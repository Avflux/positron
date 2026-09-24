using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using idK5By1ORRRAapLJQ3M;

namespace Eletron4;

public class clsMascara
{
	public struct structAttVisivel
	{
		public string sHandle;

		public List<string> lAtt;
	}

	public static void IndefineModeloDaMmascara(int iIndiceDel, ref string[] mPortas)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		mPortas = new string[1];
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
						if (Operators.CompareString(left, "M", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureMascara Masc = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
						if (Masc.indexModelo == iIndiceDel)
						{
							if (!Masc.Complementar)
							{
								int num = Information.UBound(mPortas) + 1;
								mPortas = (string[])Utils.CopyArray(mPortas, new string[num + 1]);
								mPortas[num] = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							}
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "MODELO", "");
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "FABRICANTE", "");
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "DESCRICAO", "");
							Masc.indexModelo = 0;
							Masc.iLM1 = 0;
							Masc.iLM2 = 0;
							Masc.Descricao = "";
							Masc.Layout = "";
							Masc.Fabricante = "";
							Masc.Plaquetas = "";
							Masc.Topografico = "";
							XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
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
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static string BuscaNomeDaMascara(string sHandle)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected Obj, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected Obj, but got Unknown
		string text = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			Entity val2 = (Entity)Geral.HandleToObject(sHandle);
			if (val2 != null)
			{
				BlockReference blockRef = (BlockReference)val2;
				object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
				val2 = (Entity)(object)blockRef;
				DeclaracoesEntidades.StructureMascara structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
				text = structureMascara.Nome1;
				if (Operators.CompareString(structureMascara.Nome2, "", TextCompare: true) != 0)
				{
					text = text + "/" + structureMascara.Nome2;
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
		return text;
	}

	public static void InsereModeloNaMascara(ref Entity ent, ref int iIndiceModeloMascara, string sNome, DeclaracoesEntidades.StructureMascara MascTEMP)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DeclaracoesEntidades.StructureMascara structureMascara = default;
				BlockReference blockRef = (BlockReference)ent;
				object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
				ent = (Entity)(object)blockRef;
				structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
				Entity ent2 = (Entity)val2.GetObject(((DBObject)ent).ObjectId, (OpenMode)0);
				if (structureMascara.indexModelo != 0)
				{
					if (structureMascara.indexModelo != iIndiceModeloMascara)
					{
						MsgBoxResult msgBoxResult = MsgBoxResult.No;
						msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 978], "\r\n"), DeclaracoesGeral.mMensagem[1, 979]), " "), sNome), " ?"), MsgBoxStyle.YesNo, "Eletron");
						if (msgBoxResult != MsgBoxResult.No)
						{
							string handleMascara = ((object)((DBObject)ent2).Handle/*cast due to constrained. prefix*/).ToString();
							desvincularPortas(handleMascara, structureMascara.indexModelo, iIndiceModeloMascara);
							desvincularDefinicoes(handleMascara, iIndiceModeloMascara);
							EditaMascara(ent2, "MODELO", sNome);
							structureMascara.indexModelo = iIndiceModeloMascara;
							structureMascara.iLM1 = MascTEMP.iLM1;
							structureMascara.iLM2 = MascTEMP.iLM2;
							structureMascara.Layout = MascTEMP.Layout;
							structureMascara.Topografico = MascTEMP.Topografico;
							XDataDispositivosMaster.GravarXDataMascara(ref ent2, ref structureMascara);
						}
					}
					else
					{
						Interaction.MsgBox(RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 977]), MsgBoxStyle.Information);
					}
				}
				else
				{
					((DBObject)ent2).UpgradeOpen();
					structureMascara.indexModelo = iIndiceModeloMascara;
					structureMascara.iLM1 = MascTEMP.iLM1;
					structureMascara.iLM2 = MascTEMP.iLM2;
					structureMascara.Layout = MascTEMP.Layout;
					structureMascara.Topografico = MascTEMP.Topografico;
					structureMascara.Modelo = MascTEMP.Modelo;
					structureMascara.Descricao = MascTEMP.Descricao;
					XDataDispositivosMaster.GravarXDataMascara(ref ent2, ref structureMascara);
					string sHandle = ((object)((DBObject)ent2).Handle/*cast due to constrained. prefix*/).ToString();
					clsBlocos.EditaUmaMascara(ref sHandle, structureMascara, bAlternativoVisivel: true);
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

	public static void desvincularPortas(string HandleMascara, long indexModelo, long indexNovoModelo)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		DeclaracoesEntidades.StructurePortas structurePortas = default;
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
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "E", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							structurePortas = ((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj));
							if (Operators.CompareString(structurePortas.HandleDaMascara, HandleMascara, TextCompare: true) == 0 && structurePortas.indiceDoModelo == indexModelo)
							{
								structurePortas.indiceDoModelo = checked((int)indexNovoModelo);
								structurePortas.indiceDaPorta = 0;
								structurePortas.handleDaDefinicao = "";
								structurePortas.chavePrimaria = "";
								structurePortas.Alternativo = "";
								XDataDispositivosMaster.GravarXDataPorta(ref ent, ref structurePortas);
								IndefineUmaPorta(ent);
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

	public static void desvincularDefinicoes(string HandleMascara, long indexNovoModelo)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
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
						Def.Nome = "";
						Def.HandleDaMascara = "";
						XDataDispositivosMaster.LerXDataDefinicao(ref Ent, ref Def);
						if (Operators.CompareString(Def.Nome, "Definicao", TextCompare: true) == 0 && Operators.CompareString(Def.HandleDaMascara, HandleMascara, TextCompare: true) == 0)
						{
							DBText val5 = (DBText)(object)((Ent is DBText) ? Ent : null);
							((DBObject)val5).UpgradeOpen();
							val5.TextString = "( )";
							Def.indiceDoModelo = checked((int)indexNovoModelo);
							Def.indiceDaPorta = 0;
							Def.handleDaPorta = "";
							XDataDispositivosMaster.GravarXDataDefinicao(ref Ent, ref Def);
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

	public static void carregaModelosDeMascaraNoDG(ref DataGridView dg, Declaracoes2.MModeloDeMascara[] mMODELO)
	{
		checked
		{
			try
			{
				dg.Rows.Clear();
				dg.Columns.Clear();
				if (mMODELO == null || Information.UBound(mMODELO) <= 0)
				{
					return;
				}
				dg.Columns.Add("IndiceModelo", "#");
				dg.Columns.Add("Nome", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 987]));
				dg.Columns.Add("Material1", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1084], "1")));
				dg.Columns.Add("Material2", Conversions.ToString(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1084], "2")));
				dg.Columns.Add("Topográfico", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 990]));
				dg.Columns.Add("Layout", Conversions.ToString(DeclaracoesGeral.mMensagem[1, 991]));
				dg.Columns.Add("", "");
				dg.ColumnHeadersVisible = true;
				int num = Information.UBound(mMODELO);
				for (int i = 1; i <= num; i++)
				{
					dg.Rows.Add(mMODELO[i].iIndiceModelo, mMODELO[i].sNomeModelo, mMODELO[i].iLM1, mMODELO[i].iLM2, mMODELO[i].sBlocoTopografico, mMODELO[i].sBlocoLayout, "");
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
					while (num3 <= 6);
				}
				AtualizaColunasDGModelos(ref dg);
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

	public static void carregaModelosDeMascaraNoCombo(ref ComboBox combo, Declaracoes2.MModeloDeMascara[] mMODELO)
	{
		try
		{
			combo.Items.Clear();
			if (Information.UBound(mMODELO) > 0)
			{
				int num = Information.UBound(mMODELO);
				for (int i = 1; i <= num; i = checked(i + 1))
				{
					combo.Items.Add(mMODELO[i].sNomeModelo);
				}
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
	}

	public static void AtualizaColunasDGModelos(ref DataGridView dg)
	{
		checked
		{
			if (dg.RowCount != 0)
			{
				double num = ((!haG8HN1M755FJ2bc2NW.ARP1IVj2So(dg)) ? ((double)(dg.Width - 4)) : ((double)(dg.Width - 21)));
				dg.Columns[0].Width = (int)Math.Round(num * 0.1);
				dg.Columns[1].Width = (int)Math.Round(num * 0.18);
				dg.Columns[2].Width = (int)Math.Round(num * 0.1);
				dg.Columns[3].Width = (int)Math.Round(num * 0.1);
				dg.Columns[4].Width = (int)Math.Round(num * 0.26);
				dg.Columns[5].Width = (int)Math.Round(num * 0.26);
				dg.Columns[6].Width = 0;
				dg.Columns[0].Visible = true;
				dg.Columns[1].Visible = true;
				dg.Columns[2].Visible = true;
				dg.Columns[3].Visible = true;
				dg.Columns[4].Visible = true;
				dg.Columns[5].Visible = true;
				dg.Columns[6].Visible = false;
				dg.Columns[0].ReadOnly = false;
				dg.Columns[1].ReadOnly = false;
				dg.Columns[2].ReadOnly = false;
				dg.Columns[3].ReadOnly = false;
				dg.Columns[4].ReadOnly = false;
				dg.Columns[5].ReadOnly = false;
				dg.Columns[6].ReadOnly = false;
				dg.MultiSelect = false;
			}
		}
	}

	public static void EditaAsMascaras(string Nome1, string Nome2, string Alternativo, DeclaracoesEntidades.StructureMascara MascTEMP, bool bIndefineMascara)
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
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_0340: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(left, "M", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureMascara Masc = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
						if (Masc.Painel != MascTEMP.Painel || !((Operators.CompareString(Masc.Nome1, Nome1, TextCompare: true) == 0) & (Operators.CompareString(Masc.Nome2, Nome2, TextCompare: true) == 0) & (Operators.CompareString(Masc.Alternativo, Alternativo, TextCompare: true) == 0)) || Masc.Complementar)
						{
							continue;
						}
						if (Masc.indexModelo != 0)
						{
							if (bIndefineMascara)
							{
								if (Masc.indexModelo == MascTEMP.indexModelo)
								{
									break;
								}
								MsgBoxResult msgBoxResult = MsgBoxResult.No;
								msgBoxResult = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 978], "\r\n"), DeclaracoesGeral.mMensagem[1, 979]), " "), MascTEMP.Modelo), " ?"), MsgBoxStyle.YesNo, "Eletron");
								if (msgBoxResult == MsgBoxResult.No)
								{
									break;
								}
							}
							if (!bIndefineMascara)
							{
								MsgBoxResult msgBoxResult2 = MsgBoxResult.No;
								msgBoxResult2 = Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 970], "\r\n"), DeclaracoesGeral.mMensagem[1, 979]), " "), MascTEMP.Modelo), " ?"), MsgBoxStyle.YesNo, "Eletron");
								if (msgBoxResult2 == MsgBoxResult.No)
								{
									break;
								}
							}
							else
							{
								string handleMascara = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								desvincularPortas(handleMascara, Masc.indexModelo, MascTEMP.indexModelo);
								desvincularDefinicoes(handleMascara, MascTEMP.indexModelo);
							}
							Masc.indexModelo = MascTEMP.indexModelo;
							Masc.iLM1 = MascTEMP.iLM1;
							Masc.iLM2 = MascTEMP.iLM2;
							Masc.Layout = MascTEMP.Layout;
							Masc.Topografico = MascTEMP.Topografico;
							Masc.Modelo = MascTEMP.Modelo;
							Masc.Descricao = MascTEMP.Descricao;
							Masc.Fabricante = MascTEMP.Fabricante;
							XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmaMascara(ref tipoImportado, Masc, bAlternativoVisivel: true);
							clsPortas.EditaOsIndicesDoModeloDeMascara(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), MascTEMP.indexModelo);
							if (!bIndefineMascara)
							{
								Declaracoes2.MModeloDePortas[] mPortas = new Declaracoes2.MModeloDePortas[1];
								DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref MascTEMP.indexModelo, MascTEMP.Modelo, ref mPortas);
								clsPortas.AtualizaPortasPortas(Conversions.ToString((int)Masc.Painel), MascTEMP.indexModelo, mPortas);
								clsPortas.SincronizaPortas();
							}
						}
						else
						{
							((DBObject)ent).UpgradeOpen();
							Masc.indexModelo = MascTEMP.indexModelo;
							Masc.iLM1 = MascTEMP.iLM1;
							Masc.iLM2 = MascTEMP.iLM2;
							Masc.Layout = MascTEMP.Layout;
							Masc.Topografico = MascTEMP.Topografico;
							Masc.Modelo = MascTEMP.Modelo;
							Masc.Descricao = MascTEMP.Descricao;
							Masc.Fabricante = MascTEMP.Fabricante;
							XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmaMascara(ref tipoImportado, Masc, bAlternativoVisivel: true);
							clsPortas.EditaOsIndicesDoModeloDeMascara(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), MascTEMP.indexModelo);
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

	public static string BuscaAMascaraPrincipal(int iPainel, string Nome1, string Nome2, string Alternativo, [Optional][DefaultParameterValue(0)] ref int indexModelo)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
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
					if (Operators.CompareString(left, "M", TextCompare: true) == 0)
					{
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureMascara structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
						if (((structureMascara.Painel == iPainel) & (Operators.CompareString(structureMascara.Nome1, Nome1, TextCompare: true) == 0) & (Operators.CompareString(structureMascara.Nome2, Nome2, TextCompare: true) == 0) & (Operators.CompareString(structureMascara.Alternativo, Alternativo, TextCompare: true) == 0)) && !structureMascara.Complementar)
						{
							indexModelo = structureMascara.indexModelo;
							result = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
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
		return result;
	}

	public static void InserirMascara(DeclaracoesEntidades.StructureMascara DispMasc, bool bAlternativoVisivel, bool bModeloVisivel, int iCorDaMascara)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected Obj, but got Unknown
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Invalid comparison between Unknown and I4
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected Obj, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Expected Obj, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Expected Obj, but got Unknown
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected Obj, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Expected Obj, but got Unknown
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				string text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Cadgraph\\Eletron4\\";
				string text2 = "MascaraM";
				ObjectId val3 = ObjectId.Null;
				BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockReference val6 = null;
				BlockTableRecord val7 = null;
				if (!((SymbolTable)val4).Has(text2))
				{
					Database val8 = new Database(false, true);
					val8.ReadDwgFile(text + text2 + ".DWG", FileShare.Read, true, "");
					DeclaracoesGeral.bAnularEventos = true;
					val3 = database.Insert(text2 + ".DWG", val8, false);
					((DisposableWrapper)val8).Dispose();
				}
				else
				{
					BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text2], (OpenMode)0);
					val3 = ((DBObject)val9).Id;
				}
				val6 = new BlockReference(Point3d.Origin, val3);
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				Jig jig = new Jig((Entity)(object)val6);
				PromptResult val10 = editor.Drag((Jig)(object)jig);
				if (!(((int)val10.Status == -5002) | ((int)val10.Status == -5001)))
				{
					val5.AppendEntity((Entity)(object)val6);
					((Entity)val6).Draw();
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					_ = val6.Position;
					val7 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					string text3 = DispMasc.Nome1;
					string alternativo = DispMasc.Alternativo;
					if (Operators.CompareString(DispMasc.Nome2, "", TextCompare: true) != 0)
					{
						text3 = text3 + "/" + DispMasc.Nome2;
					}
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
							AttributeReference val13 = new AttributeReference();
							val13.SetAttributeFromBlock(val12, val6.BlockTransform);
							string text4 = "";
							string tag = val12.Tag;
							if (Operators.CompareString(tag, "NOME1", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "FABRICANTE", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "DESCRICAO", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag, "MODELO", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag, "ALTERNATIVO", TextCompare: true) != 0)
											{
												text4 = " ";
											}
											else
											{
												text4 = alternativo;
												((Entity)val13).Visible = bAlternativoVisivel;
											}
										}
										else
										{
											text4 = DispMasc.Modelo;
											((Entity)val13).Visible = false;
											if (bModeloVisivel)
											{
												((Entity)val13).Visible = true;
											}
										}
									}
									else
									{
										text4 = DispMasc.Descricao;
									}
								}
								else
								{
									text4 = DispMasc.Fabricante;
								}
							}
							else
							{
								text4 = text3;
							}
							((Entity)val13).ColorIndex = iCorDaMascara;
							((DBText)val13).TextString = text4;
							((DBText)val13).AdjustAlignment(database);
							val6.AttributeCollection.AppendAttribute(val13);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
							((Entity)val13).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)val6).Draw();
					Entity ent = (Entity)(object)val6;
					XDataDispositivosMaster.GravarXDataMascara(ref ent, ref DispMasc);
					val6 = (BlockReference)ent;
				}
				else
				{
					val6 = null;
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void EditaUmAtributo(ref Entity ent, string sAtt, string sValor)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			ObjectId val2 = ObjectId.Null;
			BlockTable val3 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			_ = (BlockTableRecord)val.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Entity obj = ent;
			BlockReference val4 = (BlockReference)(object)((obj is BlockReference) ? obj : null);
			string name = val4.Name;
			if (((SymbolTable)val3).Has(name))
			{
				BlockTableRecord val5 = (BlockTableRecord)val.GetObject(((SymbolTable)val3)[name], (OpenMode)0);
				val2 = ((DBObject)val5).Id;
			}
			if (!val2.IsNull)
			{
				BlockTableRecord val6 = (BlockTableRecord)val.GetObject(val4.BlockTableRecord, (OpenMode)1);
				if (string.Compare(((SymbolTableRecord)val6).Name, name, ignoreCase: true) == 0)
				{
					AttributeCollection attributeCollection = val4.AttributeCollection;
					((DBObject)val4).UpgradeOpen();
					foreach (object item in attributeCollection)
					{
						ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)1);
						if (Operators.CompareString(val8.Tag, sAtt, TextCompare: true) == 0)
						{
							((DBText)val8).TextString = sValor;
							break;
						}
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

	public static void IndefineUmaPorta(Entity ENT)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction topTransaction = database.TransactionManager.TopTransaction;
			try
			{
				ObjectId val = ObjectId.Null;
				BlockTable val2 = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockReference val3 = (BlockReference)(object)((ENT is BlockReference) ? ENT : null);
				string name = val3.Name;
				if (((SymbolTable)val2).Has(name))
				{
					BlockTableRecord val4 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[name], (OpenMode)0);
					val = ((DBObject)val4).Id;
				}
				if (val.IsNull)
				{
					return;
				}
				BlockTableRecord val5 = (BlockTableRecord)topTransaction.GetObject(val3.BlockTableRecord, (OpenMode)1);
				if (string.Compare(((SymbolTableRecord)val5).Name, name, ignoreCase: true) != 0)
				{
					return;
				}
				AttributeCollection attributeCollection = val3.AttributeCollection;
				foreach (object item in attributeCollection)
				{
					ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
					string text = "";
					text = ((DBText)val7).TextString;
					string tag = val7.Tag;
					if (Operators.CompareString(tag, "NOME1", TextCompare: true) != 0 && Operators.CompareString(tag, "NOME2", TextCompare: true) != 0 && Operators.CompareString(tag, "ALTERNATIVO", TextCompare: true) != 0)
					{
						text = "";
					}
					((DBText)val7).TextString = text;
				}
			}
			finally
			{
				((IDisposable)topTransaction)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void EditaMascara(Entity ENT, string TAG, string sValor)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction topTransaction = database.TransactionManager.TopTransaction;
			try
			{
				ObjectId val = ObjectId.Null;
				BlockTable val2 = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockReference val3 = (BlockReference)(object)((ENT is BlockReference) ? ENT : null);
				string name = val3.Name;
				if (((SymbolTable)val2).Has(name))
				{
					BlockTableRecord val4 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val2)[name], (OpenMode)0);
					val = ((DBObject)val4).Id;
				}
				if (val.IsNull)
				{
					return;
				}
				BlockTableRecord val5 = (BlockTableRecord)topTransaction.GetObject(val3.BlockTableRecord, (OpenMode)1);
				if (string.Compare(((SymbolTableRecord)val5).Name, name, ignoreCase: true) != 0)
				{
					return;
				}
				AttributeCollection attributeCollection = val3.AttributeCollection;
				foreach (object item in attributeCollection)
				{
					ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
					if (Operators.CompareString(val7.Tag, TAG, TextCompare: true) == 0)
					{
						((DBText)val7).TextString = sValor;
					}
				}
			}
			finally
			{
				((IDisposable)topTransaction)?.Dispose();
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static void CarregaMascaras(ref Declaracoes2.MMascara[] mMasc)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		mMasc = (Declaracoes2.MMascara[])Utils.CopyArray(mMasc, new Declaracoes2.MMascara[1]);
		int num = 0;
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
						DeclaracoesEntidades.StructureMascara structureMascara = default;
						string text = "";
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "M", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
							num = Information.UBound(mMasc) + 1;
							mMasc = (Declaracoes2.MMascara[])Utils.CopyArray(mMasc, new Declaracoes2.MMascara[num + 1]);
							mMasc[num].sNome1 = structureMascara.Nome1;
							mMasc[num].sNome2 = structureMascara.Nome2;
							mMasc[num].sNome3 = structureMascara.Alternativo;
							mMasc[num].iPainel = structureMascara.Painel;
							mMasc[num].sPainel = Dicionario.BuscaNomeDoPainel(structureMascara.Painel);
							mMasc[num].sPagina = ent.Layer.ToString();
							mMasc[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							text = "C";
							if (structureMascara.Complementar == Conversions.ToBoolean("0"))
							{
								text = "P";
							}
							if (((double)structureMascara.indexModelo == Conversions.ToDouble("0")) & (structureMascara.Complementar == Conversions.ToBoolean("0")))
							{
								text = "N";
							}
							mMasc[num].sTipo = text;
							mMasc[num].iIndiceModelo = structureMascara.indexModelo;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				if (Information.UBound(mMasc) >= 2 && Information.UBound(mMasc) > 0)
				{
					int num2 = Information.UBound(mMasc) - 1;
					for (int i = num2; i >= 1; i += -1)
					{
						int num3 = i;
						for (int j = 1; j <= num3; j++)
						{
							if (Operators.CompareString(mMasc[j].sPainel.ToString(), mMasc[j + 1].sPainel.ToString(), TextCompare: true) > 0)
							{
								Declaracoes2.MMascara mMascara = mMasc[j + 1];
								mMasc[j + 1] = mMasc[j];
								mMasc[j] = mMascara;
							}
							if (Operators.CompareString(mMasc[j].sPainel.ToString(), mMasc[j + 1].sPainel.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome1.ToString(), mMasc[j + 1].sNome1.ToString(), TextCompare: true) > 0)
							{
								Declaracoes2.MMascara mMascara2 = mMasc[j + 1];
								mMasc[j + 1] = mMasc[j];
								mMasc[j] = mMascara2;
							}
							if (Operators.CompareString(mMasc[j].sPainel.ToString(), mMasc[j + 1].sPainel.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome1.ToString(), mMasc[j + 1].sNome1.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome2.ToString(), mMasc[j + 1].sNome2.ToString(), TextCompare: true) > 0)
							{
								Declaracoes2.MMascara mMascara3 = mMasc[j + 1];
								mMasc[j + 1] = mMasc[j];
								mMasc[j] = mMascara3;
							}
							if (Operators.CompareString(mMasc[j].sPainel.ToString(), mMasc[j + 1].sPainel.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome1.ToString(), mMasc[j + 1].sNome1.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome2.ToString(), mMasc[j + 1].sNome2.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome3.ToString(), mMasc[j + 1].sNome3.ToString(), TextCompare: true) > 0)
							{
								Declaracoes2.MMascara mMascara4 = mMasc[j + 1];
								mMasc[j + 1] = mMasc[j];
								mMasc[j] = mMascara4;
							}
							if (Operators.CompareString(mMasc[j].sPainel.ToString(), mMasc[j + 1].sPainel.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome1.ToString(), mMasc[j + 1].sNome1.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome2.ToString(), mMasc[j + 1].sNome2.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sNome3.ToString(), mMasc[j + 1].sNome3.ToString(), TextCompare: true) == 0 && Operators.CompareString(mMasc[j].sTipo.ToString(), mMasc[j + 1].sTipo.ToString(), TextCompare: true) < 0)
							{
								Declaracoes2.MMascara mMascara5 = mMasc[j + 1];
								mMasc[j + 1] = mMasc[j];
								mMasc[j] = mMascara5;
							}
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
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void ApagaAMascara(Entity entMasc)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected Obj, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected Obj, but got Unknown
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
		//IL_054c: Expected Obj, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c4: Expected Obj, but got Unknown
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Expected Obj, but got Unknown
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Expected Obj, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference blockRef = (BlockReference)entMasc;
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					entMasc = (Entity)(object)blockRef;
					object obj2 = obj;
					DeclaracoesEntidades.StructureMascara structureMascara = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
					if (structureMascara.Complementar)
					{
						return;
					}
					string sHandle = ((object)((DBObject)entMasc).Handle/*cast due to constrained. prefix*/).ToString();
					string sValor = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "MODELO");
					string sValor2 = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "FABRICANTE");
					string sValor3 = clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "DESCRICAO");
					string sHandle2 = "";
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "M", TextCompare: true) != 0)
							{
								continue;
							}
							blockRef = (BlockReference)ent;
							obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							object obj3 = obj;
							DeclaracoesEntidades.StructureMascara Masc = ((obj3 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj3));
							if (!((structureMascara.Painel == Masc.Painel) & (Operators.CompareString(structureMascara.Nome1, Masc.Nome1, TextCompare: true) == 0) & (Operators.CompareString(structureMascara.Nome2, Masc.Nome2, TextCompare: true) == 0) & (Operators.CompareString(structureMascara.Alternativo, Masc.Alternativo, TextCompare: true) == 0) & (Operators.CompareString(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), ((object)((DBObject)entMasc).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)))
							{
								continue;
							}
							if (Operators.CompareString(sHandle2, "", TextCompare: true) != 0)
							{
								Masc.HandleMascPrincipal = sHandle2;
								Masc.iLM1 = 0;
								Masc.iLM2 = 0;
								Masc.Topografico = "";
								Masc.Layout = "";
								if (Operators.CompareString(clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "MODELO"), "", TextCompare: true) == 0)
								{
									tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "MODELO", sValor, bliga: false);
								}
								if (Operators.CompareString(clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "FABRICANTE"), "", TextCompare: true) == 0)
								{
									tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "FABRICANTE", sValor2);
								}
								if (Operators.CompareString(clsBlocos.LeUmAtributoDeUmBloco(ref sHandle, "DESCRICAO"), "", TextCompare: true) == 0)
								{
									tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
									clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "DESCRICAO", sValor3, bliga: false);
								}
								XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
							}
							if (Operators.CompareString(sHandle2, "", TextCompare: true) == 0)
							{
								sHandle2 = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								Masc = structureMascara;
								if (Operators.CompareString(clsBlocos.LeUmAtributoDeUmBloco(ref sHandle2, "MODELO"), "", TextCompare: true) == 0)
								{
									clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle2, "MODELO", sValor);
								}
								if (Operators.CompareString(clsBlocos.LeUmAtributoDeUmBloco(ref sHandle2, "FABRICANTE"), "", TextCompare: true) == 0)
								{
									clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle2, "FABRICANTE", sValor2);
								}
								if (Operators.CompareString(clsBlocos.LeUmAtributoDeUmBloco(ref sHandle2, "DESCRICAO"), "", TextCompare: true) == 0)
								{
									clsBlocos.EditaUmAtributoDeUmBloco(ref sHandle2, "DESCRICAO", sValor3, bliga: false);
								}
								XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					if (Operators.CompareString(sHandle2, "", TextCompare: true) == 0)
					{
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val4.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity ent2 = (Entity)val2.GetObject(current2, (OpenMode)1);
								string tipoImportado = "";
								string left2 = XDataDispositivo.verificaTipoDispositivo(ref ent2, ref tipoImportado);
								if (Operators.CompareString(left2, "E", TextCompare: true) != 0)
								{
									DeclaracoesEntidades.StructureDefinicaoPortas Def = default;
									if (XDataDispositivosMaster.LerXDataDefinicao(ref ent2, ref Def) && Operators.CompareString(Def.HandleDaMascara, sHandle, TextCompare: true) == 0)
									{
										((DBObject)ent2).UpgradeOpen();
										((DBObject)ent2).Erase();
									}
									continue;
								}
								DeclaracoesEntidades.StructurePortas structurePortas = default;
								blockRef = (BlockReference)ent2;
								obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent2 = (Entity)(object)blockRef;
								object obj4 = obj;
								if (Operators.CompareString(((obj4 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj4)).HandleDaMascara, sHandle, TextCompare: true) == 0)
								{
									((DBObject)ent2).UpgradeOpen();
									((DBObject)ent2).Erase();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
					}
					else
					{
						BlockTableRecordEnumerator enumerator3 = default;
						try
						{
							enumerator3 = val4.GetEnumerator();
							while (enumerator3.MoveNext())
							{
								ObjectId current3 = enumerator3.Current;
								Entity ent3 = (Entity)val2.GetObject(current3, (OpenMode)1);
								string tipoImportado = "";
								string left3 = XDataDispositivo.verificaTipoDispositivo(ref ent3, ref tipoImportado);
								if (Operators.CompareString(left3, "E", TextCompare: true) != 0)
								{
									DeclaracoesEntidades.StructureDefinicaoPortas Def2 = default;
									if (XDataDispositivosMaster.LerXDataDefinicao(ref ent3, ref Def2) && Operators.CompareString(Def2.HandleDaMascara, sHandle, TextCompare: true) == 0)
									{
										Def2.HandleDaMascara = sHandle2;
										XDataDispositivosMaster.GravarXDataDefinicao(ref ent3, ref Def2);
									}
									continue;
								}
								DeclaracoesEntidades.StructurePortas structurePortas2 = default;
								blockRef = (BlockReference)ent3;
								obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent3 = (Entity)(object)blockRef;
								object obj5 = obj;
								structurePortas2 = ((obj5 == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj5));
								if (Operators.CompareString(structurePortas2.HandleDaMascara, sHandle, TextCompare: true) == 0)
								{
									structurePortas2.HandleDaMascara = sHandle2;
									XDataDispositivosMaster.GravarXDataPorta(ref ent3, ref structurePortas2);
								}
							}
						}
						finally
						{
							((IDisposable)enumerator3)?.Dispose();
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
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			throw;
		}
		finally
		{
		}
	}

	public static void EditaUmaMascaraSelecionadaNoDG(string sHandleMasc, string sNovoNome1, string sNovoNome2, string sNovoAlternativo, bool bAlternativo, string sFabricante, string sDescricao, Declaracoes2.MModeloDeMascara[] mMODELO, int indexModelo)
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected Obj, but got Unknown
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				DeclaracoesEntidades.StructureMascara structureMascara = default;
				ObjectId val3 = clsBlocos.RetornaID_Bloco(sHandleMasc);
				if (val3.IsValid)
				{
					BlockReference blockRef = (BlockReference)val2.GetObject(val3, (OpenMode)0);
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val5.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string tipoImportado = "";
							string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
							if (Operators.CompareString(left, "M", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef2 = (BlockReference)ent;
							object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef2);
							ent = (Entity)(object)blockRef2;
							DeclaracoesEntidades.StructureMascara Masc = ((obj2 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj2));
							if (!((Operators.CompareString(Masc.Nome1, structureMascara.Nome1, TextCompare: true) == 0) & (Operators.CompareString(Masc.Nome2, structureMascara.Nome2, TextCompare: true) == 0) & (Operators.CompareString(Masc.Alternativo, structureMascara.Alternativo, TextCompare: true) == 0)) || !((Operators.CompareString(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), sHandleMasc, TextCompare: true) == 0) | (Operators.CompareString(sHandleMasc, Masc.HandleMascPrincipal, TextCompare: true) == 0)))
							{
								continue;
							}
							Masc.Nome1 = sNovoNome1;
							Masc.Nome2 = sNovoNome2;
							Masc.Alternativo = sNovoAlternativo;
							Masc.Fabricante = sFabricante;
							Masc.Descricao = sDescricao;
							Masc.Modelo = "";
							int num = Information.UBound(mMODELO);
							for (int i = 1; i <= num; i = checked(i + 1))
							{
								if (mMODELO[i].iIndiceModelo == indexModelo)
								{
									Masc.indexModelo = indexModelo;
									Masc.Modelo = mMODELO[i].sNomeModelo;
									break;
								}
							}
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							string left2 = clsBlocos.LeUmAtributoDeUmBloco(ref tipoImportado, "MODELO");
							if (Operators.CompareString(left2, "", TextCompare: true) == 0)
							{
								Masc.Modelo = "";
							}
							XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmaMascara(ref tipoImportado, Masc, bAlternativo);
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

	public static void MudaMascaraPrincipalExcluida(ref DeclaracoesEntidades.StructureMascara MascPri, string sHandleCorrente, bool bPrincipal)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = Geral.HandleToID(sHandleCorrente);
				if (val3.IsValid)
				{
					Entity val4 = (Entity)val2.GetObject(val3, (OpenMode)1);
					DeclaracoesEntidades.StructureMascara structureMascara = default;
					BlockReference blockRef = (BlockReference)val4;
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					val4 = (Entity)(object)blockRef;
					structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
					if (!bPrincipal)
					{
						structureMascara.HandleMascPrincipal = MascPri.HandleMascPrincipal;
						structureMascara.Complementar = true;
						structureMascara.iLM1 = 0;
						structureMascara.iLM2 = 0;
						structureMascara.Topografico = "";
						structureMascara.Layout = "";
					}
					else
					{
						structureMascara.iLM1 = MascPri.iLM1;
						structureMascara.iLM2 = MascPri.iLM2;
						structureMascara.Topografico = MascPri.Topografico;
						structureMascara.Layout = MascPri.Layout;
						structureMascara.HandleMascPrincipal = "";
						structureMascara.Complementar = false;
					}
					XDataDispositivosMaster.GravarXDataMascara(ref val4, ref structureMascara);
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

	public static string BuscaPainel(string sHandleMascara)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected Obj, but got Unknown
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = Geral.HandleToID(sHandleMascara);
				if (val3.IsValid)
				{
					Entity val4 = (Entity)val2.GetObject(val3, (OpenMode)1);
					DeclaracoesEntidades.StructureMascara structureMascara = default;
					BlockReference blockRef = (BlockReference)val4;
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					val4 = (Entity)(object)blockRef;
					structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
					if (Versioned.IsNumeric(structureMascara.Painel))
					{
						result = Dicionario.BuscaNomeDoPainel(structureMascara.Painel);
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
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static int BuscaCorDaMascara()
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
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		int colorIndex = default;
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
					IEnumerator enumerator2 = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "M", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
						AttributeCollection attributeCollection = val5.AttributeCollection;
						{
							enumerator2 = attributeCollection.GetEnumerator();
							try
							{
								if (enumerator2.MoveNext())
								{
									object current2 = enumerator2.Current;
									ObjectId val6 = ((current2 == null) ? default(ObjectId) : ((ObjectId)current2));
									AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
									colorIndex = ((Entity)val7).ColorIndex;
								}
							}
							finally
							{
								IDisposable disposable = enumerator2 as IDisposable;
								if (disposable != null)
								{
									disposable.Dispose();
								}
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
		return colorIndex;
	}

	public static void EditaAsMascarasDoDispositivo(string sHandle, int iPN, string sNome1, string sNome2, string sAlternativo)
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
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), sHandle, TextCompare: true) != 0)
						{
							continue;
						}
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "M", TextCompare: true) == 0)
						{
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							DeclaracoesEntidades.StructureMascara Masc = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
							((DBObject)ent).UpgradeOpen();
							Masc.Nome1 = sNome1;
							Masc.Nome2 = sNome2;
							Masc.Alternativo = sAlternativo;
							XDataDispositivosMaster.GravarXDataMascara(ref ent, ref Masc);
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaNomesDeUmBloco(ref tipoImportado, Masc.Nome1, Masc.Nome2, Masc.Alternativo);
							if (!Masc.Complementar)
							{
								clsPortas.EditaNomeDePortasDeUmaMascara(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), Masc.Nome1, Masc.Nome2, Masc.Alternativo, bAlternativo: true);
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

	public static void LeAtributosDaMascaraSelecionada(string HandleMascara, ref structAttVisivel[] mAtt)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected Obj, but got Unknown
		int num = 0;
		mAtt = new structAttVisivel[1];
		DeclaracoesEntidades.StructurePortas structurePortas = default;
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
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "E", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							if (Operators.CompareString(((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj)).HandleDaMascara, HandleMascara, TextCompare: true) != 0)
							{
								continue;
							}
							string sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							List<string> list = new List<string>();
							BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							AttributeCollection attributeCollection = val5.AttributeCollection;
							foreach (object item in attributeCollection)
							{
								ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)0);
								if (((Entity)val7).Visible)
								{
									list.Add(val7.Tag);
								}
							}
							num++;
							mAtt = (structAttVisivel[])Utils.CopyArray(mAtt, new structAttVisivel[num + 1]);
							mAtt[num].sHandle = sHandle;
							mAtt[num].lAtt = list;
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
	}

	public static void RestauraAtributosDaMascaraSelecionada(string HandleMascara, ref structAttVisivel[] mAtt)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Expected Obj, but got Unknown
		DeclaracoesEntidades.StructurePortas structurePortas = default;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "E", TextCompare: true) != 0)
						{
							continue;
						}
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						if (Operators.CompareString(((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj)).HandleDaMascara, HandleMascara, TextCompare: true) != 0)
						{
							continue;
						}
						string sHandlePorta = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
						List<string> list = recuperaAtt(sHandlePorta, mAtt);
						BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
						AttributeCollection attributeCollection = val5.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							if (!list.Contains(val7.Tag))
							{
								((Entity)val7).Visible = false;
							}
							else
							{
								((Entity)val7).Visible = true;
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

	public static List<string> recuperaAtt(string sHandlePorta, structAttVisivel[] mAtt)
	{
		List<string> result = new List<string>();
		for (int i = 0; i < mAtt.Length; i = checked(i + 1))
		{
			structAttVisivel structAttVisivel2 = mAtt[i];
			if (Operators.CompareString(structAttVisivel2.sHandle, sHandlePorta, TextCompare: true) == 0)
			{
				result = structAttVisivel2.lAtt;
				break;
			}
		}
		return result;
	}

	public static void EncontraModelosUsados(ref List<int> lModelosUsados)
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
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
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
					if (Operators.CompareString(left, "M", TextCompare: true) == 0)
					{
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						DeclaracoesEntidades.StructureMascara structureMascara = ((obj == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj));
						if (!lModelosUsados.Contains(structureMascara.indexModelo))
						{
							lModelosUsados.Add(structureMascara.indexModelo);
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}

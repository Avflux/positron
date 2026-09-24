using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Relatorios_CabosEDPESDWG
{
	public struct structureRelatCabosEDPESDWG
	{
		public string Tag;

		public string Formacao;

		public string Funcao;

		public string sBlindagem;

		public string Comprimento;

		public int iPn1;

		public int iPn2;

		public string sPn1;

		public string sPn2;

		public string sObs;

		public string sVeiasUsadas;

		public string sVeiasLivres;

		public string Instrucao;
	}

	public struct ConfigRelatCabosEDPESDWG
	{
		public int AlturaInicial;

		public double AlturaDoBloco;

		public double TamanhoFonte;

		public int CorLinha;

		public int CorTexto;

		public string sFonte;
	}

	public static void CriaMatrizDeCabosEDPES_DWG(Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] mCabos, string revisaoSel, ConfigRelatCabosEDPESDWG confRelatCabos)
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double num = 0.0;
		num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		Point3d pti = RH.Pti;
		Point3d pt = new Point3d(RH.Pti.X, (double)confRelatCabos.AlturaInicial, 0.0);
		try
		{
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabos);
			DeclaracoesGeral._uscPagina.pbIniciar();
			pti = pt;
			CriaTituloTabelaCaboEDPES_Titulo(ref pt, num, mCabos, 0, confRelatCabos, revisaoSel);
			int num2 = Information.UBound(mCabos);
			for (int i = 1; i <= num2; i = checked(i + 1))
			{
				CriaTituloTabelaCaboEDPES_Corpo(num, ref pt, i, mCabos, confRelatCabos, revisaoSel);
				if (DeclaracoesGeral.bPararRelatorio)
				{
					break;
				}
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
				if (pt.Y < RH.AltBase + 1.0 + confRelatCabos.AlturaDoBloco * 1.1)
				{
					string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
					if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
					{
						Pagina.AtivaPagina(pag);
						DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
					}
					else
					{
						if (!Pagina.criarUmaNovaPagina())
						{
							return;
						}
						DeclaracoesGeral._uscPagina.CarregaPG();
					}
					pt = pti;
					CriaTituloTabelaCaboEDPES_Titulo(ref pt, num, mCabos, 0, confRelatCabos, revisaoSel);
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				if (DeclaracoesGeral.bPararRelatorio)
				{
					break;
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			DeclaracoesGeral._uscPagina.pbFim();
			ProjectData.ClearProjectError();
		}
	}

	public static void CriaTituloTabelaCaboEDPES_Titulo(ref Point3d pt, double dLarguraDoBloco, Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] mCabos, int iIndice, ConfigRelatCabosEDPESDWG confRelat, string sRevisao)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Unknown result type (might be due to invalid IL or missing references)
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		Point3d val = new Point3d(pt.X, pt.Y, 0.0);
		Point3d val2 = new Point3d(pt.X, pt.Y, 0.0);
		double y = pt.Y;
		_ = pt.X;
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				_ = (TextStyleTable)val4.GetObject(database.TextStyleTableId, (OpenMode)1);
				new DBObjectCollection();
				BlockTable val5 = (BlockTable)val4.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)1);
				_ = (BlockTableRecord)val4.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
				double dLargura = dLarguraDoBloco * 0.08;
				double dAltura = 17.0;
				List<string> list = new List<string>();
				list.Add(mCabos[0].Tag.ToUpper());
				val2 = pt;
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				dLargura = dLarguraDoBloco * 0.3;
				dAltura = 8.5;
				list.Clear();
				list.Add("TRAJETO");
				val2 = pt;
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				dLargura = dLarguraDoBloco * 0.15;
				dAltura = 8.5;
				list.Clear();
				list.Add(mCabos[0].sPn1.ToUpper());
				list.Add(mCabos[0].sPn2.ToUpper());
				pt = new Point3d(val2.X, val2.Y - dAltura, 0.0);
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				dLargura = dLarguraDoBloco * 0.16;
				dAltura = 17.0;
				list.Clear();
				list.Add(mCabos[0].Funcao);
				pt = new Point3d(pt.X, y, 0.0);
				val2 = pt;
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				dLargura = dLarguraDoBloco * 0.25;
				dAltura = 8.5;
				list.Clear();
				list.Add("CONDUTOR");
				pt = new Point3d(pt.X, y, 0.0);
				val2 = pt;
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				confRelat.TamanhoFonte = 1.5;
				dLargura = dLarguraDoBloco * 0.05;
				dAltura = 8.5;
				list.Clear();
				list.Add(mCabos[0].Formacao);
				list.Add(mCabos[0].VeiasUsadas);
				list.Add(mCabos[0].VeiasLivres);
				list.Add(mCabos[0].isolacao);
				list.Add(mCabos[0].Blindado);
				pt = new Point3d(val2.X, y - dAltura, 0.0);
				val2 = pt;
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				confRelat.TamanhoFonte = 2.0;
				dLargura = dLarguraDoBloco * 0.07;
				dAltura = 17.0;
				list.Clear();
				list.Add(mCabos[0].Comprimento);
				pt = new Point3d(pt.X, y, 0.0);
				val2 = pt;
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				dLargura = dLarguraDoBloco * 0.14;
				dAltura = 17.0;
				list.Clear();
				list.Add(mCabos[0].sObs);
				pt = new Point3d(pt.X, y, 0.0);
				val2 = pt;
				CriaTituloDaTabelaEDPParte(ref pt, 0, dLargura, dAltura, confRelat, sRevisao, list);
				pt = new Point3d(val.X, val.Y - dAltura, 0.0);
				DeclaracoesGeral.bAnularEventos = true;
				val4.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val4.Abort();
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
	}

	public static void CriaTituloDaTabelaEDPParte(ref Point3d pt, int iIndice, double dLargura, double dAltura, ConfigRelatCabosEDPESDWG ConfRelt, string sRevisao, List<string> lValor)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected Obj, but got Unknown
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Expected Obj, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					ObjectId textStyleId = ((SymbolTable)val3)[ConfRelt.sFonte];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(1, lValor.Count);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					((BlockReference)val6).Position = pt;
					val6.SetRowHeight(dAltura);
					((BlockReference)val6).Position = pt;
					int num = lValor.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						val6.Columns[i].Width = dLargura;
						((CellRange)val6.Cells[0, i]).TextHeight = ConfRelt.TamanhoFonte;
						val6.Cells[0, i].TextString = lValor[i];
					}
					((Entity)val6).ColorIndex = ConfRelt.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					((DBObject)val6).UpgradeOpen();
					val6.SetRowHeight(ConfRelt.AlturaDoBloco);
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d maxPoint = value.MaxPoint;
					double y = maxPoint.Y;
					value = ((Drawable)val6).Bounds.Value;
					maxPoint = value.MaxPoint;
					double x = maxPoint.X;
					pt = new Point3d(x, y, 0.0);
					DBObjectCollection val7 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val6).Explode(val7);
					((DBObject)val6).Erase();
					foreach (Entity item in val7)
					{
						Entity Ent = item;
						MText val8 = (MText)(object)((Ent is MText) ? Ent : null);
						try
						{
							if (val8 != null)
							{
								val8.TextStyleId = textStyleId;
								((Entity)val8).ColorIndex = ConfRelt.CorTexto;
								((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity((Entity)(object)val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								XDataRelatorio.GravarXDataCabosEDPES(ref Ent, sRevisao, iIndice);
							}
						}
						finally
						{
							((IDisposable)val8)?.Dispose();
						}
						Line val9 = (Line)(object)((Ent is Line) ? Ent : null);
						try
						{
							if (val9 != null)
							{
								Ent.Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity(Ent);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
								XDataRelatorio.GravarXDataCabosEDPES(ref Ent, sRevisao, iIndice);
							}
						}
						finally
						{
							((IDisposable)val9)?.Dispose();
						}
						((DisposableWrapper)Ent).Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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

	public static void CriaTituloTabelaCaboEDPES_Corpo(double dLarguraDoBloco, ref Point3d pt, int iIndice, Relatorios_CabosChesfDWG.structureRelatCabosEDPES[] mCabos, ConfigRelatCabosEDPESDWG ConfRelt, string sRevisao)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Expected Obj, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Expected Obj, but got Unknown
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId textStyleId = ((SymbolTable)val3)[ConfRelt.sFonte];
				new DBObjectCollection();
				BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Table val6 = new Table();
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				val6.SetSize(1, 11);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				double y = pt.Y;
				double x = pt.X;
				val6.SetRowHeight(ConfRelt.AlturaDoBloco);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco * 0.08;
				val6.Columns[1].Width = dLarguraDoBloco * 0.15;
				val6.Columns[2].Width = dLarguraDoBloco * 0.15;
				val6.Columns[3].Width = dLarguraDoBloco * 0.16;
				val6.Columns[4].Width = dLarguraDoBloco * 0.05;
				val6.Columns[5].Width = dLarguraDoBloco * 0.05;
				val6.Columns[6].Width = dLarguraDoBloco * 0.05;
				val6.Columns[7].Width = dLarguraDoBloco * 0.05;
				val6.Columns[8].Width = dLarguraDoBloco * 0.05;
				val6.Columns[9].Width = dLarguraDoBloco * 0.07;
				val6.Columns[10].Width = dLarguraDoBloco * 0.14;
				val6.Cells[0, 0].TextString = mCabos[iIndice].Tag.ToString();
				val6.Cells[0, 1].TextString = mCabos[iIndice].sPn1.ToString();
				val6.Cells[0, 2].TextString = mCabos[iIndice].sPn2.ToString();
				val6.Cells[0, 3].TextString = mCabos[iIndice].Funcao.ToString();
				val6.Cells[0, 4].TextString = mCabos[iIndice].Formacao.ToString();
				val6.Cells[0, 5].TextString = mCabos[iIndice].VeiasUsadas.ToString();
				val6.Cells[0, 6].TextString = mCabos[iIndice].VeiasLivres.ToString();
				val6.Cells[0, 7].TextString = mCabos[iIndice].isolacao.ToString();
				val6.Cells[0, 8].TextString = mCabos[iIndice].Blindado.ToString();
				val6.Cells[0, 9].TextString = mCabos[iIndice].Comprimento.ToString();
				val6.Cells[0, 10].TextString = mCabos[iIndice].sObs.ToString();
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelt.TamanhoFonte;
					if (!((num == 1) | (num == 2)))
					{
						((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					}
					else
					{
						((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)4;
					}
					num = checked(num + 1);
				}
				while (num <= 10);
				((Entity)val6).ColorIndex = ConfRelt.CorLinha;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				((DBObject)val6).UpgradeOpen();
				val6.SetRowHeight(ConfRelt.AlturaDoBloco);
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d minPoint = value.MinPoint;
				y = minPoint.Y;
				value = ((Drawable)val6).Bounds.Value;
				minPoint = value.MinPoint;
				x = minPoint.X;
				pt = new Point3d(x, y, 0.0);
				DBObjectCollection val7 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val7);
				((DBObject)val6).Erase();
				foreach (Entity item in val7)
				{
					Entity Ent = item;
					MText val8 = (MText)(object)((Ent is MText) ? Ent : null);
					try
					{
						if (val8 != null)
						{
							val8.TextStyleId = textStyleId;
							((Entity)val8).ColorIndex = ConfRelt.CorTexto;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							XDataRelatorio.GravarXDataCabosEDPES(ref Ent, sRevisao, iIndice);
						}
					}
					finally
					{
						((IDisposable)val8)?.Dispose();
					}
					Line val9 = (Line)(object)((Ent is Line) ? Ent : null);
					try
					{
						if (val9 != null)
						{
							Ent.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
							XDataRelatorio.GravarXDataCabosEDPES(ref Ent, sRevisao, iIndice);
						}
					}
					finally
					{
						((IDisposable)val9)?.Dispose();
					}
					((DisposableWrapper)Ent).Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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

	public static void ApagaRelatorioCabosEDPES(string revisaoSel)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			string pag = "";
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
						if (XDataRelatorio.LEXDataCabosEDPES(ref Ent, ref revisaoSel))
						{
							((DBObject)Ent).UpgradeOpen();
							((DBObject)Ent).Erase();
							if (Operators.CompareString(pag, "", TextCompare: true) == 0)
							{
								pag = Ent.Layer;
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
				Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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
			if (Operators.CompareString(pag, "", TextCompare: true) != 0)
			{
				Pagina.AtivaPagina(pag);
				DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static double BuscaAlturadaRegua()
	{
		double num = 0.0;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		num = RH.Pti.Y;
		return Math.Round(num, 2);
	}
}

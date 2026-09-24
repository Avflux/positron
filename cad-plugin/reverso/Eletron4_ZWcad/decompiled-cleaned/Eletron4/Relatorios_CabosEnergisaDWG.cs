using System;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Relatorios_CabosEnergisaDWG
{
	public struct structureRelatCabosEnergisa
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

	public struct ConfigRelatCabosEnergisa
	{
		public int DistEntreColunas;

		public int QuantColunas;

		public int AlturaInicial;

		public double AlturaDoBloco;

		public double TamanhoFonte;

		public int CorLinha;

		public int CorTexto;

		public string sFonte;
	}

	public static void CriaMatrizDeCabosDWGEnergisa(structureRelatCabosEnergisa[] mCabos, string revisaoSel, ConfigRelatCabosEnergisa confRelatCabos)
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double dX = 0.0;
		double dY = 0.0;
		double num = 0.0;
		num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num -= (double)(confRelatCabos.DistEntreColunas * (confRelatCabos.QuantColunas + 1));
			num /= (double)confRelatCabos.QuantColunas;
			double num2 = 0.0;
			num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - dX - (double)confRelatCabos.QuantColunas * num;
			num2 /= (double)(confRelatCabos.QuantColunas + 1);
			Point3d pt = new Point3d(RH.Pti.X + (double)confRelatCabos.DistEntreColunas, (double)confRelatCabos.AlturaInicial, 0.0);
			try
			{
				int num3 = 1;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mCabos);
				DeclaracoesGeral._uscPagina.pbIniciar();
				CriaTabelaCaboEnergisa(num, pt, mCabos, 0, ref dY, ref dX, confRelatCabos, revisaoSel);
				int num4 = Information.UBound(mCabos);
				int num5 = 1;
				while (num5 <= num4 && !DeclaracoesGeral.bPararRelatorio)
				{
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					pt = new Point3d(pt.X, dY, 0.0);
					CriaTabelaCaboEnergisa(num, pt, mCabos, num5, ref dY, ref dX, confRelatCabos, revisaoSel);
					if (dY < RH.AltBase + 1.0 + confRelatCabos.AlturaDoBloco * 1.1)
					{
						if (num3 != confRelatCabos.QuantColunas)
						{
							pt = new Point3d(dX + (double)confRelatCabos.DistEntreColunas + num, (double)confRelatCabos.AlturaInicial, 0.0);
							num3++;
						}
						else if (flag)
						{
							Pagina.OrdenaMatrizPaginas();
							string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_01ab;
								}
								Pagina.AtivaPagina(pag);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
							}
							else
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_01ab;
								}
								if (num5 < Information.UBound(mCabos))
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
								}
							}
							pt = new Point3d(RH.Pti.X + (double)confRelatCabos.DistEntreColunas, (double)confRelatCabos.AlturaInicial, 0.0);
							num3 = 1;
						}
						else
						{
							if (!Pagina.criarUmaNovaPagina())
							{
								break;
							}
							DeclaracoesGeral._uscPagina.CarregaPG();
							pt = new Point3d(RH.Pti.X + (double)confRelatCabos.DistEntreColunas, (double)confRelatCabos.AlturaInicial, 0.0);
						}
						if (num5 < Information.UBound(mCabos) - 1)
						{
							CriaTabelaCaboEnergisa(num, pt, mCabos, 0, ref dY, ref dX, confRelatCabos, revisaoSel);
							pt = new Point3d(pt.X, dY, 0.0);
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					goto IL_01ab;
					IL_01ab:
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					num5++;
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
	}

	public static void CriaTabelaCaboEnergisa(double dLarguraDoBloco, Point3d pt, structureRelatCabosEnergisa[] mCabos, int iIndice, ref double dY, ref double dX, ConfigRelatCabosEnergisa confRelatCabos, string revisaoSel)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_05dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_0410: Expected Obj, but got Unknown
		//IL_0419: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Expected Obj, but got Unknown
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Unknown result type (might be due to invalid IL or missing references)
		//IL_0523: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId textStyleId = (((SymbolTable)val3).Has(confRelatCabos.sFonte) ? ((SymbolTable)val3)["Romans"] : ((SymbolTable)val3)["Standard"]);
				new DBObjectCollection();
				BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Table val6 = new Table();
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				val6.SetSize(1, 8);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
				val6.Columns[0].Width = dLarguraDoBloco * 0.11000000000000001;
				val6.Columns[1].Width = dLarguraDoBloco * 0.19;
				val6.Columns[2].Width = dLarguraDoBloco * 0.1;
				val6.Columns[3].Width = dLarguraDoBloco * 0.075;
				val6.Columns[4].Width = dLarguraDoBloco * 0.075;
				val6.Columns[5].Width = dLarguraDoBloco * 0.075;
				val6.Columns[6].Width = dLarguraDoBloco * 0.1875;
				val6.Columns[7].Width = dLarguraDoBloco * 0.1875;
				val6.SetRowHeight(confRelatCabos.AlturaDoBloco);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = confRelatCabos.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 7);
				val6.Cells[0, 0].TextString = mCabos[iIndice].Tag.ToString();
				val6.Cells[0, 1].TextString = mCabos[iIndice].Funcao.ToString();
				val6.Cells[0, 2].TextString = mCabos[iIndice].Formacao.ToString();
				val6.Cells[0, 3].TextString = mCabos[iIndice].sVeiasUsadas.ToString();
				val6.Cells[0, 4].TextString = mCabos[iIndice].sVeiasLivres.ToString();
				val6.Cells[0, 5].TextString = mCabos[iIndice].Comprimento.ToString();
				val6.Cells[0, 6].TextString = mCabos[iIndice].sPn1.ToString();
				val6.Cells[0, 7].TextString = mCabos[iIndice].sPn2.ToString();
				val6.SetRowHeight(confRelatCabos.AlturaDoBloco);
				((BlockReference)val6).Position = position;
				dY = 100000.0;
				dX = 0.0;
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d val8 = value.MinPoint;
				dX = val8.X;
				((Entity)val6).ColorIndex = confRelatCabos.CorLinha;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				((DBObject)val6).UpgradeOpen();
				val6.SetRowHeight(confRelatCabos.AlturaDoBloco);
				DBObjectCollection val9 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val9);
				((DBObject)val6).Erase();
				foreach (Entity item in val9)
				{
					Entity Ent = item;
					MText val10 = (MText)(object)((Ent is MText) ? Ent : null);
					try
					{
						if (val10 != null)
						{
							((Entity)val10).ColorIndex = confRelatCabos.CorTexto;
							((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
							if (Operators.CompareString(val10.Text, "##B##", TextCompare: true) != 0)
							{
								val10.TextStyleId = textStyleId;
								val5.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								Entity Ent2 = (Entity)(object)val10;
								string sRelatorio = "";
								string sCabo = "";
								XDataRelatorio.GravarXDataCabosEnergisa(ref Ent2, revisaoSel, ref sRelatorio, ref sCabo);
							}
						}
					}
					finally
					{
						((IDisposable)val10)?.Dispose();
					}
					Line val11 = (Line)(object)((Ent is Line) ? Ent : null);
					try
					{
						if (val11 != null)
						{
							Ent.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent);
							value = ((Drawable)val11).Bounds.Value;
							val8 = value.MaxPoint;
							if (val8.Y < dY)
							{
								value = ((Drawable)val11).Bounds.Value;
								val8 = value.MaxPoint;
								dY = val8.Y;
							}
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
							string sCabo = "";
							string sRelatorio = "";
							XDataRelatorio.GravarXDataCabosEnergisa(ref Ent, revisaoSel, ref sCabo, ref sRelatorio);
						}
					}
					finally
					{
						((IDisposable)val11)?.Dispose();
					}
					((DisposableWrapper)Ent).Dispose();
				}
				if (iIndice == 0)
				{
					dY -= 1.5;
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

	public static void ApagaRelatorioCabosEnergisa(string revisaoSel)
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
						string sRelatorio = "";
						string sCabo = "";
						if (XDataRelatorio.LEXDataCabosEnergisa(ref Ent, ref revisaoSel, ref sRelatorio, ref sCabo))
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
}

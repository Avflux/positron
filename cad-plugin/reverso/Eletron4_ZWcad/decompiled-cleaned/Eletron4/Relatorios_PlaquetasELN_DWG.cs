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

public class Relatorios_PlaquetasELN_DWG
{
	public static void CriaMatrizPlaquetasELN(DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, int iPainel, int iL, int iT, int iLin, int iCol, double iInicioY)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		ApagaRelatorioDeplaquetasELN(iPainel);
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double num = 0.0;
		string pag = DeclaracoesGeral.ativo.Pagina;
		double num2 = 0.0;
		num = 90.0;
		num2 = ((Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - num * (double)iCol) / 2.0;
		Point3d pt = new Point3d(RH.Pti.X + num2, RH.Pti.Y - iInicioY, 0.0);
		checked
		{
			try
			{
				int num3 = 1;
				Dicionario.CriaTableStyleRelatorios("romans", 0.5);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mPlaquetas);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num4 = 0;
				string text = "";
				int num5 = Information.UBound(mPlaquetas);
				frmRelatorio_PlaquetasDWG.ConfigRelatorioPlaquetas configRelatorioPlaquetas = default;
				for (int num6 = 0; num6 <= num5; num6++)
				{
					if (num3 >= iCol && num4 > iLin)
					{
						string right = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
						if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, right, TextCompare: true) == 0)
						{
							Pagina.criarUmaNovaPagina();
							DeclaracoesGeral._uscPagina.CarregaPG();
							Pagina.AtivaPagina(DeclaracoesGeral.ativo.Pagina);
							Pagina.OrdenaMatrizPaginas();
							string pag2 = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (DeclaracoesGeral.bPararRelatorio)
							{
								goto IL_016c;
							}
							Pagina.AtivaPagina(pag2);
							DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag2);
							pt = new Point3d(RH.Pti.X + configRelatorioPlaquetas.DistEntreColunas, RH.Pti.Y - configRelatorioPlaquetas.AlturaInicial, 0.0);
							num3 = 0;
						}
					}
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					if (num6 == 0)
					{
						mPlaquetas[0].Desc1 = "##B##";
						mPlaquetas[0].Desc2 = "##B##";
						mPlaquetas[0].Desc3 = "##B##";
					}
					if (num6 != 0)
					{
						while (true)
						{
							if (num4 >= iLin + 1)
							{
								if (num3 != iCol)
								{
									num3++;
								}
								else if (flag)
								{
									if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina)), TextCompare: true) == 0)
									{
										if (!Pagina.criarUmaNovaPagina())
										{
											break;
										}
										DeclaracoesGeral._uscPagina.CarregaPG();
									}
									Pagina.OrdenaMatrizPaginas();
									string pag3 = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
									if (DeclaracoesGeral.bPararRelatorio)
									{
										goto IL_016c;
									}
									Pagina.AtivaPagina(pag3);
									DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag3);
									pt = new Point3d(RH.Pti.X + configRelatorioPlaquetas.DistEntreColunas, RH.Pti.Y - configRelatorioPlaquetas.AlturaInicial, 0.0);
									num3 = 1;
								}
								else
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
									pt = new Point3d(RH.Pti.X + num2, RH.Pti.Y - iInicioY, 0.0);
								}
								pt = new Point3d(RH.Pti.X + num2 + num * (double)(num3 - 1), RH.Pti.Y - iInicioY, 0.0);
								CriaTituloDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, text, iL, iT);
								num4 = 1;
							}
							if (Operators.CompareString(text, mPlaquetas[num6].Modelo, TextCompare: true) == 0)
							{
								CriaCorpoDaPlaquetaELN(ref pt, mPlaquetas, num6, iPainel, iL, iT);
								DeclaracoesGeral._uscPagina.pbPasso();
								goto IL_016c;
							}
							int num7 = num4;
							for (int i = num7; i <= iLin; i++)
							{
								CriaCorpoDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, iL, iT);
							}
							text = mPlaquetas[num6].Modelo;
							num4 = iLin + 1;
						}
						break;
					}
					CriaTituloDaPlaquetaELN(ref pt, mPlaquetas, num6, iPainel, mPlaquetas[1].Modelo, iL, iT);
					text = mPlaquetas[1].Modelo;
					goto IL_016c;
					IL_016c:
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					num4++;
				}
				while (true)
				{
					int num8 = num4;
					for (int j = num8; j <= iLin; j++)
					{
						CriaCorpoDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, iL, iT);
					}
					if (num3 >= iCol)
					{
						break;
					}
					num3++;
					pt = new Point3d(RH.Pti.X + num2 + num * (double)(num3 - 1), RH.Pti.Y - iInicioY, 0.0);
					CriaTituloDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, text, iL, iT);
					num4 = 1;
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
			if (Operators.CompareString(pag, "", TextCompare: true) != 0 && Operators.CompareString(pag, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
			{
				Pagina.AtivaPagina(pag);
				DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			}
		}
	}

	public static void CriaMatrizPlaquetasCTEEP(DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, int iPainel, int iL, int iT, int iLin, int iCol, double iInicioY, bool bAdicionaVazias = true)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0421: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		ApagaRelatorioDeplaquetasELN(iPainel);
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double num = 0.0;
		string pag = DeclaracoesGeral.ativo.Pagina;
		double num2 = 0.0;
		num = 90.0;
		num2 = ((Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - num * (double)iCol) / 2.0;
		Point3d pt = new Point3d(RH.Pti.X + num2, RH.Pti.Y - iInicioY, 0.0);
		checked
		{
			try
			{
				int num3 = 1;
				Dicionario.CriaTableStyleRelatorios("romans", 0.5);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mPlaquetas);
				DeclaracoesGeral._uscPagina.pbIniciar();
				int num4 = 0;
				string text = "";
				int num5 = Information.UBound(mPlaquetas);
				frmRelatorio_PlaquetasDWG.ConfigRelatorioPlaquetas configRelatorioPlaquetas = default;
				for (int num6 = 0; num6 <= num5; num6++)
				{
					if (num3 >= iCol && num4 > iLin)
					{
						string right = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
						if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, right, TextCompare: true) == 0)
						{
							Pagina.criarUmaNovaPagina();
							DeclaracoesGeral._uscPagina.CarregaPG();
							Pagina.AtivaPagina(DeclaracoesGeral.ativo.Pagina);
							Pagina.OrdenaMatrizPaginas();
							string pag2 = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (DeclaracoesGeral.bPararRelatorio)
							{
								goto IL_016c;
							}
							Pagina.AtivaPagina(pag2);
							DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag2);
							pt = new Point3d(RH.Pti.X + configRelatorioPlaquetas.DistEntreColunas, RH.Pti.Y - configRelatorioPlaquetas.AlturaInicial, 0.0);
							num3 = 0;
						}
					}
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					if (num6 == 0)
					{
						mPlaquetas[0].Desc1 = "##B##";
						mPlaquetas[0].Desc2 = "##B##";
						mPlaquetas[0].Desc3 = "##B##";
					}
					if (num6 != 0)
					{
						while (true)
						{
							if (num4 >= iLin + 1)
							{
								if (num3 != iCol)
								{
									num3++;
								}
								else if (flag)
								{
									if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina)), TextCompare: true) == 0)
									{
										if (!Pagina.criarUmaNovaPagina())
										{
											break;
										}
										DeclaracoesGeral._uscPagina.CarregaPG();
									}
									Pagina.OrdenaMatrizPaginas();
									string pag3 = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
									if (DeclaracoesGeral.bPararRelatorio)
									{
										goto IL_016c;
									}
									Pagina.AtivaPagina(pag3);
									DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag3);
									pt = new Point3d(RH.Pti.X + configRelatorioPlaquetas.DistEntreColunas, RH.Pti.Y - configRelatorioPlaquetas.AlturaInicial, 0.0);
									num3 = 1;
								}
								else
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
									pt = new Point3d(RH.Pti.X + num2, RH.Pti.Y - iInicioY, 0.0);
								}
								pt = new Point3d(RH.Pti.X + num2 + num * (double)(num3 - 1), RH.Pti.Y - iInicioY, 0.0);
								text = mPlaquetas[num6].Modelo;
								CriaTituloDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, text, iL, iT);
								num4 = 1;
							}
							if (Operators.CompareString(text, mPlaquetas[num6].Modelo, TextCompare: true) == 0)
							{
								CriaCorpoDaPlaquetaELN(ref pt, mPlaquetas, num6, iPainel, iL, iT);
							}
							else if (!(!bAdicionaVazias & (num4 == 1)))
							{
								int num7 = num4;
								for (int i = num7; i <= iLin; i++)
								{
									CriaCorpoDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, iL, iT);
								}
								text = mPlaquetas[num6].Modelo;
								num4 = iLin + 1;
								continue;
							}
							DeclaracoesGeral._uscPagina.pbPasso();
							goto IL_016c;
						}
						break;
					}
					CriaTituloDaPlaquetaELN(ref pt, mPlaquetas, num6, iPainel, mPlaquetas[1].Modelo, iL, iT);
					text = mPlaquetas[1].Modelo;
					goto IL_016c;
					IL_016c:
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					num4++;
				}
				while (true)
				{
					int num8 = num4;
					for (int j = num8; j <= iLin; j++)
					{
						CriaCorpoDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, iL, iT);
					}
					if (num3 >= iCol)
					{
						break;
					}
					num3++;
					pt = new Point3d(RH.Pti.X + num2 + num * (double)(num3 - 1), RH.Pti.Y - iInicioY, 0.0);
					CriaTituloDaPlaquetaELN(ref pt, mPlaquetas, 0, iPainel, text, iL, iT);
					num4 = 1;
				}
				DeclaracoesGeral._uscPagina.pbFim();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
			if (Operators.CompareString(pag, "", TextCompare: true) != 0 && Operators.CompareString(pag, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
			{
				Pagina.AtivaPagina(pag);
				DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			}
		}
	}

	public static void CriaTituloDaPlaquetaELN(ref Point3d pt, DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, int iIndice, int iPainel, string sTamanho, int iL, int iT)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected Obj, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected Obj, but got Unknown
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected Obj, but got Unknown
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0418: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c2: Expected Obj, but got Unknown
		//IL_05cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Unknown result type (might be due to invalid IL or missing references)
		//IL_0607: Expected Obj, but got Unknown
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				_ = ((SymbolTable)val3)["romans"];
				new DBObjectCollection();
				BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				double num = 0.0;
				double num2 = 0.0;
				Table val6 = new Table();
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				val6.SetSize(2, 1);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = 10.0;
				val6.SetRowHeight(5.0);
				((CellRange)val6.Cells[0, 0]).TextHeight = 2.0;
				((CellRange)val6.Cells[1, 0]).TextHeight = 2.0;
				val6.Cells[0, 0].TextString = "POS";
				((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
				val6.Cells[1, 0].TextString = "QT.";
				((CellRange)val6.Cells[1, 0]).Alignment = (CellAlignment)5;
				((Entity)val6).ColorIndex = iL;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d val7 = value.MinPoint;
				num2 = val7.Y;
				value = ((Drawable)val6).Bounds.Value;
				val7 = value.MinPoint;
				num = val7.X;
				Application.UpdateScreen();
				DBObjectCollection val8 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val8);
				((DBObject)val6).Erase();
				foreach (Entity item in val8)
				{
					Entity Ent = item;
					MText val9 = (MText)(object)((Ent is MText) ? Ent : null);
					try
					{
						if (val9 != null && Operators.CompareString(val9.Text, "##B##", TextCompare: true) != 0)
						{
							((Entity)val9).ColorIndex = iT;
							((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val9);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
							Entity Ent2 = (Entity)(object)val9;
							XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val9)?.Dispose();
					}
					Line val10 = (Line)(object)((Ent is Line) ? Ent : null);
					try
					{
						if (val10 != null)
						{
							Ent.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
							XDataRelatorio.GravarXDataPlaquetas(ref Ent, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val10)?.Dispose();
					}
					((DisposableWrapper)Ent).Dispose();
				}
				Table val11 = new Table();
				((Entity)val11).Layer = DeclaracoesGeral.ativo.Pagina;
				val11.SetSize(1, 2);
				val11.GenerateLayout();
				val11.RecomputeTableBlock(true);
				value = ((Drawable)val6).Bounds.Value;
				val7 = value.MaxPoint;
				double x = val7.X;
				value = ((Drawable)val6).Bounds.Value;
				val7 = value.MaxPoint;
				pt = new Point3d(x, val7.Y, 0.0);
				((BlockReference)val11).Position = pt;
				val11.Columns[0].Width = 40.0;
				val11.Columns[1].Width = 40.0;
				val11.SetRowHeight(10.0);
				((CellRange)val11.Cells[0, 0]).TextHeight = 2.5;
				((CellRange)val11.Cells[0, 1]).TextHeight = 2.5;
				val11.Cells[0, 0].TextString = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1354]);
				((CellRange)val11.Cells[0, 0]).Alignment = (CellAlignment)5;
				if (Operators.CompareString(sTamanho, "##B##", TextCompare: true) == 0)
				{
					sTamanho = "";
				}
				val11.Cells[0, 1].TextString = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DeclaracoesGeral.mMensagem[1, 1355], " "), sTamanho));
				((CellRange)val11.Cells[0, 1]).Alignment = (CellAlignment)5;
				((Entity)val11).ColorIndex = iL;
				DeclaracoesGeral.bAnularEventos = true;
				val11.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val11.GenerateLayout();
				val5.AppendEntity((Entity)(object)val11);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
				val11.RecomputeTableBlock(true);
				DBObjectCollection val12 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val11.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val11).Explode(val12);
				((DBObject)val11).Erase();
				foreach (Entity item2 in val12)
				{
					Entity Ent3 = item2;
					MText val13 = (MText)(object)((Ent3 is MText) ? Ent3 : null);
					try
					{
						if (val13 != null && Operators.CompareString(val13.Text, "##B##", TextCompare: true) != 0)
						{
							((Entity)val13).ColorIndex = iT;
							((Entity)val13).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val13);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
							Entity Ent2 = (Entity)(object)val13;
							XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val13)?.Dispose();
					}
					Line val14 = (Line)(object)((Ent3 is Line) ? Ent3 : null);
					try
					{
						if (val14 != null)
						{
							Ent3.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent3);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent3, true);
							XDataRelatorio.GravarXDataPlaquetas(ref Ent3, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val14)?.Dispose();
					}
					((DisposableWrapper)Ent3).Dispose();
				}
				pt = new Point3d(num, num2, 0.0);
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

	public static void CriaCorpoDaPlaquetaELN(ref Point3d pt, DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, int iIndice, int iPainel, int iL, int iT)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0200: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected Obj, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Expected Obj, but got Unknown
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Expected Obj, but got Unknown
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Expected Obj, but got Unknown
		//IL_0494: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected Obj, but got Unknown
		//IL_0337: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Expected Obj, but got Unknown
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0802: Unknown result type (might be due to invalid IL or missing references)
		//IL_0809: Expected Obj, but got Unknown
		//IL_0812: Unknown result type (might be due to invalid IL or missing references)
		//IL_0847: Unknown result type (might be due to invalid IL or missing references)
		//IL_084e: Expected Obj, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090c: Expected Obj, but got Unknown
		//IL_0937: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a79: Expected Obj, but got Unknown
		//IL_0a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abe: Expected Obj, but got Unknown
		//IL_0b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6f: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
				_ = ((SymbolTable)val3)["romans"];
				new DBObjectCollection();
				BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
				BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
				string sIndice = "";
				Table val6 = new Table();
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				val6.SetSize(1, 1);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = 10.0;
				val6.SetRowHeight(25.0);
				((CellRange)val6.Cells[0, 0]).TextHeight = 2.0;
				val6.Cells[0, 0].TextString = "##B##";
				if (iIndice != 0)
				{
					val6.Cells[0, 0].TextString = "E" + Conversions.ToString(iIndice);
					sIndice = "E" + Conversions.ToString(iIndice);
				}
				((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
				((Entity)val6).ColorIndex = iL;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d val7 = value.MaxPoint;
				double x = val7.X;
				value = ((Drawable)val6).Bounds.Value;
				val7 = value.MaxPoint;
				Point3d position = new Point3d(x, val7.Y, 0.0);
				value = ((Drawable)val6).Bounds.Value;
				val7 = value.MinPoint;
				double x2 = val7.X;
				value = ((Drawable)val6).Bounds.Value;
				val7 = value.MinPoint;
				Point3d position2 = new Point3d(x2, val7.Y, 0.0);
				DBObjectCollection val8 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val8);
				((DBObject)val6).Erase();
				foreach (Entity item in val8)
				{
					Entity Ent = item;
					MText val9 = (MText)(object)((Ent is MText) ? Ent : null);
					try
					{
						if (val9 != null && Operators.CompareString(val9.Text, "##B##", TextCompare: true) != 0)
						{
							((Entity)val9).ColorIndex = iT;
							((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val9);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
							Entity Ent2 = (Entity)(object)val9;
							XDataRelatorio.GravarXDataPlaquetas(ref Ent2, sIndice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val9)?.Dispose();
					}
					Line val10 = (Line)(object)((Ent is Line) ? Ent : null);
					try
					{
						if (val10 != null)
						{
							Ent.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
							XDataRelatorio.GravarXDataPlaquetas(ref Ent, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val10)?.Dispose();
					}
					((DisposableWrapper)Ent).Dispose();
				}
				Table val11 = new Table();
				((Entity)val11).Layer = DeclaracoesGeral.ativo.Pagina;
				val11.SetSize(1, 1);
				val11.GenerateLayout();
				val11.RecomputeTableBlock(true);
				((BlockReference)val11).Position = position;
				val11.Columns[0].Width = 80.0;
				val11.SetRowHeight(35.0);
				val11.Cells[0, 0].TextString = "##B##";
				((CellRange)val11.Cells[0, 0]).Alignment = (CellAlignment)5;
				((Entity)val11).ColorIndex = iL;
				DeclaracoesGeral.bAnularEventos = true;
				val11.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val11.GenerateLayout();
				val5.AppendEntity((Entity)(object)val11);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
				val11.RecomputeTableBlock(true);
				DBObjectCollection val12 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val11.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val11).Explode(val12);
				((DBObject)val11).Erase();
				foreach (Entity item2 in val12)
				{
					Entity Ent3 = item2;
					Line val13 = (Line)(object)((Ent3 is Line) ? Ent3 : null);
					if (val13 != null)
					{
						Ent3.Layer = DeclaracoesGeral.ativo.Pagina;
						val5.AppendEntity(Ent3);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)Ent3, true);
						XDataRelatorio.GravarXDataPlaquetas(ref Ent3, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
					}
					((DisposableWrapper)Ent3).Dispose();
				}
				Table val14 = new Table();
				((Entity)val14).Layer = DeclaracoesGeral.ativo.Pagina;
				val14.SetSize(5, 1);
				val14.GenerateLayout();
				val14.RecomputeTableBlock(true);
				val14.SetRowHeight(7.0);
				((BlockReference)val14).Position = position;
				val14.Columns[0].Width = 80.0;
				((CellRange)val14.Cells[0, 0]).TextHeight = 3.0;
				((CellRange)val14.Cells[1, 0]).TextHeight = 3.0;
				((CellRange)val14.Cells[2, 0]).TextHeight = 3.0;
				((CellRange)val14.Cells[3, 0]).TextHeight = 3.0;
				((CellRange)val14.Cells[4, 0]).TextHeight = 3.0;
				if (Operators.CompareString(mPlaquetas[iIndice].Desc1.ToString().Trim(), "", TextCompare: true) == 0)
				{
					mPlaquetas[iIndice].Desc1 = "##B##";
				}
				if (Operators.CompareString(mPlaquetas[iIndice].Desc2.ToString().Trim(), "", TextCompare: true) == 0)
				{
					mPlaquetas[iIndice].Desc2 = "##B##";
				}
				if (Operators.CompareString(mPlaquetas[iIndice].Desc3.ToString().Trim(), "", TextCompare: true) == 0)
				{
					mPlaquetas[iIndice].Desc3 = "##B##";
				}
				if (iIndice != 0)
				{
					val14.Cells[0, 0].TextString = "##B##";
					val14.Cells[1, 0].TextString = mPlaquetas[iIndice].Desc1;
					val14.Cells[2, 0].TextString = mPlaquetas[iIndice].Desc2;
					val14.Cells[3, 0].TextString = mPlaquetas[iIndice].Desc3;
					val14.Cells[4, 0].TextString = "##B##";
				}
				else
				{
					val14.Cells[0, 0].TextString = "##B##";
					val14.Cells[1, 0].TextString = "##B##";
					val14.Cells[2, 0].TextString = "##B##";
					val14.Cells[3, 0].TextString = "##B##";
					val14.Cells[4, 0].TextString = "##B##";
				}
				((CellRange)val14.Cells[1, 0]).Alignment = (CellAlignment)5;
				((CellRange)val14.Cells[2, 0]).Alignment = (CellAlignment)5;
				((CellRange)val14.Cells[3, 0]).Alignment = (CellAlignment)5;
				((Entity)val14).ColorIndex = iL;
				DeclaracoesGeral.bAnularEventos = true;
				val14.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val14.GenerateLayout();
				val5.AppendEntity((Entity)(object)val14);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val14, true);
				val14.RecomputeTableBlock(true);
				DBObjectCollection val15 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val14.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val14).Explode(val15);
				((DBObject)val14).Erase();
				foreach (Entity item3 in val15)
				{
					Entity val16 = item3;
					MText val17 = (MText)(object)((val16 is MText) ? val16 : null);
					try
					{
						if (val17 != null && Operators.CompareString(val17.Text, "##B##", TextCompare: true) != 0)
						{
							((Entity)val17).ColorIndex = iT;
							((Entity)val17).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val17);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val17, true);
							Entity Ent2 = (Entity)(object)val17;
							XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val17)?.Dispose();
					}
					((DisposableWrapper)val16).Dispose();
				}
				Table val18 = new Table();
				((Entity)val18).Layer = DeclaracoesGeral.ativo.Pagina;
				val18.SetSize(1, 1);
				val18.GenerateLayout();
				val18.RecomputeTableBlock(true);
				((BlockReference)val18).Position = position2;
				val18.Columns[0].Width = 10.0;
				val18.SetRowHeight(10.0);
				((CellRange)val18.Cells[0, 0]).TextHeight = 2.0;
				if (iIndice != 0)
				{
					val18.Cells[0, 0].TextString = mPlaquetas[iIndice].Quant.ToString();
				}
				else
				{
					val18.Cells[0, 0].TextString = "##B##";
				}
				((CellRange)val18.Cells[0, 0]).Alignment = (CellAlignment)5;
				((Entity)val18).ColorIndex = iL;
				DeclaracoesGeral.bAnularEventos = true;
				val18.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val18.GenerateLayout();
				val5.AppendEntity((Entity)(object)val18);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val18, true);
				val18.RecomputeTableBlock(true);
				value = ((Drawable)val18).Bounds.Value;
				val7 = value.MinPoint;
				double x3 = val7.X;
				value = ((Drawable)val18).Bounds.Value;
				val7 = value.MinPoint;
				pt = new Point3d(x3, val7.Y, 0.0);
				DBObjectCollection val19 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val18.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val18).Explode(val19);
				((DBObject)val18).Erase();
				foreach (Entity item4 in val19)
				{
					Entity Ent4 = item4;
					MText val20 = (MText)(object)((Ent4 is MText) ? Ent4 : null);
					try
					{
						if (val20 != null && Operators.CompareString(val20.Text, "##B##", TextCompare: true) != 0)
						{
							((Entity)val20).ColorIndex = iT;
							((Entity)val20).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val20);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val20, true);
							Entity Ent2 = (Entity)(object)val20;
							XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val20)?.Dispose();
					}
					Line val21 = (Line)(object)((Ent4 is Line) ? Ent4 : null);
					try
					{
						if (val21 != null)
						{
							Ent4.Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity(Ent4);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)Ent4, true);
							XDataRelatorio.GravarXDataPlaquetas(ref Ent4, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
					}
					finally
					{
						((IDisposable)val21)?.Dispose();
					}
					((DisposableWrapper)Ent4).Dispose();
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

	public static void ApagaRelatorioDeplaquetasELN(int iPainel)
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
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
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
						string sDisp = "";
						int iPN = 0;
						string sEti = "";
						if (XDataRelatorio.LerXDataPlaquetas(ref Ent, ref sEti, ref sDisp, ref iPN) && iPainel == iPN)
						{
							((DBObject)Ent).UpgradeOpen();
							((DBObject)Ent).Erase();
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
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}
}

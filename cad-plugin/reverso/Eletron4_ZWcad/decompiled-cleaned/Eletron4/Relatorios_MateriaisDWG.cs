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

public class Relatorios_MateriaisDWG
{
	public static void CriaRelMateriaisDWG1PN(cDadosLM.structureLMRelelatorio[] mMateriais, frmRelatorio_MateriaisDWG.ConfRelelatorio ConfRelMateriais, ref int iPainel, double cl1, double cl2, double cl3, double cl4, double cl5, double cl6, double cl7)
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double dX = 0.0;
		double dY = 0.0;
		double YInicio = 0.0;
		double num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num -= ConfRelMateriais.DistEntreColunas * (double)(ConfRelMateriais.QuantColunas + 1);
			num /= (double)ConfRelMateriais.QuantColunas;
			double num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - dX - (double)ConfRelMateriais.QuantColunas * num;
			num2 /= (double)(ConfRelMateriais.QuantColunas + 1);
			Point3d pt = new Point3d(RH.Pti.X + ConfRelMateriais.DistEntreColunas, RH.Pti.Y - ConfRelMateriais.AlturaInicial, 0.0);
			try
			{
				Dicionario.CriaTableStyleRelatorios(ConfRelMateriais.sFonte);
				int num3 = 1;
				DeclaracoesGeral._uscPagina.pbIniciar();
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mMateriais);
				bool bTituloTag = false;
				CriaTabelaMateriais1PN(num, pt, mMateriais, 0, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel, cl1, cl2, cl3, cl4, cl5, cl6, cl7);
				int num4 = Information.UBound(mMateriais);
				for (int i = 1; i <= num4; i++)
				{
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					pt = new Point3d(pt.X, dY, 0.0);
					CriaTabelaMateriais1PN(num, pt, mMateriais, i, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel, cl1, cl2, cl3, cl4, cl5, cl6, cl7);
					if (dY < RH.AltBase)
					{
						int num5 = 0;
						num5 = ApagaUmIndiceDoRelatorioMateriais1PN(i, ref iPainel);
						if (num3 != ConfRelMateriais.QuantColunas)
						{
							pt = new Point3d(dX + ConfRelMateriais.DistEntreColunas + num, RH.Pti.Y - ConfRelMateriais.AlturaInicial, 0.0);
							num3++;
						}
						else if (flag)
						{
							Pagina.OrdenaMatrizPaginas();
							string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
							{
								Pagina.AtivaPagina(pag);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
							}
							else if (i <= Information.UBound(mMateriais))
							{
								if (!Pagina.criarUmaNovaPagina())
								{
									break;
								}
								DeclaracoesGeral._uscPagina.CarregaPG();
							}
							pt = new Point3d(RH.Pti.X + ConfRelMateriais.DistEntreColunas, RH.Pti.Y - ConfRelMateriais.AlturaInicial, 0.0);
							num3 = 1;
						}
						else
						{
							if (!Pagina.criarUmaNovaPagina())
							{
								break;
							}
							DeclaracoesGeral._uscPagina.CarregaPG();
							pt = new Point3d(RH.Pti.X + ConfRelMateriais.DistEntreColunas, RH.Pti.Y - ConfRelMateriais.AlturaInicial, 0.0);
						}
						if (num5 != 0)
						{
							bTituloTag = false;
							CriaTabelaMateriais1PN(num, pt, mMateriais, 0, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel, cl1, cl2, cl3, cl4, cl5, cl6, cl7);
							pt = new Point3d(pt.X, dY, 0.0);
							CriaTabelaMateriais1PN(num, pt, mMateriais, num5, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel, cl1, cl2, cl3, cl4, cl5, cl6, cl7);
							pt = new Point3d(pt.X, dY, 0.0);
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
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

	public static void CriaTabelaMateriais1PN(double dLarguraDoBloco, Point3d pt, cDadosLM.structureLMRelelatorio[] mMateriais, int iIndice, ref double dY, ref double dX, ref double YInicio, frmRelatorio_MateriaisDWG.ConfRelelatorio ConfRelFiacao, ref bool bTituloTag, ref int iPainel, double cl1, double cl2, double cl3, double cl4, double cl5, double cl6, double cl7)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected Obj, but got Unknown
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected Obj, but got Unknown
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0719: Unknown result type (might be due to invalid IL or missing references)
		//IL_071e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_0727: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				bool flag = false;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					_ = ((SymbolTable)val3)[ConfRelFiacao.sFonte];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					int num = 4;
					int num2 = 0;
					int num3 = 0;
					int num4 = 0;
					if (!ConfRelFiacao.bConcatModelo)
					{
						num2 = num;
						num++;
					}
					if (!ConfRelFiacao.bConcatFabricante)
					{
						num3 = num;
						num++;
					}
					if (ConfRelFiacao.bVisivelCli)
					{
						num4 = num;
						num++;
					}
					val6.SetSize(1, num);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					((Entity)val6).ColorIndex = ConfRelFiacao.CorLinha;
					Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
					val6.Columns[0].Width = cl1;
					val6.Columns[1].Width = cl2;
					val6.Columns[2].Width = cl3;
					double num5 = 0.43;
					if (ConfRelFiacao.bConcatModelo)
					{
						num5 += 0.09;
					}
					if (ConfRelFiacao.bConcatFabricante)
					{
						num5 += 0.09;
					}
					if (!ConfRelFiacao.bVisivelCli)
					{
						num5 += 0.09;
					}
					val6.Columns[3].Width = cl4;
					if (!ConfRelFiacao.bConcatModelo)
					{
						val6.Columns[num2].Width = cl5;
					}
					if (!ConfRelFiacao.bConcatFabricante)
					{
						val6.Columns[num3].Width = cl6;
					}
					if (ConfRelFiacao.bVisivelCli)
					{
						val6.Columns[num4].Width = cl7;
					}
					val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
					if (iIndice != 0)
					{
						if (Information.IsNothing(mMateriais[iIndice].Desc))
						{
							mMateriais[iIndice].Desc = Conversions.ToString(0);
						}
						if (Operators.CompareString(mMateriais[iIndice].Desc.ToString().Trim(), "", TextCompare: true) == 0)
						{
							mMateriais[iIndice].Desc = "##B##";
						}
						if (Information.IsNothing(mMateriais[iIndice].sModelo))
						{
							mMateriais[iIndice].sModelo = "";
						}
						if (Operators.CompareString(mMateriais[iIndice].sModelo.ToString().Trim(), "", TextCompare: true) == 0)
						{
							mMateriais[iIndice].sModelo = "##B##";
						}
						if (Information.IsNothing(mMateriais[iIndice].sFabricante))
						{
							mMateriais[iIndice].sFabricante = "";
						}
						if (Operators.CompareString(mMateriais[iIndice].sFabricante.ToString().Trim(), "", TextCompare: true) == 0)
						{
							mMateriais[iIndice].sFabricante = "##B##";
						}
						if (Information.IsNothing(mMateriais[iIndice].CodCli))
						{
							mMateriais[iIndice].CodCli = "";
						}
						if (Operators.CompareString(mMateriais[iIndice].CodCli.ToString().Trim(), "", TextCompare: true) == 0)
						{
							mMateriais[iIndice].CodCli = "##B##";
						}
						((CellRange)val6.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
						val6.Cells[0, 0].TextString = iIndice.ToString();
						((CellRange)val6.Cells[0, 1]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 1]).Alignment = (CellAlignment)5;
						val6.Cells[0, 1].TextString = mMateriais[iIndice].Quantidade.ToString();
						((CellRange)val6.Cells[0, 2]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 2]).Alignment = (CellAlignment)4;
						val6.Cells[0, 2].TextString = mMateriais[iIndice].Tag.ToString();
						((CellRange)val6.Cells[0, 3]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 3]).Alignment = (CellAlignment)4;
						val6.Cells[0, 3].TextString = mMateriais[iIndice].Desc.ToString();
						if (!ConfRelFiacao.bConcatModelo)
						{
							((CellRange)val6.Cells[0, num2]).TextHeight = ConfRelFiacao.TamanhoFonte;
							((CellRange)val6.Cells[0, num2]).Alignment = (CellAlignment)5;
							val6.Cells[0, num2].TextString = mMateriais[iIndice].sModelo.ToString();
						}
						if (!ConfRelFiacao.bConcatFabricante)
						{
							((CellRange)val6.Cells[0, num3]).TextHeight = ConfRelFiacao.TamanhoFonte;
							((CellRange)val6.Cells[0, num3]).Alignment = (CellAlignment)5;
							val6.Cells[0, num3].TextString = mMateriais[iIndice].sFabricante.ToString();
						}
						if (ConfRelFiacao.bVisivelCli)
						{
							((CellRange)val6.Cells[0, num4]).TextHeight = ConfRelFiacao.TamanhoFonte;
							((CellRange)val6.Cells[0, num4]).Alignment = (CellAlignment)5;
							val6.Cells[0, num4].TextString = mMateriais[iIndice].CodCli.ToString();
						}
					}
					else
					{
						((CellRange)val6.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
						val6.Cells[0, 0].TextString = mMateriais[0].Index;
						((CellRange)val6.Cells[0, 1]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 1]).Alignment = (CellAlignment)5;
						val6.Cells[0, 1].TextString = mMateriais[0].Quantidade;
						((CellRange)val6.Cells[0, 2]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 2]).Alignment = (CellAlignment)4;
						val6.Cells[0, 2].TextString = mMateriais[0].Tag;
						((CellRange)val6.Cells[0, 3]).TextHeight = ConfRelFiacao.TamanhoFonte;
						((CellRange)val6.Cells[0, 3]).Alignment = (CellAlignment)4;
						val6.Cells[0, 3].TextString = mMateriais[0].Desc;
						if (!ConfRelFiacao.bConcatModelo)
						{
							((CellRange)val6.Cells[0, num2]).TextHeight = ConfRelFiacao.TamanhoFonte;
							((CellRange)val6.Cells[0, num2]).Alignment = (CellAlignment)5;
							val6.Cells[0, num2].TextString = mMateriais[0].sModelo;
						}
						if (!ConfRelFiacao.bConcatFabricante)
						{
							((CellRange)val6.Cells[0, num3]).TextHeight = ConfRelFiacao.TamanhoFonte;
							((CellRange)val6.Cells[0, num3]).Alignment = (CellAlignment)5;
							val6.Cells[0, num3].TextString = mMateriais[0].sFabricante;
						}
						if (ConfRelFiacao.bVisivelCli)
						{
							((CellRange)val6.Cells[0, num4]).TextHeight = ConfRelFiacao.TamanhoFonte;
							((CellRange)val6.Cells[0, num4]).Alignment = (CellAlignment)5;
							val6.Cells[0, num4].TextString = mMateriais[0].CodCli;
						}
					}
					val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
					((BlockReference)val6).Position = position;
					dY = 0.0;
					dX = 0.0;
					((Entity)val6).ColorIndex = ConfRelFiacao.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					((DBObject)val6).UpgradeOpen();
					val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d val8 = value.MinPoint;
					dY = val8.Y;
					value = ((Drawable)val6).Bounds.Value;
					val8 = value.MinPoint;
					dX = val8.X;
					dY = 1000000.0;
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
								((Entity)val10).ColorIndex = ConfRelFiacao.CorTexto;
								((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
								if (Operators.CompareString(val10.Text, "##B##", TextCompare: true) != 0)
								{
									val5.AppendEntity((Entity)(object)val10);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
									if (!(!flag & (iIndice != 0)))
									{
										Entity Ent2 = (Entity)(object)val10;
										XDataRelatorio.GravarXDataMateriais(ref Ent2, iIndice, iPainel);
									}
									else
									{
										string tag = mMateriais[iIndice].Tag;
										tag = tag.Replace(",", ";");
										Entity Ent2 = (Entity)(object)val10;
										XDataRelatorio.GravarXDataMateriais(ref Ent2, iIndice, iPainel, mMateriais[iIndice].Tag);
										flag = true;
									}
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
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
								XDataRelatorio.GravarXDataMateriais(ref Ent, iIndice, iPainel);
								value = ((Drawable)val11).Bounds.Value;
								val8 = value.MaxPoint;
								if (val8.Y < dY)
								{
									value = ((Drawable)val11).Bounds.Value;
									val8 = value.MaxPoint;
									dY = val8.Y;
								}
							}
						}
						finally
						{
							((IDisposable)val11)?.Dispose();
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

	public static int ApagaUmIndiceDoRelatorioMateriais1PN(int iIndice, ref int iPainel)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		int result = 0;
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
						int iIndice2 = 0;
						if (Operators.CompareString(Ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0 && XDataRelatorio.LerXDataMateriais(ref Ent, ref iIndice2, ref iPainel) && iIndice2 == iIndice)
						{
							((DBObject)Ent).UpgradeOpen();
							((DBObject)Ent).Erase();
							result = iIndice;
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
		return result;
	}

	public static int BuscaMaiorIndiceRelatorioMateriais(ref int iPainel)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		int num = 0;
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
						int iIndice = 0;
						if (XDataRelatorio.LerXDataMateriais(ref Ent, ref iIndice, ref iPainel) && iIndice > num)
						{
							num = iIndice;
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
		return num;
	}

	public static void ApagaTodoRelatorioMateriais()
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
		string pag = "";
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
						int iIndice = 0;
						int iPN = 0;
						string[] sDisps = null;
						if (XDataRelatorio.LerDispsXDataMateriaisM(ref Ent, ref iIndice, ref iPN, ref sDisps))
						{
							if (Operators.CompareString(pag, "", TextCompare: true) == 0)
							{
								pag = Ent.Layer;
							}
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
		if (Operators.CompareString(pag, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
		{
			Pagina.AtivaPagina(pag);
			DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
		}
	}

	public static void ApagaRelatorioMateriaisPainel(ref int iPN)
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
		string pag = "";
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
						int iIndice = 0;
						if (XDataRelatorio.LerXDataMateriais(ref Ent, ref iIndice, ref iPN) | (iPN == -1))
						{
							if (Operators.CompareString(pag, "", TextCompare: true) == 0)
							{
								pag = Ent.Layer;
							}
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
		if (Operators.CompareString(pag, "", TextCompare: true) != 0)
		{
			Pagina.AtivaPagina(pag);
			DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
		}
	}

	public static int ApagaUmIndiceDoRelatorioMateriais(int iIndice, ref int iPainel)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		int result = 0;
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
						int iIndice2 = 0;
						if (Operators.CompareString(Ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) == 0 && XDataRelatorio.LerXDataMateriais(ref Ent, ref iIndice2, ref iPainel) && iIndice2 == checked(iIndice + 1))
						{
							((DBObject)Ent).UpgradeOpen();
							((DBObject)Ent).Erase();
							result = iIndice;
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
		return result;
	}
}

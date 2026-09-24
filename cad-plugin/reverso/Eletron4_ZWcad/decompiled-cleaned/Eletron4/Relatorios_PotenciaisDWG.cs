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

public class Relatorios_PotenciaisDWG
{
	public static void CriaMatrizDePotenciaisDWG(DeclaracoesFiacao.structureRelPotencial[] mPotencial, frmRelatorio_PotenciaisDWG.ConfRelelatorio ConfRelFiacao, string sTipoRelatorio, int iPainel)
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double dX = 0.0;
		double dY = 0.0;
		double YInicio = 0.0;
		double num = 0.0;
		num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num -= ConfRelFiacao.DistEntreColunas * (double)(ConfRelFiacao.QuantColunas + 1);
			num /= (double)ConfRelFiacao.QuantColunas;
			double num2 = 0.0;
			num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - dX - (double)ConfRelFiacao.QuantColunas * num;
			num2 /= (double)(ConfRelFiacao.QuantColunas + 1);
			Point3d pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
			try
			{
				Dicionario.CriaTableStyleRelatorios(ConfRelFiacao.sFonte);
				int num3 = 1;
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mPotencial);
				DeclaracoesGeral._uscPagina.pbIniciar();
				bool bTituloTag = false;
				int num4 = mPotencial[1].potencial;
				CriaTabelaPotencial(sTipoRelatorio, num, pt, mPotencial, 0, ref dY, ref dX, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
				int num5 = Information.UBound(mPotencial);
				int num6 = 1;
				while (num6 <= num5 && !DeclaracoesGeral.bPararRelatorio)
				{
					if (mPotencial[num6].potencial != num4)
					{
						num4 = mPotencial[num6].potencial;
						bTituloTag = true;
						dY -= ConfRelFiacao.AlturaDoBloco / 3.0;
					}
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					pt = new Point3d(pt.X, dY, 0.0);
					CriaTabelaPotencial(sTipoRelatorio, num, pt, mPotencial, num6, ref dY, ref dX, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
					if (dY < RH.AltBase + 1.0 + ConfRelFiacao.AlturaDoBloco * 1.5)
					{
						if (num3 != ConfRelFiacao.QuantColunas)
						{
							pt = new Point3d(dX + ConfRelFiacao.DistEntreColunas + num, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
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
									goto IL_0212;
								}
								Pagina.AtivaPagina(pag);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
							}
							else
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_0212;
								}
								if (num6 < Information.UBound(mPotencial))
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
								}
							}
							pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
							num3 = 1;
						}
						else
						{
							if (!Pagina.criarUmaNovaPagina())
							{
								break;
							}
							DeclaracoesGeral._uscPagina.CarregaPG();
							pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
						}
						if (num6 < Information.UBound(mPotencial) - 1)
						{
							bTituloTag = false;
							CriaTabelaPotencial(sTipoRelatorio, num, pt, mPotencial, 0, ref dY, ref dX, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
							num4 = 0;
							pt = new Point3d(pt.X, dY, 0.0);
							num4 = 0;
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					goto IL_0212;
					IL_0212:
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					num6++;
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

	public static void CriaTabelaPotencial(string sTipoRelatorio, double dLarguraDoBloco, Point3d pt, DeclaracoesFiacao.structureRelPotencial[] mPotencial, int iIndice, ref double dY, ref double dX, ref double YInicio, frmRelatorio_PotenciaisDWG.ConfRelelatorio ConfRelFiacao, int iPainel, ref bool bTituloTag)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Expected Obj, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Expected Obj, but got Unknown
		//IL_0453: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
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
				val6.SetSize(1, 7);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
				val6.Columns[0].Width = dLarguraDoBloco * 0.15;
				val6.Columns[1].Width = dLarguraDoBloco * 0.15;
				val6.Columns[2].Width = dLarguraDoBloco * 0.15;
				val6.Columns[3].Width = dLarguraDoBloco * 0.15;
				val6.Columns[4].Width = dLarguraDoBloco * 0.125;
				val6.Columns[5].Width = dLarguraDoBloco * 0.125;
				val6.Columns[6].Width = dLarguraDoBloco * 0.15;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelFiacao.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 6);
				val6.Cells[0, 0].TextString = mPotencial[iIndice].tag1.ToString();
				val6.Cells[0, 1].TextString = mPotencial[iIndice].term1.ToString();
				val6.Cells[0, 2].TextString = mPotencial[iIndice].tag2.ToString();
				val6.Cells[0, 3].TextString = mPotencial[iIndice].term2.ToString();
				val6.Cells[0, 4].TextString = mPotencial[iIndice].secao.ToString();
				val6.Cells[0, 5].TextString = mPotencial[iIndice].cor.ToString();
				val6.Cells[0, 6].TextString = mPotencial[iIndice].pagina.ToString();
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				((BlockReference)val6).Position = position;
				dY = 100000.0;
				dX = 0.0;
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d val8 = value.MinPoint;
				dX = val8.X;
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
								Entity Ent2 = (Entity)(object)val10;
								XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
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
							XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
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

	public static void ApagaRelatorioPotencial(ref string sTipoRelatotio, int iPainel)
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
						string sRel = "";
						int iPN = 0;
						if (XDataRelatorio.LerXDataFiacao(ref Ent, ref sRel, ref iPN) && ((Operators.CompareString(sTipoRelatotio, sRel, TextCompare: true) == 0) & (iPainel == iPN)))
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

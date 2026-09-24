using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Relatorios_MateriaisMULTI_DWG
{
	public static void CriaRelMateriaisDWG(DataGridView dgRel, ConfRelelatorioMulti ConfRelMateriais, ref int iPainel, int iQuantSelecionados)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double dX = 0.0;
		double dY = 0.0;
		double YInicio = 0.0;
		double num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		double num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - dX - (double)ConfRelMateriais.QuantColunas * num;
		checked
		{
			num2 /= (double)(ConfRelMateriais.QuantColunas + 1);
			Point3d pt = new Point3d(RH.Pti.X, RH.Pti.Y - ConfRelMateriais.AlturaInicial, 0.0);
			try
			{
				Dicionario.CriaTableStyleRelatorios(ConfRelMateriais.sFonte);
				DeclaracoesGeral._uscPagina.pbIniciar();
				DeclaracoesGeral._uscPagina.Quantidade = dgRel.RowCount;
				bool bTituloTag = false;
				CriaTabelaMateriaisDG(dgRel, num, pt, -1, 0, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel);
				int rowCount = dgRel.RowCount;
				for (int i = 0; i <= rowCount; i++)
				{
					int num3 = 0;
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					pt = new Point3d(pt.X, dY, 0.0);
					if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dgRel.Rows[i].Cells[0].Value)) && num3 == 0)
					{
						num3 = Conversions.ToInteger(dgRel.Rows[i].Cells[0].Value);
					}
					CriaTabelaMateriaisDG(dgRel, num, pt, i, num3, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel);
					if (dY < RH.AltBase)
					{
						int num4 = Relatorios_MateriaisDWG.ApagaUmIndiceDoRelatorioMateriais(i, ref iPainel);
						Pagina.OrdenaMatrizPaginas();
						string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
						if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
						{
							Pagina.AtivaPagina(pag);
							DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
						}
						else if (i <= dgRel.RowCount)
						{
							if (!Pagina.criarUmaNovaPagina())
							{
								break;
							}
							DeclaracoesGeral._uscPagina.CarregaPG();
						}
						pt = new Point3d(RH.Pti.X, RH.Pti.Y - ConfRelMateriais.AlturaInicial, 0.0);
						if (num4 != -1)
						{
							bTituloTag = false;
							CriaTabelaMateriaisDG(dgRel, num, pt, -1, 0, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel);
							pt = new Point3d(pt.X, dY, 0.0);
							CriaTabelaMateriaisDG(dgRel, num, pt, num4, num3, ref dY, ref dX, ref YInicio, ConfRelMateriais, ref bTituloTag, ref iPainel);
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

	public static void CriaTabelaMateriaisDG(DataGridView dgRel, double dLarguraDoBloco, Point3d pt, int iIndicee, int index, ref double dY, ref double dX, ref double YInicio, ConfRelelatorioMulti ConfRelFiacao, ref bool bTituloTag, ref int iPainel)
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
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Expected Obj, but got Unknown
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected Obj, but got Unknown
		//IL_04dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected Obj, but got Unknown
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected Obj, but got Unknown
		//IL_0561: Unknown result type (might be due to invalid IL or missing references)
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
					int columnCount = dgRel.ColumnCount;
					string text = "";
					double num = 0.0;
					int num2 = columnCount - 1;
					for (int i = 0; i <= num2; i++)
					{
						double num3 = dgRel.Width;
						num3 = (double)dgRel.Columns[i].Width / num3;
						num3 *= dLarguraDoBloco;
						num += num3;
					}
					double num4 = (dLarguraDoBloco - num) / 2.0;
					val6.SetSize(1, columnCount);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					((Entity)val6).ColorIndex = ConfRelFiacao.CorLinha;
					Point3d position = (((BlockReference)val6).Position = ((iIndicee == -1) ? new Point3d(pt.X + num4, pt.Y - 5.0, 0.0) : new Point3d(pt.X + num4, pt.Y, 0.0)));
					val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
					int num5 = columnCount - 1;
					for (int j = 0; j <= num5; j++)
					{
						double num6 = dgRel.Width;
						num6 = (double)dgRel.Columns[j].Width / num6;
						num6 *= dLarguraDoBloco;
						num6 = Math.Round(num6, 2);
						val6.Columns[j].Width = num6;
						if (iIndicee != -1)
						{
							text = clsTextos.TiraNothing(Conversions.ToString(dgRel.Rows[iIndicee].Cells[j].Value));
						}
						else
						{
							text = clsTextos.TiraNothing(dgRel.Columns[j].HeaderText);
							index = 0;
						}
						if (Operators.CompareString(text.Trim(), "", TextCompare: true) == 0)
						{
							text = "##B##";
						}
						if (iIndicee != -1)
						{
							val6.Cells[0, j].TextString = text;
						}
						else
						{
							val6.Cells[0, j].TextString = text;
						}
						if (iIndicee != -1)
						{
							((CellRange)val6.Cells[0, j]).Alignment = (CellAlignment)5;
							if (j == 2)
							{
								((CellRange)val6.Cells[0, j]).Alignment = (CellAlignment)4;
							}
						}
						else
						{
							((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
						}
						((CellRange)val6.Cells[0, j]).TextHeight = ConfRelFiacao.TamanhoFonte;
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
									if (!(!flag & (iIndicee != -1)))
									{
										DBObjectCollection val11 = new DBObjectCollection();
										DeclaracoesGeral.bAnularEventos = true;
										val6.TableStyle = database.Tablestyle;
										DeclaracoesGeral.bAnularEventos = false;
										((Entity)val10).Explode(val11);
										((DBObject)val10).Erase();
										foreach (Entity item2 in val11)
										{
											Entity val12 = item2;
											DBText val13 = (DBText)(object)((val12 is DBText) ? val12 : null);
											try
											{
												if (val13 != null)
												{
													val5.AppendEntity((Entity)(object)val13);
													DeclaracoesGeral.bAnularEventos = true;
													val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
													Entity Ent2 = (Entity)(object)val13;
													XDataRelatorio.GravarXDataMateriais(ref Ent2, index, iPainel);
												}
											}
											finally
											{
												((IDisposable)val13)?.Dispose();
											}
										}
									}
									else
									{
										text = Conversions.ToString(dgRel.Rows[iIndicee].Cells[1].Value);
										text = text.Replace(",", ";");
										Entity Ent2 = (Entity)(object)val10;
										XDataRelatorio.GravarXDataMateriais(ref Ent2, index, iPainel, Conversions.ToString(dgRel.Rows[iIndicee].Cells[1].Value));
										flag = true;
									}
								}
							}
						}
						finally
						{
							((IDisposable)val10)?.Dispose();
						}
						Line val14 = (Line)(object)((Ent is Line) ? Ent : null);
						try
						{
							if (val14 != null)
							{
								Ent.Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity(Ent);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
								XDataRelatorio.GravarXDataMateriais(ref Ent, index, iPainel);
								value = ((Drawable)val14).Bounds.Value;
								val8 = value.MaxPoint;
								if (val8.Y < dY)
								{
									value = ((Drawable)val14).Bounds.Value;
									val8 = value.MaxPoint;
									dY = val8.Y;
								}
							}
						}
						finally
						{
							((IDisposable)val14)?.Dispose();
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
}

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

public class Relatorios_CabosChesfDWG
{
	public struct structureRelatCabosChesf
	{
		public string Tag;

		public string Bitola;

		public string Comprimento;

		public int iPn1;

		public int iPn2;

		public string sPn1;

		public string sPn2;

		public string sObs;
	}

	public struct structureRelatCabosEDPES
	{
		public string Tag;

		public int iPn1;

		public int iPn2;

		public string sPn1;

		public string sPn2;

		public string Funcao;

		public string Formacao;

		public string VeiasUsadas;

		public string VeiasLivres;

		public string isolacao;

		public string Blindado;

		public string Comprimento;

		public string sObs;
	}

	public struct ConfigRelatCabosChesf
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

	public struct structureRelatCabosCEMIG_D
	{
		public string _1_REV;

		public string _2_etapa;

		public string _3_Tag;

		public string _4_Funcao;

		public string _5_sPn1;

		public string _6_sPn2;

		public string _7_Comprimento;

		public string _8_Formacao;

		public string _9_VeiasTOT;

		public string _10_VeiasUsadas;

		public string _11_tipo;

		public string _12_Blindado;
	}

	public static void CriaMatrizDeCabosDWGChesf(structureRelatCabosChesf[] mCabos, string revisaoSel, ConfigRelatCabosChesf confRelatCabos)
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
				CriaTabelaCaboChesf(num, pt, mCabos, 0, ref dY, ref dX, confRelatCabos, revisaoSel);
				int num4 = Information.UBound(mCabos);
				int num5 = 1;
				while (num5 <= num4 && !DeclaracoesGeral.bPararRelatorio)
				{
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					pt = new Point3d(pt.X, dY, 0.0);
					CriaTabelaCaboChesf(num, pt, mCabos, num5, ref dY, ref dX, confRelatCabos, revisaoSel);
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
							CriaTabelaCaboChesf(num, pt, mCabos, 0, ref dY, ref dX, confRelatCabos, revisaoSel);
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

	public static void CriaTabelaCaboChesf(double dLarguraDoBloco, Point3d pt, structureRelatCabosChesf[] mCabos, int iIndice, ref double dY, ref double dX, ConfigRelatCabosChesf confRelatCabos, string revisaoSel)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_055a: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_035d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Expected Obj, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d5: Expected Obj, but got Unknown
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0526: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			Database database = mdiActiveDocument.Database;
			bool flag = true;
			string text = "";
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
				val6.SetSize(1, 6);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
				val6.Columns[0].Width = dLarguraDoBloco * 0.12;
				val6.Columns[1].Width = dLarguraDoBloco * 0.12;
				val6.Columns[2].Width = dLarguraDoBloco * 0.13;
				val6.Columns[3].Width = dLarguraDoBloco * 0.28;
				val6.Columns[4].Width = dLarguraDoBloco * 0.28;
				val6.Columns[5].Width = dLarguraDoBloco * 0.07;
				if (iIndice != 0)
				{
					val6.SetRowHeight(confRelatCabos.AlturaDoBloco);
				}
				else
				{
					val6.SetRowHeight(confRelatCabos.AlturaDoBloco * 1.5);
				}
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = confRelatCabos.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 5);
				val6.Cells[0, 0].TextString = mCabos[iIndice].Tag.ToString();
				val6.Cells[0, 1].TextString = mCabos[iIndice].Bitola.ToString();
				val6.Cells[0, 2].TextString = mCabos[iIndice].Comprimento.ToString();
				val6.Cells[0, 3].TextString = mCabos[iIndice].sPn1.ToString();
				val6.Cells[0, 4].TextString = mCabos[iIndice].sPn2.ToString();
				val6.Cells[0, 5].TextString = mCabos[iIndice].sObs.ToString();
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
							if (flag)
							{
								text = val10.Text;
								flag = false;
							}
							else
							{
								text = "";
								flag = false;
							}
							Entity Ent2 = (Entity)(object)val10;
							string sRelatorio = "CHESF";
							XDataRelatorio.GravarXDataCabosEnergisa(ref Ent2, revisaoSel, ref sRelatorio, ref text);
							val10 = (MText)Ent2;
						}
					}
					Line val11 = (Line)(object)((Ent is Line) ? Ent : null);
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
						string sRelatorio = "";
						string sCabo = "";
						XDataRelatorio.GravarXDataCabosEnergisa(ref Ent, revisaoSel, ref sRelatorio, ref sCabo);
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

	public static void ApagaRelatorioCabosChesf(string revisaoSel)
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
						string sRelatorio = "";
						string sCabo = "";
						if (XDataRelatorio.LEXDataCabosEnergisa(ref Ent, ref revisaoSel, ref sRelatorio, ref sCabo))
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

	public static void BuscaCabosDoRelatorioCabosChesf(ref List<string> lCabos, string revisaoSel)
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
						string sCabo = "";
						string sRelatorio = "CHESF";
						if (XDataRelatorio.LEXDataCabosEnergisa(ref Ent, ref revisaoSel, ref sRelatorio, ref sCabo))
						{
							lCabos.Add(sCabo);
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

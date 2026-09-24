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

public class Relatorios_Rev_Matricial
{
	public struct ConfigReV
	{
		public short CorLinha;

		public short CorJumper;

		public short CorTexto;

		public double TamanhoFonte;

		public short QuantColunas;

		public double AlturaInicial;

		public double DistEntreColunas;

		public double AlturaDoBloco;

		public string sFonte;

		public double dOrdenadaY;

		public string sTitulo1;

		public string sTitulo2;

		public string sRevisoesProjeto;
	}

	public struct RevisaoMatricial
	{
		public string sAlternativa;

		public string sPagina;

		public string sRevisao;

		public string R00;

		public string R01;

		public string R02;

		public string R03;

		public string R04;

		public string R05;

		public string R06;

		public string R07;

		public string R08;

		public string R09;

		public string R10;

		public string R11;

		public string R12;

		public string R13;

		public string R14;

		public string R15;

		public string R16;
	}

	public struct RevisaoPosicaoMatricial
	{
		public string R0;

		public string R1;

		public string R2;

		public string R3;

		public string R4;

		public string R5;

		public string R6;

		public string R7;

		public string R8;

		public string R9;

		public string R10;

		public string R11;

		public string R12;

		public string R13;

		public string R14;

		public string R15;

		public string R16;
	}

	public static void CriaRelatorioREvisaoDWG(ConfigReV confRelRev, RevisaoMatricial[] mRelatorioMatricial)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double dX = 0.0;
		double dY = 0.0;
		string sRevisoesProjeto = confRelRev.sRevisoesProjeto;
		checked
		{
			double num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - confRelRev.DistEntreColunas * (double)(confRelRev.QuantColunas + 1);
			Point3d val = new Point3d(RH.Pti.X + confRelRev.DistEntreColunas, confRelRev.dOrdenadaY, 0.0);
			if (confRelRev.dOrdenadaY == 0.0)
			{
				val = new Point3d(RH.Pti.X + confRelRev.DistEntreColunas, RH.Pti.Y - confRelRev.AlturaInicial - 5.0, 0.0);
			}
			Point3d val2 = val;
			Point3d val3 = new Point3d(val.X + num / 2.0, val.Y, 0.0);
			Point3d val4 = new Point3d(0.0, 0.0, 0.0);
			try
			{
				Dicionario.CriaTableStyleRelatorios(confRelRev.sFonte, 1.0, 1.0);
				int num2 = -1;
				int num3 = 1;
				int num4 = Information.UBound(mRelatorioMatricial);
				for (num3 = 1; num3 <= num4; num3++)
				{
					if (num2 != -1)
					{
						val = new Point3d(val.X, dY, 0.0);
						CriaTabelaRevMatricial(num, val, ref dY, ref dX, confRelRev, mRelatorioMatricial, num3);
						if (!(dY < RH.AltBase))
						{
							continue;
						}
						if (num2 != 1)
						{
							ApagaUmIndice(num3);
							Pagina.OrdenaMatrizPaginas();
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
									break;
								}
								DeclaracoesGeral._uscPagina.CarregaPG();
							}
							num2 = 1;
							val = val2;
							Point3d pt = val;
							ConfigReV confRelRev2 = confRelRev;
							string sRevisoesProjeto2 = "";
							CriaTituloRevMatricial(num, pt, ref dY, ref dX, confRelRev2, mRelatorioMatricial, 0, ref sRevisoesProjeto2);
							val = new Point3d(val.X, dY, 0.0);
							CriaTabelaRevMatricial(num, val, ref dY, ref dX, confRelRev, mRelatorioMatricial, num3);
							num2 = 1;
						}
						else
						{
							val = val3;
							num2++;
							ApagaUmIndice(num3);
							Point3d pt2 = val;
							ConfigReV confRelRev3 = confRelRev;
							string sRevisoesProjeto2 = "";
							CriaTituloRevMatricial(num, pt2, ref dY, ref dX, confRelRev3, mRelatorioMatricial, 0, ref sRevisoesProjeto2);
							val = new Point3d(val.X, dY, 0.0);
							CriaTabelaRevMatricial(num, val, ref dY, ref dX, confRelRev, mRelatorioMatricial, num3);
						}
					}
					else
					{
						num2 = 1;
						CriaTituloRevMatricial(num, val, ref dY, ref dX, confRelRev, mRelatorioMatricial, 0, ref sRevisoesProjeto);
						val = new Point3d(val.X, dY, 0.0);
						CriaTabelaRevMatricial(num, val, ref dY, ref dX, confRelRev, mRelatorioMatricial, num3);
					}
				}
				bool flag = false;
				do
				{
					val = new Point3d(val.X, dY, 0.0);
					CriaTabelaRevMatricialVazia(num, val, ref dY, ref dX, confRelRev, num3);
					if (dY < RH.AltBase)
					{
						ApagaUmIndice(num3);
						if (num2 != 1)
						{
							flag = true;
						}
						else
						{
							val = val3;
							num2++;
							ApagaUmIndice(num3);
							Point3d pt3 = val;
							ConfigReV confRelRev4 = confRelRev;
							string sRevisoesProjeto2 = "";
							CriaTituloRevMatricial(num, pt3, ref dY, ref dX, confRelRev4, mRelatorioMatricial, 0, ref sRevisoesProjeto2);
							val = new Point3d(val.X, dY, 0.0);
							CriaTabelaRevMatricialVazia(num, val, ref dY, ref dX, confRelRev, num3);
						}
					}
					num3++;
				}
				while (!flag);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void BuscaRevisoesAntigasDWG(ref RevisaoMatricial[] mRevisoesAntigas)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected Obj, but got Unknown
		int num = 0;
		mRevisoesAntigas = new RevisaoMatricial[1];
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							MText val6 = (MText)(object)((val5 is MText) ? val5 : null);
							try
							{
								if (val6 != null)
								{
									string sRevisao = "";
									string sPagina = "";
									int iIndice = 0;
									string sTipo = "";
									Entity Ent = (Entity)(object)val6;
									if (XDataRelatorio.leXDataRevisaoMatricial(ref Ent, ref sRevisao, ref sPagina, ref iIndice, ref sTipo) && Operators.CompareString(sTipo, "REV_FOLHA", TextCompare: true) == 0)
									{
										num++;
										sRevisao += "|||||||||||||||||";
										mRevisoesAntigas = (RevisaoMatricial[])Utils.CopyArray(mRevisoesAntigas, new RevisaoMatricial[num + 1]);
										string[] array = sRevisao.Split('|');
										mRevisoesAntigas[num].sRevisao = "";
										mRevisoesAntigas[num].sAlternativa = "";
										mRevisoesAntigas[num].sPagina = sPagina;
										mRevisoesAntigas[num].R00 = array[0];
										mRevisoesAntigas[num].R01 = array[1];
										mRevisoesAntigas[num].R02 = array[2];
										mRevisoesAntigas[num].R03 = array[3];
										mRevisoesAntigas[num].R04 = array[4];
										mRevisoesAntigas[num].R05 = array[5];
										mRevisoesAntigas[num].R06 = array[6];
										mRevisoesAntigas[num].R07 = array[7];
										mRevisoesAntigas[num].R08 = array[8];
										mRevisoesAntigas[num].R09 = array[9];
										mRevisoesAntigas[num].R10 = array[10];
										mRevisoesAntigas[num].R11 = array[11];
										mRevisoesAntigas[num].R12 = array[12];
										mRevisoesAntigas[num].R13 = array[13];
										mRevisoesAntigas[num].R14 = array[14];
										mRevisoesAntigas[num].R15 = array[15];
										mRevisoesAntigas[num].R16 = array[16];
									}
								}
							}
							finally
							{
								((IDisposable)val6)?.Dispose();
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

	public static void CriaTituloRevMatricial(double dLarguraDoBloco, Point3d pt, ref double dY, ref double dX, ConfigReV confRelRev, RevisaoMatricial[] mRelatorioMatricial, int iIndiceRel, ref string sRevisoesProjeto)
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
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected Obj, but got Unknown
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Expected Obj, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Expected Obj, but got Unknown
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Unknown result type (might be due to invalid IL or missing references)
		//IL_09af: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d3: Expected Obj, but got Unknown
		//IL_09dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a18: Expected Obj, but got Unknown
		//IL_0d08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
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
					_ = ((SymbolTable)val3)["romans"];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(2, 1);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					((BlockReference)val6).Position = pt;
					val6.Columns[0].Width = dLarguraDoBloco * 0.058;
					val6.SetRowHeight(confRelRev.AlturaDoBloco);
					((CellRange)val6.Cells[0, 0]).TextHeight = confRelRev.TamanhoFonte;
					((CellRange)val6.Cells[1, 0]).TextHeight = confRelRev.TamanhoFonte;
					val6.Cells[0, 0].TextString = confRelRev.sTitulo1;
					((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
					val6.Cells[1, 0].TextString = confRelRev.sTitulo2;
					((CellRange)val6.Cells[1, 0]).Alignment = (CellAlignment)5;
					((Entity)val6).ColorIndex = confRelRev.CorLinha;
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
					dY = val7.Y;
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MinPoint;
					dX = val7.X;
					Application.UpdateScreen();
					DBObjectCollection val8 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val6).Explode(val8);
					((DBObject)val6).Erase();
					foreach (Entity item in val8)
					{
						Entity val9 = item;
						MText val10 = (MText)(object)((val9 is MText) ? val9 : null);
						try
						{
							if (val10 != null && Operators.CompareString(val10.Text, "#B#", TextCompare: true) != 0)
							{
								((Entity)val10).ColorIndex = confRelRev.CorTexto;
								((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								Entity Ent = (Entity)(object)val10;
								XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, "", iIndiceRel, sRevisoesProjeto, "REV_TITULO");
								if (iIndiceRel == 0)
								{
									sRevisoesProjeto = "";
								}
							}
						}
						finally
						{
							((IDisposable)val10)?.Dispose();
						}
						Line val11 = (Line)(object)((val9 is Line) ? val9 : null);
						try
						{
							if (val11 != null)
							{
								val9.Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity(val9);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								Entity Ent = (Entity)(object)val11;
								XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, "", iIndiceRel, "", "");
							}
						}
						finally
						{
							((IDisposable)val11)?.Dispose();
						}
						((DisposableWrapper)val9).Dispose();
					}
					Table val12 = new Table();
					((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
					val12.SetSize(1, 17);
					val12.GenerateLayout();
					val12.RecomputeTableBlock(true);
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MaxPoint;
					double x = val7.X;
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MaxPoint;
					pt = new Point3d(x, val7.Y, 0.0);
					((BlockReference)val12).Position = pt;
					int num = 0;
					do
					{
						val12.Columns[num].Width = dLarguraDoBloco * 0.026;
						((CellRange)val12.Cells[0, num]).TextHeight = confRelRev.TamanhoFonte;
						((CellRange)val12.Cells[0, num]).Alignment = (CellAlignment)5;
						num++;
					}
					while (num <= 16);
					val12.SetRowHeight(confRelRev.AlturaDoBloco * 2.0);
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].sPagina, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].sPagina = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].sAlternativa, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].sAlternativa = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R00, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R00 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R01, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R01 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R02, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R02 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R03, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R03 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R04, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R04 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R05, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R05 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R06, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R06 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R07, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R07 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R08, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R08 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R09, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R09 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R10, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R10 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R11, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R11 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R12, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R12 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R13, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R13 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R14, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R14 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R15, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R15 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R16, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R16 = "#B#";
					}
					val12.Cells[0, 0].TextString = mRelatorioMatricial[iIndiceRel].R00;
					val12.Cells[0, 1].TextString = mRelatorioMatricial[iIndiceRel].R01;
					val12.Cells[0, 2].TextString = mRelatorioMatricial[iIndiceRel].R02;
					val12.Cells[0, 3].TextString = mRelatorioMatricial[iIndiceRel].R03;
					val12.Cells[0, 4].TextString = mRelatorioMatricial[iIndiceRel].R04;
					val12.Cells[0, 5].TextString = mRelatorioMatricial[iIndiceRel].R05;
					val12.Cells[0, 6].TextString = mRelatorioMatricial[iIndiceRel].R06;
					val12.Cells[0, 7].TextString = mRelatorioMatricial[iIndiceRel].R07;
					val12.Cells[0, 8].TextString = mRelatorioMatricial[iIndiceRel].R08;
					val12.Cells[0, 9].TextString = mRelatorioMatricial[iIndiceRel].R09;
					val12.Cells[0, 10].TextString = mRelatorioMatricial[iIndiceRel].R10;
					val12.Cells[0, 11].TextString = mRelatorioMatricial[iIndiceRel].R11;
					val12.Cells[0, 12].TextString = mRelatorioMatricial[iIndiceRel].R12;
					val12.Cells[0, 13].TextString = mRelatorioMatricial[iIndiceRel].R13;
					val12.Cells[0, 14].TextString = mRelatorioMatricial[iIndiceRel].R14;
					val12.Cells[0, 15].TextString = mRelatorioMatricial[iIndiceRel].R15;
					val12.Cells[0, 16].TextString = mRelatorioMatricial[iIndiceRel].R16;
					int num2 = 0;
					do
					{
						((CellRange)val12.Cells[0, num2]).Alignment = (CellAlignment)5;
						num2++;
					}
					while (num2 <= 16);
					((Entity)val12).ColorIndex = confRelRev.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val12.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val12.GenerateLayout();
					val5.AppendEntity((Entity)(object)val12);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
					val12.RecomputeTableBlock(true);
					DBObjectCollection val13 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val12.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val12).Explode(val13);
					((DBObject)val12).Erase();
					foreach (Entity item2 in val13)
					{
						Entity val14 = item2;
						MText val15 = (MText)(object)((val14 is MText) ? val14 : null);
						try
						{
							if (val15 != null && Operators.CompareString(val15.Text, "#B#", TextCompare: true) != 0)
							{
								((Entity)val15).ColorIndex = confRelRev.CorTexto;
								((Entity)val15).Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity((Entity)(object)val15);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val15, true);
								Entity Ent = (Entity)(object)val15;
								XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, "", iIndiceRel, "", "");
							}
						}
						finally
						{
							((IDisposable)val15)?.Dispose();
						}
						Line val16 = (Line)(object)((val14 is Line) ? val14 : null);
						try
						{
							if (val16 != null)
							{
								val14.Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity(val14);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val14, true);
								Entity Ent = (Entity)(object)val16;
								XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, "", iIndiceRel, "", "");
							}
						}
						finally
						{
							((IDisposable)val16)?.Dispose();
						}
						((DisposableWrapper)val14).Dispose();
					}
					pt = new Point3d(dX, dY, 0.0);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					iIndiceRel++;
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

	public static void CriaTabelaRevMatricial(double dLarguraDoBloco, Point3d pt, ref double dY, ref double dX, ConfigReV confRelRev, RevisaoMatricial[] mRelatorioMatricial, int iIndiceRel)
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
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Expected Obj, but got Unknown
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0750: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_0779: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07af: Expected Obj, but got Unknown
		//IL_0b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c6: Unknown result type (might be due to invalid IL or missing references)
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
					_ = ((SymbolTable)val3)["romans"];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(1, 18);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					((BlockReference)val6).Position = pt;
					val6.Columns[0].Width = dLarguraDoBloco * 0.058;
					((CellRange)val6.Cells[0, 0]).TextHeight = confRelRev.TamanhoFonte;
					int num = 1;
					do
					{
						val6.Columns[num].Width = dLarguraDoBloco * 0.026;
						num++;
					}
					while (num <= 17);
					int num2 = 0;
					do
					{
						((CellRange)val6.Cells[0, num2]).TextHeight = confRelRev.TamanhoFonte;
						num2++;
					}
					while (num2 <= 17);
					val6.SetRowHeight(confRelRev.AlturaDoBloco);
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].sPagina, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].sPagina = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].sAlternativa, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].sAlternativa = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].sRevisao, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].sRevisao = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R00, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R00 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R01, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R01 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R02, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R02 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R03, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R03 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R04, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R04 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R05, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R05 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R06, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R06 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R07, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R07 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R08, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R08 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R09, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R09 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R10, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R10 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R11, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R11 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R12, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R12 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R13, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R13 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R14, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R14 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R15, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R15 = "#B#";
					}
					if (Operators.CompareString(mRelatorioMatricial[iIndiceRel].R16, "", TextCompare: true) == 0)
					{
						mRelatorioMatricial[iIndiceRel].R16 = "#B#";
					}
					string text = mRelatorioMatricial[iIndiceRel].sPagina;
					if ((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4))
					{
						text = mRelatorioMatricial[iIndiceRel].sAlternativa;
						if (Operators.CompareString(text.Trim(), "#B#", TextCompare: true) == 0)
						{
							text = mRelatorioMatricial[iIndiceRel].sPagina;
						}
					}
					val6.Cells[0, 0].TextString = text;
					val6.Cells[0, 1].TextString = mRelatorioMatricial[iIndiceRel].R00;
					val6.Cells[0, 2].TextString = mRelatorioMatricial[iIndiceRel].R01;
					val6.Cells[0, 3].TextString = mRelatorioMatricial[iIndiceRel].R02;
					val6.Cells[0, 4].TextString = mRelatorioMatricial[iIndiceRel].R03;
					val6.Cells[0, 5].TextString = mRelatorioMatricial[iIndiceRel].R04;
					val6.Cells[0, 6].TextString = mRelatorioMatricial[iIndiceRel].R05;
					val6.Cells[0, 7].TextString = mRelatorioMatricial[iIndiceRel].R06;
					val6.Cells[0, 8].TextString = mRelatorioMatricial[iIndiceRel].R07;
					val6.Cells[0, 9].TextString = mRelatorioMatricial[iIndiceRel].R08;
					val6.Cells[0, 10].TextString = mRelatorioMatricial[iIndiceRel].R09;
					val6.Cells[0, 11].TextString = mRelatorioMatricial[iIndiceRel].R10;
					val6.Cells[0, 12].TextString = mRelatorioMatricial[iIndiceRel].R11;
					val6.Cells[0, 13].TextString = mRelatorioMatricial[iIndiceRel].R12;
					val6.Cells[0, 14].TextString = mRelatorioMatricial[iIndiceRel].R13;
					val6.Cells[0, 15].TextString = mRelatorioMatricial[iIndiceRel].R14;
					val6.Cells[0, 16].TextString = mRelatorioMatricial[iIndiceRel].R15;
					val6.Cells[0, 17].TextString = mRelatorioMatricial[iIndiceRel].R16;
					int num3 = 0;
					do
					{
						((CellRange)val6.Cells[0, num3]).Alignment = (CellAlignment)5;
						num3++;
					}
					while (num3 <= 17);
					string text2 = mRelatorioMatricial[iIndiceRel].sRevisao;
					((CellRange)val6.Cells[0, 1]).Alignment = (CellAlignment)5;
					((Entity)val6).ColorIndex = confRelRev.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					DBObjectCollection val7 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val6).Explode(val7);
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d minPoint = value.MinPoint;
					dX = minPoint.X;
					value = ((Drawable)val6).Bounds.Value;
					minPoint = value.MinPoint;
					dY = minPoint.Y;
					((DBObject)val6).Erase();
					foreach (Entity item in val7)
					{
						Entity val8 = item;
						MText val9 = (MText)(object)((val8 is MText) ? val8 : null);
						try
						{
							if (val9 != null && Operators.CompareString(val9.Text, "#B#", TextCompare: true) != 0)
							{
								((Entity)val9).ColorIndex = confRelRev.CorTexto;
								((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity((Entity)(object)val9);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								if (Operators.CompareString(val9.Text, "X", TextCompare: true) == 0)
								{
									Entity Ent = (Entity)(object)val9;
									XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, mRelatorioMatricial[iIndiceRel].sPagina, iIndiceRel, "", "");
								}
								else
								{
									text2 = text2.Replace("#B#", "");
									Entity Ent = (Entity)(object)val9;
									XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, mRelatorioMatricial[iIndiceRel].sPagina, iIndiceRel, OrdenaRevisao(text2), "REV_FOLHA");
									text2 = "";
								}
							}
						}
						finally
						{
							((IDisposable)val9)?.Dispose();
						}
						Line val10 = (Line)(object)((val8 is Line) ? val8 : null);
						try
						{
							if (val10 != null)
							{
								val8.Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity(val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								Entity Ent = (Entity)(object)val10;
								XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, mRelatorioMatricial[iIndiceRel].sPagina, iIndiceRel, "", "");
							}
						}
						finally
						{
							((IDisposable)val10)?.Dispose();
						}
						((DisposableWrapper)val8).Dispose();
					}
					pt = new Point3d(dX, dY, 0.0);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					iIndiceRel++;
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

	public static void CriaTabelaRevMatricialVazia(double dLarguraDoBloco, Point3d pt, ref double dY, ref double dX, ConfigReV confRelRev, int iIndiceRel)
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
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected Obj, but got Unknown
		//IL_03c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0411: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected Obj, but got Unknown
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Unknown result type (might be due to invalid IL or missing references)
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
					_ = ((SymbolTable)val3)["romans"];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(1, 18);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					((BlockReference)val6).Position = pt;
					val6.Columns[0].Width = dLarguraDoBloco * 0.058;
					((CellRange)val6.Cells[0, 0]).TextHeight = confRelRev.TamanhoFonte;
					int num = 1;
					do
					{
						val6.Columns[num].Width = dLarguraDoBloco * 0.026;
						num++;
					}
					while (num <= 17);
					int num2 = 0;
					do
					{
						((CellRange)val6.Cells[0, num2]).TextHeight = confRelRev.TamanhoFonte;
						num2++;
					}
					while (num2 <= 17);
					val6.SetRowHeight(confRelRev.AlturaDoBloco);
					val6.Cells[0, 0].TextString = "#B#";
					val6.Cells[0, 1].TextString = "#B#";
					val6.Cells[0, 2].TextString = "#B#";
					val6.Cells[0, 3].TextString = "#B#";
					val6.Cells[0, 4].TextString = "#B#";
					val6.Cells[0, 5].TextString = "#B#";
					val6.Cells[0, 6].TextString = "#B#";
					val6.Cells[0, 7].TextString = "#B#";
					val6.Cells[0, 8].TextString = "#B#";
					val6.Cells[0, 9].TextString = "#B#";
					val6.Cells[0, 10].TextString = "#B#";
					val6.Cells[0, 11].TextString = "#B#";
					val6.Cells[0, 12].TextString = "#B#";
					val6.Cells[0, 13].TextString = "#B#";
					val6.Cells[0, 14].TextString = "#B#";
					val6.Cells[0, 15].TextString = "#B#";
					val6.Cells[0, 16].TextString = "#B#";
					val6.Cells[0, 17].TextString = "#B#";
					int num3 = 0;
					do
					{
						((CellRange)val6.Cells[0, num3]).Alignment = (CellAlignment)5;
						num3++;
					}
					while (num3 <= 17);
					string text = "#B#";
					((CellRange)val6.Cells[0, 1]).Alignment = (CellAlignment)5;
					((Entity)val6).ColorIndex = confRelRev.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					DBObjectCollection val7 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val6).Explode(val7);
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d minPoint = value.MinPoint;
					dX = minPoint.X;
					value = ((Drawable)val6).Bounds.Value;
					minPoint = value.MinPoint;
					dY = minPoint.Y;
					((DBObject)val6).Erase();
					foreach (Entity item in val7)
					{
						Entity val8 = item;
						MText val9 = (MText)(object)((val8 is MText) ? val8 : null);
						try
						{
							if (val9 != null && Operators.CompareString(val9.Text, "#B#", TextCompare: true) != 0)
							{
								((Entity)val9).ColorIndex = confRelRev.CorTexto;
								((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity((Entity)(object)val9);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								if (Operators.CompareString(val9.Text, "X", TextCompare: true) == 0)
								{
									Entity Ent = (Entity)(object)val9;
									XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, "", iIndiceRel, "", "");
								}
								else
								{
									text = text.Replace("#B#", "");
									Entity Ent = (Entity)(object)val9;
									XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, "", iIndiceRel, text, "REV_FOLHA");
								}
							}
						}
						finally
						{
							((IDisposable)val9)?.Dispose();
						}
						Line val10 = (Line)(object)((val8 is Line) ? val8 : null);
						try
						{
							if (val10 != null)
							{
								val8.Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity(val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								Entity Ent = (Entity)(object)val10;
								XDataRelatorio.GravarXDataRevisaoMatricial(ref Ent, "", iIndiceRel, "", "");
							}
						}
						finally
						{
							((IDisposable)val10)?.Dispose();
						}
						((DisposableWrapper)val8).Dispose();
					}
					pt = new Point3d(dX, dY, 0.0);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					iIndiceRel++;
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

	public static void ApagaUmIndice(int iIndice)
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
						string sRevisao = "";
						string sPagina = "";
						int iIndice2 = 0;
						string sTipo = "";
						if (XDataRelatorio.leXDataRevisaoMatricial(ref Ent, ref sRevisao, ref sPagina, ref iIndice2, ref sTipo) && iIndice2 == iIndice)
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

	public static void ApagaRelatorioRevisaoMatricial()
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
						string sRevisao = "";
						string sPagina = "";
						int iIndice = 0;
						string sTipo = "";
						if (XDataRelatorio.leXDataRevisaoMatricial(ref Ent, ref sRevisao, ref sPagina, ref iIndice, ref sTipo))
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

	public static bool BuscaRevisaoMatricial(ref List<string> lRevisoes)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected Obj, but got Unknown
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			lRevisoes.Clear();
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
						string sRevisao = "";
						string sPagina = "";
						int iIndice = 0;
						string sTipo = "";
						if (XDataRelatorio.leXDataRevisaoMatricial(ref Ent, ref sRevisao, ref sPagina, ref iIndice, ref sTipo) && ((iIndice == 0) & (Operators.CompareString(sTipo, "REV_TITULO", TextCompare: true) == 0)))
						{
							string[] array = sRevisao.Split('|');
							int num = Information.UBound(array);
							for (int i = 0; i <= num; i = checked(i + 1))
							{
								lRevisoes.Add(array[i].Trim());
								result = true;
							}
							break;
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
				return result;
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

	public static bool BuscaRevisoes(string sPagina, string sRevisao, RevisaoMatricial[] mRevisoesAntigas)
	{
		bool result = false;
		int num = Information.UBound(mRevisoesAntigas);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(mRevisoesAntigas[i].sPagina, sPagina, TextCompare: true) != 0)
			{
				continue;
			}
			if (Operators.CompareString(sRevisao, "", TextCompare: true) != 0)
			{
				if (Operators.CompareString(mRevisoesAntigas[i].R00, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R01, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R02, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R03, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R04, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R05, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R06, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R07, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R08, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R09, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R10, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R11, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R12, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R13, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R14, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R15, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
				if (Operators.CompareString(mRevisoesAntigas[i].R16, sRevisao, TextCompare: true) == 0)
				{
					result = true;
				}
			}
			break;
		}
		return result;
	}

	public static string OrdenaRevisao(string sRevisao)
	{
		string text = "";
		if (Operators.CompareString(sRevisao, "", TextCompare: true) != 0)
		{
			string[] array = sRevisao.Split('|');
			List<string> list = new List<string>();
			int num = Information.UBound(array);
			for (int i = 0; i <= num; i = checked(i + 1))
			{
				if (!list.Contains(array[i]) && Operators.CompareString(array[i], "", TextCompare: true) != 0)
				{
					list.Add(array[i]);
				}
			}
			list.Sort();
			foreach (string item in list)
			{
				text = text + item + "|";
			}
		}
		return text;
	}

	public static double BuscaPosicaoInicialRelatorio()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		double result = 270.0;
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
						Line val5 = (Line)(object)((Ent is Line) ? Ent : null);
						if (val5 != null)
						{
							string sRevisao = "";
							string sPagina = "";
							int iIndice = 0;
							string sTipo = "";
							if (XDataRelatorio.leXDataRevisaoMatricial(ref Ent, ref sRevisao, ref sPagina, ref iIndice, ref sTipo))
							{
								Point3d startPoint = val5.StartPoint;
								result = Math.Round(startPoint.Y, 2);
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

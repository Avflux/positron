using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.Colors;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Relatorios_FiacaoDWG
{
	public static object CapturaOsTextStyle()
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		_ = Application.DocumentManager.MdiActiveDocument;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			string[] array = new string[1] { "" };
			DBObject val2 = val.GetObject(database.TextStyleTableId, (OpenMode)0);
			TextStyleTable val3 = (TextStyleTable)(object)((val2 is TextStyleTable) ? val2 : null);
			SymbolTableEnumerator enumerator = default;
			try
			{
				enumerator = ((SymbolTable)val3).GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					DBObject val4 = val.GetObject(current, (OpenMode)1);
					TextStyleTableRecord val5 = (TextStyleTableRecord)(object)((val4 is TextStyleTableRecord) ? val4 : null);
					_ = ((SymbolTableRecord)val5).Name;
					if (Operators.CompareString(((SymbolTableRecord)val5).Name.Trim(), "", TextCompare: true) != 0)
					{
						array = (string[])Utils.CopyArray(array, new string[checked(Information.UBound(array) + 1 + 1)]);
						array[Information.UBound(array)] = ((SymbolTableRecord)val5).Name;
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
			result = array;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static void CriaRelatorioMatrizFiacaoDispositivoDWG(DeclaracoesFiacao.structureRelFiacao[] mFiacao, Declaracoes2.ConfRelatorio ConfRelFiacao, string sTipoRelatorio, int iPainel, string sDestino1, string sDestino2)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double num = 0.0;
		double YInicio = 0.0;
		double num2 = 0.0;
		num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num2 -= ConfRelFiacao.DistEntreColunas * (double)(ConfRelFiacao.QuantColunas + 1);
			num2 /= (double)ConfRelFiacao.QuantColunas;
			double num3 = 0.0;
			num3 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - num - (double)ConfRelFiacao.QuantColunas * num2;
			num3 /= (double)(ConfRelFiacao.QuantColunas + 1);
			bool flag2 = false;
			Point3d pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
			bool flag3 = false;
			string sValor = "";
			try
			{
				int num4 = 1;
				Dicionario.CriaTableStyleRelatorios(ConfRelFiacao.sFonte, 0.5, 0.5);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				bool bTituloTag = false;
				int num5 = 100;
				int num6 = Information.UBound(mFiacao);
				int num7 = 1;
				double num8 = default;
				double num9 = default;
				while (num7 <= num6 && !DeclaracoesGeral.bPararRelatorio)
				{
					if (num7 > num5)
					{
						Application.DoEvents();
						num5 += 100;
					}
					if (!((Operators.CompareString(mFiacao[num7 - 1].Tag, "", TextCompare: true) != 0) & (num7 == 1)))
					{
						if ((Operators.CompareString(mFiacao[num7 - 1].Tag, "", TextCompare: true) != 0) & (num7 > 1))
						{
							if (!flag2)
							{
								pt = new Point3d(pt.X, pt.Y - ConfRelFiacao.AlturaDoBloco / 2.0, 0.0);
							}
							num8 = ConfRelFiacao.AlturaDoBloco;
							if (Information.UBound(mFiacao) >= num7 + 1 && Operators.CompareString(mFiacao[num7 - 1].Tag, "", TextCompare: true) != 0)
							{
								num8 = ConfRelFiacao.AlturaDoBloco * 4.5;
							}
							sValor = mFiacao[num7 - 1].Tag;
							bTituloTag = true;
							if (pt.Y < RH.AltBase + num8)
							{
								flag3 = true;
								goto IL_01fd;
							}
							if (!flag2)
							{
								CriaTituloDaTabelaFiacaoDispBorne(sTipoRelatorio, num2, ref pt, mFiacao, ConfRelFiacao, iPainel, "", sValor, sDestino1, sDestino2);
							}
							bTituloTag = false;
						}
					}
					else
					{
						sValor = mFiacao[num7 - 1].Tag;
						bTituloTag = true;
						CriaTituloDaTabelaFiacaoDispBorne(sTipoRelatorio, num2, ref pt, mFiacao, ConfRelFiacao, iPainel, "", sValor, sDestino1, sDestino2);
						bTituloTag = false;
						flag2 = false;
					}
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					_DCriaTabelaFiacaoDisp(sTipoRelatorio, num2, ref pt, mFiacao, num7, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
					flag2 = false;
					num9 = ConfRelFiacao.AlturaDoBloco;
					goto IL_01fd;
					IL_01fd:
					if (flag3)
					{
						num9 = num8;
					}
					if (pt.Y < RH.AltBase + num9)
					{
						if (num4 != ConfRelFiacao.QuantColunas)
						{
							pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas + (ConfRelFiacao.DistEntreColunas + num2) * (double)num4, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
							num4++;
						}
						else if (flag)
						{
							Pagina.OrdenaMatrizPaginas();
							string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_021d;
								}
								Pagina.AtivaPagina(pag);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
							}
							else
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_021d;
								}
								if (num7 < Information.UBound(mFiacao))
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
								}
							}
							pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
							num4 = 1;
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
						if (num7 <= Information.UBound(mFiacao) - 1)
						{
							bTituloTag = false;
							if (Operators.CompareString(mFiacao[num7].Tag, "", TextCompare: true) != 0)
							{
								sValor = mFiacao[num7].Tag;
							}
							CriaTituloDaTabelaFiacaoDispBorne(sTipoRelatorio, num2, ref pt, mFiacao, ConfRelFiacao, iPainel, "", sValor, sDestino1, sDestino2);
							flag2 = true;
							if (Operators.CompareString(mFiacao[num7].Tag.Trim(), "", TextCompare: true) == 0 && flag3)
							{
								bTituloTag = true;
								_DCriaTabelaFiacaoDisp(sTipoRelatorio, num2, ref pt, mFiacao, num7, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
								bTituloTag = false;
								flag3 = false;
							}
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					goto IL_021d;
					IL_021d:
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					num7++;
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

	public static void CriaRelatorioMatrizFiacaoBornesDWG(DeclaracoesFiacao.structureRelFiacao[] mFiacao, Declaracoes2.ConfRelatorio ConfRelFiacao, string sTipoRelatorio, int iPainel, string sDestino1, string sDestino2)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0573: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double num = 0.0;
		double YInicio = 0.0;
		double num2 = 0.0;
		num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num2 -= ConfRelFiacao.DistEntreColunas * (double)(ConfRelFiacao.QuantColunas + 1);
			num2 /= (double)ConfRelFiacao.QuantColunas;
			double num3 = 0.0;
			num3 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - num - (double)ConfRelFiacao.QuantColunas * num2;
			num3 /= (double)(ConfRelFiacao.QuantColunas + 1);
			Point3d pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
			string sValor = "";
			try
			{
				int num4 = 1;
				Dicionario.CriaTableStyleRelatorios(ConfRelFiacao.sFonte, 0.5, 0.5);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				bool bTituloTag = false;
				int num5 = 1000;
				int num6 = Information.UBound(mFiacao);
				int num7 = 1;
				while (num7 <= num6 && !DeclaracoesGeral.bPararRelatorio)
				{
					if (num7 > num5)
					{
						Application.DoEvents();
						num5 += 1000;
					}
					if ((Operators.CompareString(mFiacao[num7 - 1].Tag, "", TextCompare: true) != 0) & (num7 > 1))
					{
						pt = new Point3d(pt.X, pt.Y - ConfRelFiacao.AlturaDoBloco / 2.0, 0.0);
					}
					if (Operators.CompareString(mFiacao[num7 - 1].Tag, "", TextCompare: true) != 0)
					{
						sValor = mFiacao[num7 - 1].Tag;
						bTituloTag = true;
						CriaTituloDaTabelaFiacaoDispBorne(sTipoRelatorio, num2, ref pt, mFiacao, ConfRelFiacao, iPainel, sValor, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1338]), sDestino1, sDestino2);
						bTituloTag = false;
					}
					double num8 = ConfRelFiacao.AlturaDoBloco;
					if (mFiacao[num7].TipoBorne == 1)
					{
						num8 = ConfRelFiacao.AlturaDoBloco * 2.0;
					}
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					_BCriaTabelaFiacaoBorne(sTipoRelatorio, num2, ref pt, mFiacao, num7, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag, num8);
					double num9 = ConfRelFiacao.AlturaDoBloco;
					if (Information.UBound(mFiacao) >= num7 + 1 && Operators.CompareString(mFiacao[num7 + 1].Tag, "", TextCompare: true) != 0)
					{
						num9 = ((mFiacao[num7 + 1].TipoBorne == 1) ? (ConfRelFiacao.AlturaDoBloco * 2.0 + ConfRelFiacao.AlturaDoBloco / 2.0) : (ConfRelFiacao.AlturaDoBloco * 4.5));
					}
					if (num7 <= Information.UBound(mFiacao) - 1 && num9 < ConfRelFiacao.AlturaDoBloco * 2.0 && Operators.CompareString(mFiacao[num7 + 1].Tag, "", TextCompare: true) == 0 && mFiacao[num7 + 1].TipoBorne == 1)
					{
						num9 = ConfRelFiacao.AlturaDoBloco * 2.0;
					}
					bool flag2 = true;
					double num10 = 0.0;
					if (Operators.CompareString(mFiacao[num7].Tag, "", TextCompare: true) != 0)
					{
						num10 = num8 * 3.0;
						flag2 = false;
					}
					if (pt.Y < RH.AltBase + num9 + num10)
					{
						if (num4 != ConfRelFiacao.QuantColunas)
						{
							pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas + (ConfRelFiacao.DistEntreColunas + num2) * (double)num4, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
							num4++;
						}
						else if (flag)
						{
							Pagina.OrdenaMatrizPaginas();
							string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_0261;
								}
								Pagina.AtivaPagina(pag);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
							}
							else
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_0261;
								}
								if (num7 < Information.UBound(mFiacao))
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
								}
							}
							pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
							num4 = 1;
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
						if (num7 <= Information.UBound(mFiacao) - 1)
						{
							bTituloTag = false;
							if (flag2)
							{
								CriaTituloDaTabelaFiacaoDispBorne(sTipoRelatorio, num2, ref pt, mFiacao, ConfRelFiacao, iPainel, sValor, Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1338]), sDestino1, sDestino2);
							}
						}
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					goto IL_0261;
					IL_0261:
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					num7++;
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

	public static void _DCriaTabelaFiacaoDisp(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, DeclaracoesFiacao.structureRelFiacao[] mFiacao, int iIndice, ref double YInicio, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel, ref bool bTituloTag)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected Obj, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected Obj, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected Obj, but got Unknown
		//IL_044d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0489: Expected Obj, but got Unknown
		//IL_0676: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		double x = pt.X;
		double y = pt.Y;
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
				val6.SetSize(1, 8);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				Point3d position = (((BlockReference)val6).Position = new Point3d(x, y, 0.0));
				val6.Columns[0].Width = dLarguraDoBloco * 0.15;
				val6.Columns[1].Width = dLarguraDoBloco * 0.14;
				val6.Columns[2].Width = dLarguraDoBloco * 0.14;
				val6.Columns[3].Width = dLarguraDoBloco * 0.14;
				val6.Columns[4].Width = dLarguraDoBloco * 0.14;
				val6.Columns[5].Width = dLarguraDoBloco * 0.11;
				val6.Columns[6].Width = dLarguraDoBloco * 0.09;
				val6.Columns[7].Width = dLarguraDoBloco * 0.09;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelFiacao.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 7);
				val6.Cells[0, 0].TextString = mFiacao[iIndice].Terminal.ToString();
				val6.Cells[0, 1].TextString = mFiacao[iIndice].Disp1.ToString();
				val6.Cells[0, 2].TextString = mFiacao[iIndice].Term1.ToString();
				val6.Cells[0, 3].TextString = mFiacao[iIndice].Disp2.ToString();
				val6.Cells[0, 4].TextString = mFiacao[iIndice].Term2.ToString();
				val6.Cells[0, 5].TextString = mFiacao[iIndice].Secao12.ToString();
				if (Operators.CompareString(mFiacao[iIndice].Secao34.ToString(), "", TextCompare: true) != 0)
				{
					val6.Cells[0, 5].TextString = mFiacao[iIndice].Secao12.ToString() + ", " + mFiacao[iIndice].Secao34.ToString();
				}
				val6.Cells[0, 6].TextString = mFiacao[iIndice].Cor12.ToString();
				if (Operators.CompareString(mFiacao[iIndice].Cor34.ToString(), "", TextCompare: true) != 0)
				{
					val6.Cells[0, 6].TextString = mFiacao[iIndice].Cor12.ToString() + ", " + mFiacao[iIndice].Cor34.ToString();
				}
				val6.Cells[0, 7].TextString = mFiacao[iIndice].Pagina12.ToString();
				if (Operators.CompareString(mFiacao[iIndice].Pagina34.ToString(), "", TextCompare: true) != 0)
				{
					val6.Cells[0, 7].TextString = mFiacao[iIndice].Pagina12.ToString() + ", " + mFiacao[iIndice].Pagina34.ToString();
				}
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				((BlockReference)val6).Position = position;
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
						if (val9 != null)
						{
							((Entity)val9).ColorIndex = ConfRelFiacao.CorTexto;
							((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
							if (Operators.CompareString(val9.Text, "##B##", TextCompare: true) != 0)
							{
								val5.AppendEntity((Entity)(object)val9);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								Entity Ent2 = (Entity)(object)val9;
								XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
							}
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
							XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
						}
					}
					finally
					{
						((IDisposable)val10)?.Dispose();
					}
					((DisposableWrapper)Ent).Dispose();
				}
				pt = new Point3d(pt.X, pt.Y - ConfRelFiacao.AlturaDoBloco, 0.0);
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

	public static void _BCriaTabelaFiacaoBorne(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, DeclaracoesFiacao.structureRelFiacao[] mFiacao, int iIndice, ref double YInicio, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel, ref bool bTituloTag, double dalturaBorne)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected Obj, but got Unknown
		//IL_105d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Expected Obj, but got Unknown
		//IL_1090: Unknown result type (might be due to invalid IL or missing references)
		//IL_110c: Unknown result type (might be due to invalid IL or missing references)
		//IL_112e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1149: Unknown result type (might be due to invalid IL or missing references)
		//IL_1172: Unknown result type (might be due to invalid IL or missing references)
		//IL_1177: Unknown result type (might be due to invalid IL or missing references)
		//IL_117b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1180: Unknown result type (might be due to invalid IL or missing references)
		//IL_1195: Unknown result type (might be due to invalid IL or missing references)
		//IL_119a: Unknown result type (might be due to invalid IL or missing references)
		//IL_119e: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11de: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1200: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected Obj, but got Unknown
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_1235: Unknown result type (might be due to invalid IL or missing references)
		//IL_123c: Expected Obj, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Expected Obj, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1286: Unknown result type (might be due to invalid IL or missing references)
		//IL_143d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1444: Expected Obj, but got Unknown
		//IL_104e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected Obj, but got Unknown
		//IL_12dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_148d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1492: Unknown result type (might be due to invalid IL or missing references)
		//IL_1496: Unknown result type (might be due to invalid IL or missing references)
		//IL_0548: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Expected Obj, but got Unknown
		//IL_0583: Unknown result type (might be due to invalid IL or missing references)
		//IL_0588: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_039a: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_0439: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Unknown result type (might be due to invalid IL or missing references)
		//IL_0651: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d7: Expected Obj, but got Unknown
		//IL_06e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_172e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1749: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_071d: Expected Obj, but got Unknown
		//IL_179b: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a2: Expected Obj, but got Unknown
		//IL_17ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0817: Unknown result type (might be due to invalid IL or missing references)
		//IL_081e: Expected Obj, but got Unknown
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e8: Expected Obj, but got Unknown
		//IL_07be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0955: Unknown result type (might be due to invalid IL or missing references)
		//IL_0974: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Expected Obj, but got Unknown
		//IL_0a04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1832: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a40: Expected Obj, but got Unknown
		//IL_1889: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef4: Unknown result type (might be due to invalid IL or missing references)
		double x = pt.X;
		double y = pt.Y;
		Point3d val = new Point3d(pt.X, pt.Y, 0.0);
		DocumentLock val2 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val4 = (TextStyleTable)val3.GetObject(database.TextStyleTableId, (OpenMode)0);
					_ = ((SymbolTable)val4)[ConfRelFiacao.sFonte];
					DBObjectCollection val5 = new DBObjectCollection();
					BlockTable val6 = (BlockTable)val3.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val7 = (BlockTableRecord)val3.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1);
					double num = 0.0;
					bool flag = false;
					Extents3d value;
					Point3d val10;
					if (Operators.CompareString(sTipoRelatorio, "R", TextCompare: true) == 0)
					{
						Table val8 = new Table();
						((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
						val8.SetSize(1, 1);
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							val8.SetSize(2, 1);
						}
						val8.GenerateLayout();
						val8.RecomputeTableBlock(true);
						Point3d position = (((BlockReference)val8).Position = new Point3d(pt.X, pt.Y, 0.0));
						val8.Columns[0].Width = dLarguraDoBloco * 0.04;
						val8.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						((CellRange)val8.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						val8.Cells[0, 0].TextString = "o";
						((CellRange)val8.Cells[0, 0]).Alignment = (CellAlignment)5;
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							((CellRange)val8.Cells[1, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						}
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							val8.Cells[1, 0].TextString = "o";
						}
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							((CellRange)val8.Cells[1, 0]).Alignment = (CellAlignment)5;
						}
						((BlockReference)val8).Position = position;
						((Entity)val8).ColorIndex = ConfRelFiacao.CorLinha;
						DeclaracoesGeral.bAnularEventos = true;
						val8.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						val8.GenerateLayout();
						val7.AppendEntity((Entity)(object)val8);
						DeclaracoesGeral.bAnularEventos = true;
						val3.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
						val8.RecomputeTableBlock(true);
						value = ((Drawable)val8).Bounds.Value;
						val10 = value.MaxPoint;
						y = val10.Y;
						value = ((Drawable)val8).Bounds.Value;
						val10 = value.MaxPoint;
						x = val10.X;
						value = ((Drawable)val8).Bounds.Value;
						val10 = value.MinPoint;
						num = val10.X;
						value = ((Drawable)val8).Bounds.Value;
						val10 = value.MinPoint;
						YInicio = val10.Y;
						DBObjectCollection val11 = new DBObjectCollection();
						DeclaracoesGeral.bAnularEventos = true;
						val8.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						((Entity)val8).Explode(val11);
						((DBObject)val8).Erase();
						foreach (Entity item in val11)
						{
							Entity Ent = item;
							MText val12 = (MText)(object)((Ent is MText) ? Ent : null);
							try
							{
								if (val12 != null)
								{
									((Entity)val12).ColorIndex = ConfRelFiacao.CorTexto;
									((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
									value = ((Drawable)val12).Bounds.Value;
									val10 = value.MinPoint;
									double x2 = val10.X;
									value = ((Drawable)val12).Bounds.Value;
									val10 = value.MaxPoint;
									double x3 = val10.X;
									value = ((Drawable)val12).Bounds.Value;
									val10 = value.MinPoint;
									double num2 = x2 + (x3 - val10.X) / 2.0;
									value = ((Drawable)val12).Bounds.Value;
									val10 = value.MinPoint;
									double y2 = val10.Y;
									value = ((Drawable)val12).Bounds.Value;
									val10 = value.MaxPoint;
									double y3 = val10.Y;
									value = ((Drawable)val12).Bounds.Value;
									val10 = value.MinPoint;
									double num3 = y2 + (y3 - val10.Y) / 2.0;
									new Point3d(num2, num3, 0.0);
									if (Operators.CompareString(val12.Text.ToUpper(), "O", TextCompare: true) == 0)
									{
										val12.Contents = "";
									}
									val7.AppendEntity((Entity)(object)val12);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
									Entity Ent2 = (Entity)(object)val12;
									XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
								}
							}
							finally
							{
								((IDisposable)val12)?.Dispose();
							}
							Line val13 = (Line)(object)((Ent is Line) ? Ent : null);
							try
							{
								if (val13 != null)
								{
									Ent.Layer = DeclaracoesGeral.ativo.Pagina;
									val7.AppendEntity(Ent);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
									XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
								}
							}
							finally
							{
								((IDisposable)val13)?.Dispose();
							}
							((DisposableWrapper)Ent).Dispose();
						}
						Table val14 = new Table();
						((Entity)val14).Layer = DeclaracoesGeral.ativo.Pagina;
						val14.SetSize(1, 1);
						val14.GenerateLayout();
						val14.RecomputeTableBlock(true);
						position = (((BlockReference)val14).Position = new Point3d(x, y, 0.0));
						val14.Columns[0].Width = dLarguraDoBloco * 0.07;
						val14.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							val14.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
						}
						((CellRange)val14.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						val14.Cells[0, 0].TextString = mFiacao[iIndice].Terminal.ToString();
						((CellRange)val14.Cells[0, 0]).Alignment = (CellAlignment)5;
						((BlockReference)val14).Position = position;
						((Entity)val14).ColorIndex = ConfRelFiacao.CorLinha;
						DeclaracoesGeral.bAnularEventos = true;
						val14.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						val14.GenerateLayout();
						val7.AppendEntity((Entity)(object)val14);
						DeclaracoesGeral.bAnularEventos = true;
						val3.AddNewlyCreatedDBObject((DBObject)(object)val14, true);
						val14.RecomputeTableBlock(true);
						value = ((Drawable)val14).Bounds.Value;
						val10 = value.MaxPoint;
						y = val10.Y;
						value = ((Drawable)val14).Bounds.Value;
						val10 = value.MaxPoint;
						x = val10.X;
						DBObjectCollection val16 = new DBObjectCollection();
						DeclaracoesGeral.bAnularEventos = true;
						val14.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						((Entity)val14).Explode(val16);
						((DBObject)val14).Erase();
						foreach (Entity item2 in val16)
						{
							Entity Ent3 = item2;
							MText val17 = (MText)(object)((Ent3 is MText) ? Ent3 : null);
							try
							{
								if (val17 != null)
								{
									((Entity)val17).ColorIndex = ConfRelFiacao.CorTexto;
									((Entity)val17).Layer = DeclaracoesGeral.ativo.Pagina;
									if (Operators.CompareString(val17.Text, "##B##", TextCompare: true) != 0)
									{
										val7.AppendEntity((Entity)(object)val17);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val17, true);
										Entity Ent2 = (Entity)(object)val17;
										XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
									}
								}
							}
							finally
							{
								((IDisposable)val17)?.Dispose();
							}
							Line val18 = (Line)(object)((Ent3 is Line) ? Ent3 : null);
							try
							{
								if (val18 != null)
								{
									Ent3.Layer = DeclaracoesGeral.ativo.Pagina;
									val7.AppendEntity(Ent3);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)Ent3, true);
									XDataRelatorio.GravarXDataFiacao(ref Ent3, sTipoRelatorio, iPainel);
								}
							}
							finally
							{
								((IDisposable)val18)?.Dispose();
							}
							((DisposableWrapper)Ent3).Dispose();
						}
						Table val19 = new Table();
						((Entity)val19).Layer = DeclaracoesGeral.ativo.Pagina;
						val19.SetSize(1, 1);
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							val19.SetSize(2, 1);
						}
						val19.GenerateLayout();
						val19.RecomputeTableBlock(true);
						position = (((BlockReference)val19).Position = new Point3d(x, y, 0.0));
						val19.Columns[0].Width = dLarguraDoBloco * 0.04;
						val19.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						((CellRange)val19.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						val19.Cells[0, 0].TextString = "o";
						((CellRange)val19.Cells[0, 0]).Alignment = (CellAlignment)5;
						Color backgroundColor = Color.FromColorIndex((ColorMethod)194, (short)3);
						((CellRange)val19.Cells[0, 0]).BackgroundColor = backgroundColor;
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							((CellRange)val19.Cells[1, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						}
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							val19.Cells[1, 0].TextString = "b";
						}
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							((CellRange)val19.Cells[1, 0]).Alignment = (CellAlignment)5;
						}
						((BlockReference)val19).Position = position;
						((Entity)val19).ColorIndex = ConfRelFiacao.CorLinha;
						DeclaracoesGeral.bAnularEventos = true;
						val19.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						val19.GenerateLayout();
						val7.AppendEntity((Entity)(object)val19);
						DeclaracoesGeral.bAnularEventos = true;
						val3.AddNewlyCreatedDBObject((DBObject)(object)val19, true);
						val19.RecomputeTableBlock(true);
						value = ((Drawable)val19).Bounds.Value;
						val10 = value.MaxPoint;
						y = val10.Y;
						value = ((Drawable)val19).Bounds.Value;
						val10 = value.MaxPoint;
						x = val10.X;
						DBObjectCollection val21 = new DBObjectCollection();
						DeclaracoesGeral.bAnularEventos = true;
						val19.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						((Entity)val19).Explode(val21);
						((DBObject)val19).Erase();
						foreach (Entity item3 in val21)
						{
							Entity Ent4 = item3;
							MText val22 = (MText)(object)((Ent4 is MText) ? Ent4 : null);
							try
							{
								if (val22 != null)
								{
									((Entity)val22).ColorIndex = ConfRelFiacao.CorTexto;
									((Entity)val22).Layer = DeclaracoesGeral.ativo.Pagina;
									value = ((Drawable)val22).Bounds.Value;
									val10 = value.MinPoint;
									double x4 = val10.X;
									value = ((Drawable)val22).Bounds.Value;
									val10 = value.MaxPoint;
									double x5 = val10.X;
									value = ((Drawable)val22).Bounds.Value;
									val10 = value.MinPoint;
									double num4 = x4 + (x5 - val10.X) / 2.0;
									value = ((Drawable)val22).Bounds.Value;
									val10 = value.MinPoint;
									double y4 = val10.Y;
									value = ((Drawable)val22).Bounds.Value;
									val10 = value.MaxPoint;
									double y5 = val10.Y;
									value = ((Drawable)val22).Bounds.Value;
									val10 = value.MinPoint;
									double num5 = y4 + (y5 - val10.Y) / 2.0;
									Point3d pt2 = new Point3d(num4, num5, 0.0);
									if ((Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) == 0) | (Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0))
									{
										if (mFiacao[iIndice].TipoBorne == 0)
										{
											if ((Operators.CompareString(mFiacao[iIndice].Jumper, "U", TextCompare: true) == 0) | (Operators.CompareString(mFiacao[iIndice].Jumper, "T", TextCompare: true) == 0))
											{
												Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
											}
											if (Operators.CompareString(mFiacao[iIndice].Jumper, "UD", TextCompare: true) == 0)
											{
												Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
												Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
											}
											if ((Operators.CompareString(mFiacao[iIndice].Jumper, "D", TextCompare: true) == 0) | (Operators.CompareString(mFiacao[iIndice].Jumper, "T", TextCompare: true) == 0))
											{
												Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
											}
										}
										if (mFiacao[iIndice].TipoBorne == 1)
										{
											if (Operators.CompareString(mFiacao[iIndice].Jumper, "D", TextCompare: true) == 0 && Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0)
											{
												Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
											}
											if (Operators.CompareString(mFiacao[iIndice].Jumper, "UD", TextCompare: true) == 0)
											{
												if (Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) == 0)
												{
													Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
													Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
												}
												if (Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0)
												{
													Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
													Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt2, ConfRelFiacao.AlturaDoBloco, dLarguraDoBloco * 0.04, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
												}
											}
											if (Operators.CompareString(mFiacao[iIndice].Jumper, "U", TextCompare: true) == 0 && Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) != 0)
											{
											}
										}
									}
									if ((Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) == 0) | (Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0))
									{
										val22.Contents = "";
									}
								}
							}
							finally
							{
								((IDisposable)val22)?.Dispose();
							}
							Line val23 = (Line)(object)((Ent4 is Line) ? Ent4 : null);
							try
							{
								if (val23 != null)
								{
									Ent4.Layer = DeclaracoesGeral.ativo.Pagina;
									val7.AppendEntity(Ent4);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)Ent4, true);
									XDataRelatorio.GravarXDataFiacao(ref Ent4, sTipoRelatorio, iPainel);
								}
							}
							finally
							{
								((IDisposable)val23)?.Dispose();
							}
							((DisposableWrapper)Ent4).Dispose();
						}
						flag = true;
					}
					else
					{
						Table val24 = new Table();
						((Entity)val24).Layer = DeclaracoesGeral.ativo.Pagina;
						val24.SetSize(1, 1);
						val24.GenerateLayout();
						val24.RecomputeTableBlock(true);
						((BlockReference)val24).Position = pt;
						val24.Columns[0].Width = dLarguraDoBloco * 0.15;
						val24.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						((CellRange)val24.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
						val24.Cells[0, 0].TextString = mFiacao[iIndice].Terminal.ToString();
						((BlockReference)val24).Position = pt;
						((Entity)val24).ColorIndex = ConfRelFiacao.CorLinha;
						DeclaracoesGeral.bAnularEventos = true;
						val24.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						val24.GenerateLayout();
						val7.AppendEntity((Entity)(object)val24);
						DeclaracoesGeral.bAnularEventos = true;
						val3.AddNewlyCreatedDBObject((DBObject)(object)val24, true);
						val24.RecomputeTableBlock(true);
						value = ((Drawable)val24).Bounds.Value;
						val10 = value.MaxPoint;
						x = val10.X;
						value = ((Drawable)val24).Bounds.Value;
						val10 = value.MaxPoint;
						y = val10.Y;
						value = ((Drawable)val24).Bounds.Value;
						val10 = value.MinPoint;
						num = val10.X;
						value = ((Drawable)val24).Bounds.Value;
						val10 = value.MinPoint;
						YInicio = val10.Y;
						DeclaracoesGeral.bAnularEventos = true;
						val24.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						((Entity)val24).Explode(val5);
						((DBObject)val24).Erase();
						foreach (Entity item4 in val5)
						{
							Entity Ent5 = item4;
							MText val25 = (MText)(object)((Ent5 is MText) ? Ent5 : null);
							try
							{
								if (val25 != null)
								{
									((Entity)val25).ColorIndex = ConfRelFiacao.CorTexto;
									((Entity)val25).Layer = DeclaracoesGeral.ativo.Pagina;
									if (Operators.CompareString(val25.Text, "##B##", TextCompare: true) != 0)
									{
										val7.AppendEntity((Entity)(object)val25);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val25, true);
										Entity Ent2 = (Entity)(object)val25;
										XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
									}
								}
							}
							finally
							{
								((IDisposable)val25)?.Dispose();
							}
							Line val26 = (Line)(object)((Ent5 is Line) ? Ent5 : null);
							try
							{
								if (val26 != null)
								{
									Ent5.Layer = DeclaracoesGeral.ativo.Pagina;
									val7.AppendEntity(Ent5);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)Ent5, true);
									XDataRelatorio.GravarXDataFiacao(ref Ent5, sTipoRelatorio, iPainel);
								}
							}
							finally
							{
								((IDisposable)val26)?.Dispose();
							}
							((DisposableWrapper)Ent5).Dispose();
						}
						if (bTituloTag)
						{
							goto IL_1aea;
						}
						flag = true;
					}
					if (flag)
					{
						Table val27 = new Table();
						((Entity)val27).Layer = DeclaracoesGeral.ativo.Pagina;
						val27.SetSize(1, 7);
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							val27.SetSize(2, 7);
						}
						val27.GenerateLayout();
						val27.RecomputeTableBlock(true);
						Point3d position = (((BlockReference)val27).Position = new Point3d(x, y, 0.0));
						val27.Columns[0].Width = dLarguraDoBloco * 0.14;
						val27.Columns[1].Width = dLarguraDoBloco * 0.14;
						val27.Columns[2].Width = dLarguraDoBloco * 0.14;
						val27.Columns[3].Width = dLarguraDoBloco * 0.14;
						val27.Columns[4].Width = dLarguraDoBloco * 0.11;
						val27.Columns[5].Width = dLarguraDoBloco * 0.09;
						val27.Columns[6].Width = dLarguraDoBloco * 0.09;
						val27.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						int num6 = 0;
						do
						{
							((CellRange)val27.Cells[0, num6]).TextHeight = ConfRelFiacao.TamanhoFonte;
							((CellRange)val27.Cells[0, num6]).Alignment = (CellAlignment)5;
							num6++;
						}
						while (num6 <= 6);
						if (mFiacao[iIndice].TipoBorne == 1)
						{
							int num7 = 0;
							do
							{
								((CellRange)val27.Cells[1, num7]).TextHeight = ConfRelFiacao.TamanhoFonte;
								((CellRange)val27.Cells[1, num7]).Alignment = (CellAlignment)5;
								num7++;
							}
							while (num7 <= 6);
						}
						val27.Cells[0, 0].TextString = mFiacao[iIndice].Disp1.ToString();
						val27.Cells[0, 1].TextString = mFiacao[iIndice].Term1.ToString();
						val27.Cells[0, 2].TextString = mFiacao[iIndice].Disp2.ToString();
						val27.Cells[0, 3].TextString = mFiacao[iIndice].Term2.ToString();
						val27.Cells[0, 4].TextString = mFiacao[iIndice].Secao12.ToString();
						val27.Cells[0, 5].TextString = mFiacao[iIndice].Cor12.ToString();
						val27.Cells[0, 6].TextString = mFiacao[iIndice].Pagina12.ToString();
						if (mFiacao[iIndice].TipoBorne == 1 && iIndice <= Information.UBound(mFiacao))
						{
							val27.Cells[1, 0].TextString = mFiacao[iIndice].Disp3.ToString();
							val27.Cells[1, 1].TextString = mFiacao[iIndice].Term3.ToString();
							val27.Cells[1, 2].TextString = mFiacao[iIndice].Disp4.ToString();
							val27.Cells[1, 3].TextString = mFiacao[iIndice].Term4.ToString();
							val27.Cells[1, 4].TextString = mFiacao[iIndice].Secao34.ToString();
							val27.Cells[1, 5].TextString = mFiacao[iIndice].Cor34.ToString();
							val27.Cells[1, 6].TextString = mFiacao[iIndice].Pagina34.ToString();
						}
						val27.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						((BlockReference)val27).Position = position;
						y = 0.0;
						x = 0.0;
						((Entity)val27).ColorIndex = ConfRelFiacao.CorLinha;
						DeclaracoesGeral.bAnularEventos = true;
						val27.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						val27.GenerateLayout();
						val7.AppendEntity((Entity)(object)val27);
						if (val27.Height != ConfRelFiacao.AlturaDoBloco)
						{
							int num8 = 5;
							do
							{
								((CellRange)val27.Cells[0, num8]).TextHeight = ConfRelFiacao.TamanhoFonte * 0.9;
								num8++;
							}
							while (num8 <= 5);
							val27.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						}
						DeclaracoesGeral.bAnularEventos = true;
						val3.AddNewlyCreatedDBObject((DBObject)(object)val27, true);
						val27.RecomputeTableBlock(true);
						((DBObject)val27).UpgradeOpen();
						val27.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
						x = num;
						y = YInicio;
						DBObjectCollection val29 = new DBObjectCollection();
						DeclaracoesGeral.bAnularEventos = true;
						val27.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						((Entity)val27).Explode(val29);
						((DBObject)val27).Erase();
						foreach (Entity item5 in val29)
						{
							Entity Ent6 = item5;
							MText val30 = (MText)(object)((Ent6 is MText) ? Ent6 : null);
							try
							{
								if (val30 != null)
								{
									((Entity)val30).ColorIndex = ConfRelFiacao.CorTexto;
									((Entity)val30).Layer = DeclaracoesGeral.ativo.Pagina;
									if (Operators.CompareString(val30.Text, "##B##", TextCompare: true) != 0)
									{
										val7.AppendEntity((Entity)(object)val30);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val30, true);
										Entity Ent2 = (Entity)(object)val30;
										XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
									}
								}
							}
							finally
							{
								((IDisposable)val30)?.Dispose();
							}
							Line val31 = (Line)(object)((Ent6 is Line) ? Ent6 : null);
							try
							{
								if (val31 != null)
								{
									Ent6.Layer = DeclaracoesGeral.ativo.Pagina;
									val7.AppendEntity(Ent6);
									DeclaracoesGeral.bAnularEventos = true;
									val3.AddNewlyCreatedDBObject((DBObject)(object)Ent6, true);
									XDataRelatorio.GravarXDataFiacao(ref Ent6, sTipoRelatorio, iPainel);
									double y6 = pt.Y;
									val10 = val31.StartPoint;
									bool flag2 = y6 == val10.Y;
									val10 = val31.StartPoint;
									double y7 = val10.Y;
									val10 = val31.EndPoint;
									if (flag2 & (y7 == val10.Y))
									{
										((DBObject)val31).Erase();
									}
								}
							}
							finally
							{
								((IDisposable)val31)?.Dispose();
							}
							((DisposableWrapper)Ent6).Dispose();
						}
					}
					pt = new Point3d(val.X, val.Y - dalturaBorne, 0.0);
					goto IL_1aea;
					IL_1aea:
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val3.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
		}
	}

	public static void CriaTituloDaTabelaFiacaoDispBorne(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, DeclaracoesFiacao.structureRelFiacao[] mFiacao, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel, string sValor1, string sValor2, string sDestino1, string sDestino2)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		Point3d val = pt;
		CriaTituloDaTabelaFiacaoDispBorneParte1(sTipoRelatorio, dLarguraDoBloco, ref pt, ConfRelFiacao, iPainel, sValor1, sValor2);
		CriaTituloDaTabelaFiacaoDispBorneParte2(sTipoRelatorio, dLarguraDoBloco, ref pt, mFiacao, ConfRelFiacao, iPainel);
		Point3d pt2 = pt;
		Point3d pt3 = new Point3d(pt.X, pt.Y - ConfRelFiacao.AlturaDoBloco, 0.0);
		CriaTituloDaTabelaFiacaoDispBorneParte3(sTipoRelatorio, dLarguraDoBloco, ref pt2, ConfRelFiacao, iPainel, sDestino1, sDestino2);
		Point3d pt4 = pt2;
		CriaTituloDaTabelaFiacaoDispBorneParte4(sTipoRelatorio, dLarguraDoBloco, ref pt3, mFiacao, ConfRelFiacao, iPainel);
		CriaTituloDaTabelaFiacaoDispBorneParte5(sTipoRelatorio, dLarguraDoBloco, ref pt4, mFiacao, ConfRelFiacao, iPainel);
		pt = new Point3d(val.X, pt3.Y, 0.0);
	}

	public static void CriaTituloDaTabelaFiacaoDispBorneParte1(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel, string sValor1, string sValor2)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected Obj, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
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
				val6.SetSize(1, 2);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco * 0.15;
				val6.Columns[1].Width = dLarguraDoBloco * 0.85;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelFiacao.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 1);
				val6.Cells[0, 0].TextString = sValor1;
				val6.Cells[0, 1].TextString = sValor2;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				((BlockReference)val6).Position = pt;
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
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d minPoint = value.MinPoint;
				double y = minPoint.Y;
				value = ((Drawable)val6).Bounds.Value;
				minPoint = value.MinPoint;
				double x = minPoint.X;
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
							((Entity)val8).ColorIndex = ConfRelFiacao.CorTexto;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							Entity Ent2 = (Entity)(object)val8;
							XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
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
							XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
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

	public static void CriaTituloDaTabelaFiacaoDispBorneParte2(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, DeclaracoesFiacao.structureRelFiacao[] mFiacao, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel)
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
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Expected Obj, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Expected Obj, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
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
				val6.SetSize(1, 1);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco * 0.15;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelFiacao.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 0);
				val6.Cells[0, 0].TextString = mFiacao[0].Terminal;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
				((BlockReference)val6).Position = pt;
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
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
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
							((Entity)val8).ColorIndex = ConfRelFiacao.CorTexto;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							Entity Ent2 = (Entity)(object)val8;
							XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
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
							XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
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

	public static void CriaTituloDaTabelaFiacaoDispBorneParte3(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel, string sDestino1, string sDestino2)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Obj, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Expected Obj, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Unknown result type (might be due to invalid IL or missing references)
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
				val6.SetSize(1, 2);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco * 0.28;
				val6.Columns[1].Width = dLarguraDoBloco * 0.28;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelFiacao.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 1);
				val6.Cells[0, 0].TextString = sDestino1;
				val6.Cells[0, 1].TextString = sDestino2;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				((BlockReference)val6).Position = pt;
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
							((Entity)val8).ColorIndex = ConfRelFiacao.CorTexto;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							Entity Ent2 = (Entity)(object)val8;
							XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
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
							XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
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

	public static void CriaTituloDaTabelaFiacaoDispBorneParte4(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, DeclaracoesFiacao.structureRelFiacao[] mFiacao, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel)
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
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected Obj, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Expected Obj, but got Unknown
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
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
				val6.SetSize(1, 4);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco * 0.14;
				val6.Columns[1].Width = dLarguraDoBloco * 0.14;
				val6.Columns[2].Width = dLarguraDoBloco * 0.14;
				val6.Columns[3].Width = dLarguraDoBloco * 0.14;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelFiacao.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 3);
				val6.Cells[0, 0].TextString = mFiacao[0].Disp1;
				val6.Cells[0, 1].TextString = mFiacao[0].Term1;
				val6.Cells[0, 2].TextString = mFiacao[0].Disp2;
				val6.Cells[0, 3].TextString = mFiacao[0].Term2;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
				((BlockReference)val6).Position = pt;
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
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d minPoint = value.MinPoint;
				double y = minPoint.Y;
				value = ((Drawable)val6).Bounds.Value;
				minPoint = value.MinPoint;
				double x = minPoint.X;
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
							((Entity)val8).ColorIndex = ConfRelFiacao.CorTexto;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							Entity Ent2 = (Entity)(object)val8;
							XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
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
							XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
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

	public static void CriaTituloDaTabelaFiacaoDispBorneParte5(string sTipoRelatorio, double dLarguraDoBloco, ref Point3d pt, DeclaracoesFiacao.structureRelFiacao[] mFiacao, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel)
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
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected Obj, but got Unknown
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Expected Obj, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
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
				val6.SetSize(1, 3);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				((BlockReference)val6).Position = pt;
				val6.Columns[0].Width = dLarguraDoBloco * 0.11;
				val6.Columns[1].Width = dLarguraDoBloco * 0.09;
				val6.Columns[2].Width = dLarguraDoBloco * 0.09;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
				int num = 0;
				do
				{
					((CellRange)val6.Cells[0, num]).TextHeight = ConfRelFiacao.TamanhoFonte;
					((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
					num = checked(num + 1);
				}
				while (num <= 2);
				val6.Cells[0, 0].TextString = mFiacao[0].Secao12;
				val6.Cells[0, 1].TextString = mFiacao[0].Cor12;
				val6.Cells[0, 2].TextString = mFiacao[0].Pagina12;
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
				((BlockReference)val6).Position = pt;
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
				val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d minPoint = value.MinPoint;
				double y = minPoint.Y;
				value = ((Drawable)val6).Bounds.Value;
				minPoint = value.MinPoint;
				double x = minPoint.X;
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
							((Entity)val8).ColorIndex = ConfRelFiacao.CorTexto;
							((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
							val5.AppendEntity((Entity)(object)val8);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
							Entity Ent2 = (Entity)(object)val8;
							XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
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
							XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
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

	public static void ApagaRelatorioDeplaquetas(ref string sTipoRelatotio, int iPainel)
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

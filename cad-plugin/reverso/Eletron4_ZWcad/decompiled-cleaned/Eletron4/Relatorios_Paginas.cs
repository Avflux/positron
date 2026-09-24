using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Relatorios_Paginas
{
	public static object[,] mIndice;

	public static void InsereIndiceDePaginas(DeclaracoesGeral.ConfRelatorioIndice IndicePg, bool bPg, bool bAlt, bool bUnidade, bool bPaginasReserva, string sReserva)
	{
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_075f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Unknown result type (might be due to invalid IL or missing references)
		if (Pagina.checaCapa(DeclaracoesGeral.ativo.Pagina))
		{
			return;
		}
		string pagina = DeclaracoesGeral.ativo.Pagina;
		checked
		{
			try
			{
				Pagina.OrdenaMatrizPaginas();
				Pagina.capturaTitulos();
				DeclaracoesGeral.Reguas RH = default;
				XDataGeral.LeXDataReguaH(ref RH);
				mIndice = new object[9, 1];
				mIndice[0, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 378]);
				if (IndicePg.QuantColunas > 2)
				{
					mIndice[0, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 379]);
				}
				mIndice[1, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 380]);
				mIndice[2, 0] = "PÁGINA NUMERICA";
				mIndice[3, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 381]);
				mIndice[4, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 381]);
				mIndice[5, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 381]);
				mIndice[6, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 381]);
				mIndice[7, 0] = DeclaracoesGeral.mMensagem[1, 10].ToString().ToUpper();
				mIndice[8, 0] = DeclaracoesGeral.mMensagem[1, 11].ToString().ToUpper();
				if (IndicePg.QuantColunas > 2)
				{
					mIndice[7, 0] = "ALT";
				}
				if (!bPg)
				{
					mIndice[7, 0] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 378]);
				}
				int num = Information.UBound(DeclaracoesGeral.mTitulos, 2);
				for (int i = 1; i <= num; i++)
				{
					double num2 = Pagina.calculaPaginaDecimal(DeclaracoesGeral.mTitulos[0, i].ToString());
					int num3 = 0;
					int num4 = 1;
					do
					{
						if (Pagina.checaCapa(Conversions.ToString(DeclaracoesGeral.mTitulos[0, i])))
						{
							DeclaracoesGeral.mTitulos[num4, i] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 377]);
						}
						if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mTitulos[num4, i], null, TextCompare: true))
						{
							DeclaracoesGeral.mTitulos[num4, i] = " ";
							num3++;
						}
						num4++;
					}
					while (num4 <= 4);
					int num5 = Information.UBound(mIndice, 2) + 1;
					mIndice = (object[,])Utils.CopyArray(mIndice, new object[9, num5 + 1]);
					mIndice[0, num5] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mTitulos[0, i]);
					mIndice[1, num5] = " ";
					mIndice[2, num5] = num2;
					mIndice[3, num5] = " ";
					if (IndicePg.Tit1)
					{
						mIndice[3, num5] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mTitulos[1, i]);
					}
					mIndice[4, num5] = " ";
					if (IndicePg.Tit2)
					{
						mIndice[4, num5] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mTitulos[2, i]);
					}
					mIndice[5, num5] = " ";
					if (IndicePg.Tit3)
					{
						mIndice[5, num5] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mTitulos[3, i]);
					}
					mIndice[6, num5] = " ";
					if (IndicePg.Tit4)
					{
						mIndice[6, num5] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mTitulos[4, i]);
					}
					mIndice[7, num5] = " ";
					if (bAlt)
					{
						mIndice[7, num5] = clsTextos.TiraNothing(Conversions.ToString(DeclaracoesGeral.mTitulos[6, i]));
					}
					mIndice[8, num5] = " ";
					if (bUnidade)
					{
						mIndice[8, num5] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mTitulos[5, i]);
					}
					int num6 = 1;
					do
					{
						int num7 = 3;
						do
						{
							if (Operators.CompareString(mIndice[num7, num5].ToString().Trim(), "", TextCompare: true) == 0)
							{
								mIndice[num7, num5] = RuntimeHelpers.GetObjectValue(mIndice[num7 + 1, num5]);
								mIndice[num7 + 1, num5] = " ";
							}
							num7++;
						}
						while (num7 <= 5);
						num6++;
					}
					while (num6 <= 4);
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(mIndice[3, num5], null, "trim", new object[0], null, null, null), "", TextCompare: true))
					{
						mIndice[3, num5] = "#SEM TITULOS#";
					}
				}
				object obj = mIndice;
				TW3p1Tp15UT(ref obj);
				mIndice = (object[,])obj;
				if (bPaginasReserva)
				{
					obj = mIndice;
					CpIp1JqBYXF(ref obj, sReserva, IndicePg);
					mIndice = (object[,])obj;
					obj = mIndice;
					TW3p1Tp15UT(ref obj);
					mIndice = (object[,])obj;
				}
				if (IndicePg.bRev)
				{
					Revisao.capturaRevisoesCompletas();
					int num8 = Information.UBound(mIndice, 2);
					for (int j = 1; j <= num8; j++)
					{
						int num9 = Information.UBound(DeclaracoesGeral.mRevCompleta);
						for (int k = 1; k <= num9; k++)
						{
							if (Operators.ConditionalCompareObjectEqual(mIndice[0, j], DeclaracoesGeral.mRevCompleta[k].Pagina, TextCompare: true))
							{
								mIndice[1, j] = DeclaracoesGeral.mRevCompleta[k].Revisao;
								break;
							}
						}
					}
					Revisao.capturaRevisoesSimplificadas();
					int num10 = Information.UBound(mIndice, 2);
					for (int l = 1; l <= num10; l++)
					{
						int num11 = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
						for (int m = 1; m <= num11; m++)
						{
							if (Operators.ConditionalCompareObjectEqual(mIndice[0, l], DeclaracoesGeral.mRevSimplificada[0, m], TextCompare: true) && Operators.ConditionalCompareObjectEqual(mIndice[1, l], "", TextCompare: true))
							{
								mIndice[1, l] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mRevSimplificada[1, m]);
								break;
							}
						}
					}
				}
				if (!bPg && ((DeclaracoesGeral.Conf.incluirColuna == 3) | (DeclaracoesGeral.Conf.incluirColuna == 4) | (DeclaracoesGeral.Conf.incluirColuna == 5)))
				{
					int num12 = Information.UBound(mIndice, 2);
					for (int n = 1; n <= num12; n++)
					{
						int num13 = Information.UBound(DeclaracoesGeral.mTitulos, 2);
						for (int num14 = 1; num14 <= num13; num14++)
						{
							if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(mIndice[0, n], DeclaracoesGeral.mTitulos[0, num14], TextCompare: true), Operators.CompareString(DeclaracoesGeral.mTitulos[6, num14].ToString(), "", TextCompare: true) != 0)))
							{
								mIndice[0, n] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mTitulos[6, num14]);
								break;
							}
						}
					}
				}
				Point3d pti = RH.Pti;
				double num15 = 0.0;
				double num16 = 0.0;
				double num17 = 0.0;
				double num18 = 0.0;
				num18 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
				num18 -= IndicePg.DistEntreColunas * (double)(IndicePg.QuantColunas + 1);
				num18 /= (double)IndicePg.QuantColunas;
				int num19 = 1;
				double num20 = 0.0;
				num20 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - num15 - (double)IndicePg.QuantColunas * num18;
				num20 /= (double)(IndicePg.QuantColunas + 1);
				num15 = pti.X;
				num16 = pti.Y;
				Point3d val = new Point3d(pti.X + num20, pti.Y - IndicePg.AlturaInicial, 0.0);
				Dicionario.CriaTableStyleRelatorios(IndicePg.sFonte);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mIndice, 2);
				DeclaracoesGeral._uscPagina.pbIniciar();
				Pagina.OrdenaMatrizPaginas();
				int num21 = Information.UBound(mIndice, 2);
				int num22 = 0;
				while (num22 <= num21)
				{
					Point3d val2 = val;
					double num23 = num18;
					obj = mIndice;
					LsPp1p0nmF9(val2, num23, ref obj, num22, ref num16, ref num15, ref num17, IndicePg, bPg, bAlt, bUnidade);
					mIndice = (object[,])obj;
					if (num22 != Information.UBound(mIndice, 2))
					{
						val = new Point3d(val.X, num16, 0.0);
						if (Math.Round(num16 - num17 - IndicePg.AlturaDoBloco, 2) < Math.Round(RH.AltBase, 2))
						{
							if (num19 < IndicePg.QuantColunas)
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_07a0;
								}
								val = new Point3d(val.X + num20 + num18, pti.Y - IndicePg.AlturaInicial, 0.0);
								num19++;
							}
							else
							{
								val = new Point3d(pti.X + num20, pti.Y - IndicePg.AlturaInicial, 0.0);
								num19 = 1;
								string pagina2 = Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina);
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_07a0;
								}
								Pagina.AtivaPagina(pagina2);
							}
							if (DeclaracoesGeral.bPararRelatorio)
							{
								goto IL_07a0;
							}
							Point3d val3 = val;
							double num24 = num18;
							obj = mIndice;
							LsPp1p0nmF9(val3, num24, ref obj, 0, ref num16, ref num15, ref num17, IndicePg, bPg, bAlt, bUnidade);
							mIndice = (object[,])obj;
							val = new Point3d(val.X, num16, 0.0);
						}
						DeclaracoesGeral._uscPagina.pbPasso();
					}
					goto IL_07a0;
					IL_07a0:
					if (!DeclaracoesGeral.bPararRelatorio)
					{
						num22++;
						continue;
					}
					break;
				}
				DeclaracoesGeral._uscPagina.pbFim();
				Pagina.AtivaPagina(pagina);
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
		}
	}

	private static void LsPp1p0nmF9(Point3d P_0, double P_1, ref object P_2, int P_3, ref double P_4, ref double P_5, ref double P_6, DeclaracoesGeral.ConfRelatorioIndice P_7, bool P_8, bool P_9, bool P_10)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_066c: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0683: Expected Obj, but got Unknown
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Expected Obj, but got Unknown
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected Obj, but got Unknown
		//IL_06c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0700: Unknown result type (might be due to invalid IL or missing references)
		//IL_0716: Unknown result type (might be due to invalid IL or missing references)
		//IL_071b: Unknown result type (might be due to invalid IL or missing references)
		//IL_071f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0724: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_0792: Unknown result type (might be due to invalid IL or missing references)
		//IL_0799: Expected Obj, but got Unknown
		//IL_07e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a38: Expected Obj, but got Unknown
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a71: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ee: Expected Obj, but got Unknown
		//IL_08ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Expected Obj, but got Unknown
		//IL_08cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d6: Expected Obj, but got Unknown
		//IL_08d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Expected Obj, but got Unknown
		//IL_0924: Unknown result type (might be due to invalid IL or missing references)
		//IL_0944: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				Table val2 = new Table();
				((Entity)val2).Layer = DeclaracoesGeral.ativo.Pagina;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					try
					{
						P_4 = 0.0;
						P_5 = 0.0;
						int num = 0;
						int num2 = 0;
						int num3 = 3;
						do
						{
							if (Operators.CompareString(NewLateBinding.LateIndexGet(P_2, new object[2] { num3, P_3 }, null).ToString().Trim(), "", TextCompare: true) != 0)
							{
								num++;
							}
							num3++;
						}
						while (num3 <= 6);
						if ((P_3 == 0) | Pagina.checaCapa(Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 0, P_3 }, null))))
						{
							num = 1;
						}
						if (num == 0)
						{
							return;
						}
						int num4 = 0;
						if (P_8)
						{
							num4++;
						}
						if (P_9)
						{
							num4++;
						}
						if (P_10)
						{
							num4++;
						}
						if (P_7.bRev)
						{
							num4++;
						}
						num4++;
						val2.SetSize(num, num4);
						val2.GenerateLayout();
						val2.RecomputeTableBlock(true);
						((BlockReference)val2).Position = P_0;
						val2.SetRowHeight(P_7.AlturaDoBloco);
						((Entity)val2).ColorIndex = P_7.CorLinha;
						double num5 = P_7.TamanhoFonte;
						if (P_3 == 0)
						{
							num5 += 0.5;
						}
						double num6 = P_1 * 0.1;
						double num7 = P_1 * 0.13;
						double num8 = P_1 * 0.1;
						double num9 = P_1 * 0.06;
						double num10 = P_1;
						if (num >= 1)
						{
							num2 = 0;
							if (P_8)
							{
								val2.MergeCells(CellRange.Create(val2, 0, num2, num - 1, num2));
								((CellRange)val2.Cells[0, num2]).TextHeight = num5;
								((CellRange)val2.Cells[0, num2]).Alignment = (CellAlignment)5;
								val2.Cells[0, num2].TextString = Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 0, P_3 }, null));
								val2.Columns[num2].Width = num6;
								num10 -= num6;
								num2++;
							}
							if (P_9)
							{
								val2.MergeCells(CellRange.Create(val2, 0, num2, num - 1, num2));
								val2.Cells[0, num2].TextString = Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 7, P_3 }, null));
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateIndexGet(P_2, new object[2] { 7, P_3 }, null), null, "trim", new object[0], null, null, null), "", TextCompare: true) && !P_8)
								{
									val2.Cells[0, num2].TextString = Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 0, P_3 }, null));
								}
								val2.Columns[num2].Width = num7;
								num10 -= num7;
								((CellRange)val2.Cells[0, num2]).TextHeight = num5;
								((CellRange)val2.Cells[0, num2]).Alignment = (CellAlignment)5;
								num2++;
							}
							if (P_10)
							{
								val2.MergeCells(CellRange.Create(val2, 0, num2, num - 1, num2));
								val2.Cells[0, num2].TextString = Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 8, P_3 }, null));
								val2.Columns[num2].Width = num8;
								num10 -= num8;
								((CellRange)val2.Cells[0, num2]).TextHeight = num5;
								((CellRange)val2.Cells[0, num2]).Alignment = (CellAlignment)5;
								num2++;
							}
							if (P_7.bRev)
							{
								val2.MergeCells(CellRange.Create(val2, 0, num2, num - 1, num2));
								((CellRange)val2.Cells[0, num2]).TextHeight = num5;
								((CellRange)val2.Cells[0, num2]).Alignment = (CellAlignment)5;
								val2.Cells[0, num2].TextString = Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2] { 1, P_3 }, null));
								val2.Columns[num2].Width = num9;
								num10 -= num9;
								num2++;
							}
						}
						val2.Columns[num2].Width = num10;
						int num11 = num2;
						int num12 = num - 1;
						for (int i = 0; i <= num12; i++)
						{
							((CellRange)val2.Cells[i, num11]).TextHeight = num5;
							if (P_3 != 0)
							{
								((CellRange)val2.Cells[i, num11]).Alignment = (CellAlignment)4;
							}
							else
							{
								((CellRange)val2.Cells[0, num11]).Alignment = (CellAlignment)5;
							}
							if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(P_2, new object[2]
							{
								i + 3,
								P_3
							}, null), "#SEM TITULOS#", TextCompare: true))
							{
								val2.Cells[i, num11].TextString = Conversions.ToString(NewLateBinding.LateIndexGet(P_2, new object[2]
								{
									i + 3,
									P_3
								}, null));
							}
							else
							{
								val2.Cells[i, num11].TextString = " ";
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						DBObjectCollection val4 = new DBObjectCollection();
						BlockTable val5 = (BlockTable)val3.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
						BlockTableRecord val6 = (BlockTableRecord)val3.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
						val2.GenerateLayout();
						val6.AppendEntity((Entity)(object)val2);
						DeclaracoesGeral.bAnularEventos = true;
						val3.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
						val2.RecomputeTableBlock(true);
						P_6 = val2.Height;
						Extents3d value = ((Drawable)val2).Bounds.Value;
						Point3d val7 = value.MinPoint;
						P_4 = val7.Y;
						value = ((Drawable)val2).Bounds.Value;
						val7 = value.MaxPoint;
						double x = val7.X;
						value = ((Drawable)val2).Bounds.Value;
						val7 = value.MinPoint;
						P_5 = x - val7.X;
						DeclaracoesGeral.bAnularEventos = true;
						val2.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						((Entity)val2).Explode(val4);
						((DBObject)val2).Erase();
						foreach (Entity item in val4)
						{
							Entity val8 = item;
							MText val9 = (MText)(object)((val8 is MText) ? val8 : null);
							if (val9 != null)
							{
								((Entity)val9).ColorIndex = P_7.CorTexto;
								((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
								val6.AppendEntity((Entity)(object)val9);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								bool flag = false;
								string sPG = "";
								if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(P_2, new object[2] { 0, P_3 }, null), val9.Text, TextCompare: true), Operators.CompareObjectEqual(NewLateBinding.LateIndexGet(P_2, new object[2] { 7, P_3 }, null), val9.Text, TextCompare: true))) && Operators.ConditionalCompareObjectNotEqual(val9.Text, DeclaracoesGeral.mMensagem[1, 378], TextCompare: true))
								{
									sPG = val9.Text;
									flag = true;
								}
								if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateIndexGet(P_2, new object[2] { 7, P_3 }, null), val9.Text, TextCompare: true) && Operators.ConditionalCompareObjectNotEqual(val9.Text, DeclaracoesGeral.mMensagem[1, 378], TextCompare: true))
								{
									sPG = val9.Text;
									flag = true;
								}
								if (flag)
								{
									DBObjectCollection val10 = new DBObjectCollection();
									((Entity)val9).Explode(val10);
									foreach (DBObject item2 in val10)
									{
										DBObject val11 = item2;
										Entity val12 = (Entity)val11;
										DBText val13 = (DBText)(object)((val12 is DBText) ? val12 : null);
										if (val13 != null)
										{
											((Entity)val13).ColorIndex = P_7.CorTexto;
											((Entity)val13).Layer = DeclaracoesGeral.ativo.Pagina;
											val6.AppendEntity((Entity)(object)val13);
											val3.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
											object ent = val13;
											XDataRelatorio.GravarXDataIndice(ref ent, P_3, sPG);
											val13 = (DBText)ent;
										}
										((DisposableWrapper)val12).Dispose();
									}
									((DBObject)val9).Erase();
								}
								else
								{
									object ent = val9;
									XDataRelatorio.GravarXDataIndice(ref ent, P_3, sPG);
									val9 = (MText)ent;
								}
							}
							Line val14 = (Line)(object)((val8 is Line) ? val8 : null);
							if (val14 != null)
							{
								val8.Layer = DeclaracoesGeral.ativo.Pagina;
								val6.AppendEntity(val8);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								object ent = val8;
								XDataRelatorio.GravarXDataIndice(ref ent, P_3);
								val8 = (Entity)ent;
								if (P_3 != 0)
								{
									double y = P_0.Y;
									val7 = val14.StartPoint;
									bool flag2 = y == val7.Y;
									val7 = val14.StartPoint;
									double y2 = val7.Y;
									val7 = val14.EndPoint;
									if (flag2 & (y2 == val7.Y))
									{
										((DBObject)val14).Erase();
									}
								}
							}
							((DisposableWrapper)val8).Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val3.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val3.Abort();
						throw;
					}
					finally
					{
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	private static void TW3p1Tp15UT(ref object P_0)
	{
		if (Information.UBound((Array)P_0, 2) < 2 || Information.UBound((Array)P_0, 2) <= 0)
		{
			return;
		}
		checked
		{
			int num = Information.UBound((Array)P_0, 2) - 1;
			for (int i = num; i >= 1; i += -1)
			{
				int num2 = i;
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.ConditionalCompareObjectGreater(NewLateBinding.LateIndexGet(P_0, new object[2] { 2, j }, null), NewLateBinding.LateIndexGet(P_0, new object[2]
					{
						2,
						j + 1
					}, null), TextCompare: true))
					{
						int num3 = 0;
						do
						{
							object objectValue = RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(P_0, new object[2]
							{
								num3,
								j + 1
							}, null));
							NewLateBinding.LateIndexSet(P_0, new object[3]
							{
								num3,
								j + 1,
								NewLateBinding.LateIndexGet(P_0, new object[2] { num3, j }, null)
							}, null);
							NewLateBinding.LateIndexSet(P_0, new object[3] { num3, j, objectValue }, null);
							num3++;
						}
						while (num3 <= 8);
					}
				}
			}
		}
	}

	private static void CpIp1JqBYXF(ref object P_0, string P_1, DeclaracoesGeral.ConfRelatorioIndice P_2)
	{
		if (Information.UBound((Array)P_0, 2) <= 0)
		{
			return;
		}
		List<double> list = new List<double>();
		int num = Conversions.ToInteger(Conversion.Int(RuntimeHelpers.GetObjectValue(NewLateBinding.LateIndexGet(P_0, new object[2]
		{
			2,
			Information.UBound((Array)P_0, 2)
		}, null))));
		int num2 = 0;
		int num3 = num;
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				list.Add(i);
			}
			int num4 = Information.UBound((Array)P_0, 2);
			for (int j = 1; j <= num4; j++)
			{
				if (list.Contains(Conversions.ToDouble(NewLateBinding.LateIndexGet(P_0, new object[2] { 2, j }, null))))
				{
					list.Remove(Conversions.ToDouble(NewLateBinding.LateIndexGet(P_0, new object[2] { 2, j }, null)));
				}
			}
			foreach (double item in list)
			{
				int num5 = (int)Math.Round(item);
				num2 = Information.UBound((Array)P_0, 2) + 1;
				P_0 = Utils.CopyArray((Array)P_0, new object[9, num2 + 1]);
				NewLateBinding.LateIndexSet(P_0, new object[3]
				{
					0,
					num2,
					Pagina.montaNumeroPagina(num5.ToString())
				}, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 1, num2, " " }, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 2, num2, num5 }, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 3, num2, P_1 }, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 4, num2, " " }, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 5, num2, " " }, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 6, num2, " " }, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 7, num2, " " }, null);
				NewLateBinding.LateIndexSet(P_0, new object[3] { 8, num2, " " }, null);
			}
		}
	}

	public static object CapturaOsTextStyle()
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		string[] array = new string[1] { "" };
		_ = Application.DocumentManager.MdiActiveDocument;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
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
			((DisposableWrapper)val).Dispose();
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
		return array;
	}

	public static void ApagaRelatorioDeIndices()
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
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						if (XDataRelatorio.TemOxDataNoRelatorio(ref ent, "INDICE"))
						{
							((DBObject)ent).Erase();
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				BlockReference val5 = null;
				if (DeclaracoesGeral.blockFormatoID.IsValid & !DeclaracoesGeral.blockFormatoID.IsErased)
				{
					DBObject val6 = val2.GetObject(DeclaracoesGeral.blockFormatoID, (OpenMode)0);
					val5 = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
					Caderno.ZEntity(((DBObject)val5).ObjectId);
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

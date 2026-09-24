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

public class Relatorios_PlaquetasDWG
{
	public static void ordenaPlaquetasEletroNorte(ref DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, string sOrdem)
	{
		if (Information.UBound(mPlaquetas) < 2)
		{
			return;
		}
		int num = Information.UBound(mPlaquetas);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				int num2 = Information.UBound(mPlaquetas) - 1;
				int num3 = i;
				for (int j = num2; j >= num3; j += -1)
				{
					if (Operators.CompareString(sOrdem, "ABC", TextCompare: true) != 0)
					{
						if (Operators.CompareString(mPlaquetas[j].Modelo, mPlaquetas[j + 1].Modelo, TextCompare: true) < 0)
						{
							DeclaracoesFiacao.structureRelPlaquetas structureRelPlaquetas = mPlaquetas[j + 1];
							mPlaquetas[j + 1] = mPlaquetas[j];
							mPlaquetas[j] = structureRelPlaquetas;
						}
					}
					else if (Operators.CompareString(mPlaquetas[j].Modelo, mPlaquetas[j + 1].Modelo, TextCompare: true) > 0)
					{
						DeclaracoesFiacao.structureRelPlaquetas structureRelPlaquetas = mPlaquetas[j + 1];
						mPlaquetas[j + 1] = mPlaquetas[j];
						mPlaquetas[j] = structureRelPlaquetas;
					}
				}
			}
		}
	}

	public static void ordenaPlaquetasEletroSul(ref DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, string sTipo)
	{
		ordenaPlaquetasEletroNorte(ref mPlaquetas, sTipo);
		double num = 2.0;
		int num2 = Information.UBound(mPlaquetas);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				try
				{
					if (!Versioned.IsNumeric(mPlaquetas[i].Modelo))
					{
						if (Versioned.IsNumeric(mPlaquetas[i].Modelo))
						{
							continue;
						}
						string text = Strings.Mid(mPlaquetas[i].Modelo, 1, 1);
						string text2 = "0";
						if (Strings.Len(mPlaquetas[i].Modelo) > 1 && Versioned.IsNumeric(text2))
						{
							text2 = Strings.Mid(mPlaquetas[i].Modelo, 2, Strings.Len(mPlaquetas[i].Modelo));
						}
						if (!(!Versioned.IsNumeric(text) & Versioned.IsNumeric(text2)))
						{
							continue;
						}
						if (Operators.CompareString(text, "D", TextCompare: true) != 0)
						{
							if (Strings.Len(mPlaquetas[i].Modelo) <= 1)
							{
								mPlaquetas[i].ordem = Strings.Asc(text) - 64;
							}
							else
							{
								mPlaquetas[i].ordem = (double)(Strings.Asc(text) - 64) + Conversions.ToDouble(text2) / 100.0;
							}
							if (num < mPlaquetas[i].ordem)
							{
								num = mPlaquetas[i].ordem + 1.0;
							}
						}
						else
						{
							mPlaquetas[i].ordem = Conversions.ToDouble(text2) / 100.0;
							if (num < mPlaquetas[i].ordem)
							{
								num = mPlaquetas[i].ordem + 1.0;
							}
						}
						continue;
					}
					mPlaquetas[i].ordem = Conversions.ToDouble(mPlaquetas[i].Modelo);
					num = mPlaquetas[i].ordem + 100.0;
					mPlaquetas[i].ordem = num;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					mPlaquetas[i].ordem = num;
					ProjectData.ClearProjectError();
				}
			}
			if (Information.UBound(mPlaquetas) < 2)
			{
				return;
			}
			int num3 = Information.UBound(mPlaquetas);
			for (int j = 1; j <= num3; j++)
			{
				int num4 = Information.UBound(mPlaquetas) - 1;
				int num5 = j;
				for (int k = num4; k >= num5; k += -1)
				{
					if (mPlaquetas[k].ordem > mPlaquetas[k + 1].ordem)
					{
						DeclaracoesFiacao.structureRelPlaquetas structureRelPlaquetas = mPlaquetas[k + 1];
						mPlaquetas[k + 1] = mPlaquetas[k];
						mPlaquetas[k] = structureRelPlaquetas;
					}
				}
			}
		}
	}

	public static void ordenaPlaquetasCustomizadas(ref DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, string sOrdem)
	{
		sOrdem = sOrdem.ToUpper();
		sOrdem += ";";
		sOrdem = sOrdem.Replace(";;", ";");
		sOrdem = sOrdem.Replace(" ", "");
		string[] array = sOrdem.Split(';');
		int num = Information.UBound(mPlaquetas);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				mPlaquetas[i].ordem = 100.0;
				int num2 = Information.UBound(array);
				for (int j = 0; j <= num2; j++)
				{
					if (Operators.CompareString(mPlaquetas[i].Modelo.ToUpper(), array[j].ToUpper(), TextCompare: true) == 0)
					{
						mPlaquetas[i].ordem = j;
						break;
					}
				}
			}
			if (Information.UBound(mPlaquetas) >= 2)
			{
				int num3 = Information.UBound(mPlaquetas);
				for (int k = 1; k <= num3; k++)
				{
					int num4 = Information.UBound(mPlaquetas) - 1;
					int num5 = k;
					for (int l = num4; l >= num5; l += -1)
					{
						if (mPlaquetas[l].ordem > mPlaquetas[l + 1].ordem)
						{
							DeclaracoesFiacao.structureRelPlaquetas structureRelPlaquetas = mPlaquetas[l + 1];
							mPlaquetas[l + 1] = mPlaquetas[l];
							mPlaquetas[l] = structureRelPlaquetas;
						}
					}
				}
			}
			int num6 = Information.UBound(mPlaquetas);
			for (int m = 1; m <= num6; m++)
			{
				mPlaquetas[m].ordem = m;
			}
		}
	}

	public static void CriaMatrizPlaquetas(DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, frmRelatorio_PlaquetasDWG.ConfigRelatorioPlaquetas ConfP, int iPainel)
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0404: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double dX = 0.0;
		double dY = 0.0;
		double YInicio = 0.0;
		string pag = DeclaracoesGeral.ativo.Pagina;
		double num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num -= ConfP.DistEntreColunas * (double)(ConfP.QuantColunas + 1);
			num /= (double)ConfP.QuantColunas;
			_ = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - dX - (double)ConfP.QuantColunas * num / (double)(ConfP.QuantColunas + 1);
			Point3d pt = new Point3d(RH.Pti.X + ConfP.DistEntreColunas, RH.Pti.Y - ConfP.AlturaInicial, 0.0);
			int iIndiceNumerico = 1;
			int num2 = 1;
			Dicionario.CriaTableStyleRelatorios(ConfP.sFonte, 0.5);
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mPlaquetas);
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num3 = Information.UBound(mPlaquetas);
			int num4 = 0;
			while (num4 <= num3)
			{
				if ((num4 <= 0 || !((Operators.CompareString(mPlaquetas[num4].Desc1.Trim(), "##B##", TextCompare: true) == 0) & (Operators.CompareString(mPlaquetas[num4].Desc2.Trim(), "##B##", TextCompare: true) == 0) & (Operators.CompareString(mPlaquetas[num4].Desc3.Trim(), "##B##", TextCompare: true) == 0))) && (num4 <= 0 || !((Operators.CompareString(mPlaquetas[num4].Desc1.Trim(), "", TextCompare: true) == 0) & (Operators.CompareString(mPlaquetas[num4].Desc2.Trim(), "", TextCompare: true) == 0) & (Operators.CompareString(mPlaquetas[num4].Desc3.Trim(), "", TextCompare: true) == 0))))
				{
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					CriaTabelaPlaqueta(ref iIndiceNumerico, num, pt, mPlaquetas, num4, ref dY, ref dX, ref YInicio, ConfP, iPainel);
					pt = new Point3d(pt.X, dY, 0.0);
					if (dY < RH.AltBase + 1.0 + ConfP.AlturaDoBloco)
					{
						if (num2 != ConfP.QuantColunas)
						{
							pt = new Point3d(dX + ConfP.DistEntreColunas, RH.Pti.Y - ConfP.AlturaInicial, 0.0);
							num2++;
						}
						else if (flag)
						{
							Pagina.OrdenaMatrizPaginas();
							string pag2 = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag2, TextCompare: true) != 0)
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_01d4;
								}
								Pagina.AtivaPagina(pag2);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag2);
							}
							else
							{
								if (DeclaracoesGeral.bPararRelatorio)
								{
									goto IL_01d4;
								}
								if (num4 < Information.UBound(mPlaquetas))
								{
									if (!Pagina.criarUmaNovaPagina())
									{
										break;
									}
									DeclaracoesGeral._uscPagina.CarregaPG();
								}
							}
							pt = new Point3d(RH.Pti.X + ConfP.DistEntreColunas, RH.Pti.Y - ConfP.AlturaInicial, 0.0);
							num2 = 1;
						}
						else
						{
							if (!Pagina.criarUmaNovaPagina())
							{
								break;
							}
							DeclaracoesGeral._uscPagina.CarregaPG();
							pt = new Point3d(RH.Pti.X + ConfP.DistEntreColunas, RH.Pti.Y - ConfP.AlturaInicial, 0.0);
						}
						CriaTabelaPlaqueta(ref iIndiceNumerico, num, pt, mPlaquetas, 0, ref dY, ref dX, ref YInicio, ConfP, iPainel);
						pt = new Point3d(pt.X, dY, 0.0);
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				goto IL_01d4;
				IL_01d4:
				if (!DeclaracoesGeral.bPararRelatorio)
				{
					num4++;
					continue;
				}
				break;
			}
			DeclaracoesGeral._uscPagina.pbFim();
			if (Operators.CompareString(pag, "", TextCompare: true) != 0 && Operators.CompareString(pag, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
			{
				Pagina.AtivaPagina(pag);
				DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
			}
		}
	}

	public static void CriaTabelaPlaqueta(ref int iIndiceNumerico, double dLarguraDoBloco, Point3d pt, DeclaracoesFiacao.structureRelPlaquetas[] mPlaquetas, int iIndice, ref double dY, ref double dX, ref double YInicio, frmRelatorio_PlaquetasDWG.ConfigRelatorioPlaquetas ConfP, int iPainel)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected Obj, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Expected Obj, but got Unknown
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Expected Obj, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_0594: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Unknown result type (might be due to invalid IL or missing references)
		//IL_0615: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0635: Unknown result type (might be due to invalid IL or missing references)
		//IL_063a: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0654: Expected Obj, but got Unknown
		//IL_065d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Unknown result type (might be due to invalid IL or missing references)
		//IL_0699: Expected Obj, but got Unknown
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a7: Expected Obj, but got Unknown
		//IL_08f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0983: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2b: Expected Obj, but got Unknown
		//IL_0a34: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Expected Obj, but got Unknown
		//IL_0a66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Expected Obj, but got Unknown
		//IL_082e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f2: Expected Obj, but got Unknown
		//IL_0af7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afe: Expected Obj, but got Unknown
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_0749: Unknown result type (might be due to invalid IL or missing references)
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Unknown result type (might be due to invalid IL or missing references)
		//IL_077d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d7: Expected Obj, but got Unknown
		//IL_0e10: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6e: Expected Obj, but got Unknown
		//IL_0e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eb3: Expected Obj, but got Unknown
		//IL_1081: Unknown result type (might be due to invalid IL or missing references)
		//IL_1088: Expected Obj, but got Unknown
		//IL_10c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_115b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1191: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_11dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1201: Unknown result type (might be due to invalid IL or missing references)
		//IL_1205: Unknown result type (might be due to invalid IL or missing references)
		//IL_120a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1214: Unknown result type (might be due to invalid IL or missing references)
		//IL_121b: Expected Obj, but got Unknown
		//IL_1224: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee7: Expected Obj, but got Unknown
		//IL_1259: Unknown result type (might be due to invalid IL or missing references)
		//IL_1260: Expected Obj, but got Unknown
		//IL_0f05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0c: Expected Obj, but got Unknown
		//IL_128d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1294: Expected Obj, but got Unknown
		//IL_0f70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1006: Expected Obj, but got Unknown
		//IL_13f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b9: Expected Obj, but got Unknown
		//IL_130b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1310: Unknown result type (might be due to invalid IL or missing references)
		//IL_131b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1320: Unknown result type (might be due to invalid IL or missing references)
		//IL_1344: Unknown result type (might be due to invalid IL or missing references)
		//IL_1349: Unknown result type (might be due to invalid IL or missing references)
		//IL_134d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1358: Unknown result type (might be due to invalid IL or missing references)
		//IL_1397: Unknown result type (might be due to invalid IL or missing references)
		//IL_139e: Expected Obj, but got Unknown
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
					TextStyleTable val4 = (TextStyleTable)val3.GetObject(database.TextStyleTableId, (OpenMode)0);
					_ = ((SymbolTable)val4)[ConfP.sFonte];
					DBObjectCollection val5 = new DBObjectCollection();
					BlockTable val6 = (BlockTable)val3.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val7 = (BlockTableRecord)val3.GetObject(((SymbolTable)val6)[BlockTableRecord.ModelSpace], (OpenMode)1);
					val2.SetSize(1, 2);
					val2.GenerateLayout();
					val2.RecomputeTableBlock(true);
					((Entity)val2).Layer = DeclaracoesGeral.ativo.Pagina;
					Point3d position = (((BlockReference)val2).Position = new Point3d(pt.X, pt.Y, 0.0));
					val2.Columns[0].Width = Math.Round(dLarguraDoBloco * 0.084, 2);
					val2.Columns[1].Width = Math.Round(dLarguraDoBloco * 0.168, 2);
					val2.SetRowHeight(ConfP.AlturaDoBloco);
					((CellRange)val2.Cells[0, 0]).TextHeight = ConfP.TamanhoFonte;
					((CellRange)val2.Cells[0, 1]).TextHeight = ConfP.TamanhoFonte;
					if (iIndice == 0)
					{
						val2.Cells[0, 0].TextString = mPlaquetas[iIndice].Indice.ToString();
					}
					if (iIndice > 0)
					{
						val2.Cells[0, 0].TextString = iIndiceNumerico.ToString();
						iIndiceNumerico++;
					}
					((CellRange)val2.Cells[0, 0]).Alignment = (CellAlignment)5;
					val2.Cells[0, 1].TextString = mPlaquetas[iIndice].Nome.ToString();
					((CellRange)val2.Cells[0, 1]).Alignment = (CellAlignment)5;
					((BlockReference)val2).Position = position;
					dY = 0.0;
					dX = 0.0;
					((Entity)val2).ColorIndex = ConfP.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val2.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val2.GenerateLayout();
					val7.AppendEntity((Entity)(object)val2);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
					val2.RecomputeTableBlock(true);
					Extents3d value = ((Drawable)val2).Bounds.Value;
					Point3d val9 = value.MaxPoint;
					dY = val9.Y;
					value = ((Drawable)val2).Bounds.Value;
					val9 = value.MaxPoint;
					dX = val9.X;
					value = ((Drawable)val2).Bounds.Value;
					val9 = value.MinPoint;
					YInicio = val9.Y;
					DeclaracoesGeral.bAnularEventos = true;
					val2.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val2).Explode(val5);
					((DBObject)val2).Erase();
					foreach (Entity item in val5)
					{
						Entity Ent = item;
						MText val10 = (MText)(object)((Ent is MText) ? Ent : null);
						try
						{
							if (val10 != null && Operators.CompareString(val10.Text, "##B##", TextCompare: true) != 0)
							{
								((Entity)val10).ColorIndex = ConfP.CorTexto;
								((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
								val7.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								Entity Ent2 = (Entity)(object)val10;
								XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
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
								val7.AppendEntity(Ent);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
								XDataRelatorio.GravarXDataPlaquetas(ref Ent, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
							}
						}
						finally
						{
							((IDisposable)val11)?.Dispose();
						}
						((DisposableWrapper)Ent).Dispose();
					}
					Table val12 = new Table();
					((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
					val12.SetSize(2, 1);
					val12.GenerateLayout();
					val12.RecomputeTableBlock(true);
					((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
					position = (((BlockReference)val12).Position = new Point3d(dX, dY, 0.0));
					val12.Columns[0].Width = Math.Round(dLarguraDoBloco * 0.126, 2);
					val12.SetRowHeight(ConfP.AlturaDoBloco / 2.0);
					((CellRange)val12.Cells[0, 0]).TextHeight = ConfP.TamanhoFonte / 2.0;
					((CellRange)val12.Cells[1, 0]).TextHeight = ConfP.TamanhoFonte / 2.0;
					val12.Cells[0, 0].TextString = mPlaquetas[iIndice].Modelo.ToString();
					((CellRange)val12.Cells[0, 0]).Alignment = (CellAlignment)5;
					val12.Cells[1, 0].TextString = mPlaquetas[iIndice].Quant.ToString();
					((CellRange)val12.Cells[1, 0]).Alignment = (CellAlignment)5;
					((BlockReference)val12).Position = position;
					dY = 0.0;
					dX = 0.0;
					((Entity)val12).ColorIndex = ConfP.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val12.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val12.GenerateLayout();
					val7.AppendEntity((Entity)(object)val12);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
					val12.RecomputeTableBlock(true);
					value = ((Drawable)val12).Bounds.Value;
					val9 = value.MaxPoint;
					dY = val9.Y;
					value = ((Drawable)val12).Bounds.Value;
					val9 = value.MaxPoint;
					dX = val9.X;
					DBObjectCollection val14 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val12.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val12).Explode(val14);
					((DBObject)val12).Erase();
					foreach (Entity item2 in val14)
					{
						Entity Ent3 = item2;
						MText val15 = (MText)(object)((Ent3 is MText) ? Ent3 : null);
						try
						{
							if (val15 != null && Operators.CompareString(val15.Text, "##B##", TextCompare: true) != 0)
							{
								DBObjectCollection val16 = new DBObjectCollection();
								((Entity)val15).Explode(val16);
								foreach (Entity item3 in val16)
								{
									Entity val17 = item3;
									DBText val18 = (DBText)(object)((val17 is DBText) ? val17 : null);
									if (val18 != null)
									{
										((Entity)val18).ColorIndex = ConfP.CorTexto;
										((Entity)val18).Layer = DeclaracoesGeral.ativo.Pagina;
										val18.Height = ConfP.TamanhoFonte;
										val18.HorizontalMode = (TextHorizontalMode)1;
										val18.VerticalMode = (TextVerticalMode)3;
										val9 = val15.Location;
										double x = val9.X;
										val9 = val15.Location;
										Point3d alignmentPoint = new Point3d(x, val9.Y + ConfP.TamanhoFonte / 2.0, 0.0);
										val18.AlignmentPoint = alignmentPoint;
										val7.AppendEntity((Entity)(object)val18);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val18, true);
										Entity Ent2 = (Entity)(object)val18;
										XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
										val18 = (DBText)Ent2;
									}
								}
							}
						}
						finally
						{
							((IDisposable)val15)?.Dispose();
						}
						Line val19 = (Line)(object)((Ent3 is Line) ? Ent3 : null);
						try
						{
							if (val19 != null)
							{
								Ent3.Layer = DeclaracoesGeral.ativo.Pagina;
								val7.AppendEntity(Ent3);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)Ent3, true);
								XDataRelatorio.GravarXDataPlaquetas(ref Ent3, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
							}
						}
						finally
						{
							((IDisposable)val19)?.Dispose();
						}
						((DisposableWrapper)Ent3).Dispose();
					}
					Table val20 = new Table();
					((Entity)val20).Layer = DeclaracoesGeral.ativo.Pagina;
					val20.SetSize(1, 1);
					val20.GenerateLayout();
					val20.RecomputeTableBlock(true);
					((Entity)val20).Layer = DeclaracoesGeral.ativo.Pagina;
					position = (((BlockReference)val20).Position = new Point3d(dX, dY, 0.0));
					val20.Columns[0].Width = Math.Round(dLarguraDoBloco * 0.42, 2);
					val20.SetRowHeight(ConfP.AlturaDoBloco);
					((CellRange)val20.Cells[0, 0]).TextHeight = ConfP.TamanhoFonte;
					val20.Cells[0, 0].TextString = "##B##";
					((CellRange)val20.Cells[0, 0]).Alignment = (CellAlignment)5;
					((BlockReference)val20).Position = position;
					((Entity)val20).ColorIndex = ConfP.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val20.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val20.GenerateLayout();
					val7.AppendEntity((Entity)(object)val20);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val20, true);
					val20.RecomputeTableBlock(true);
					value = ((Drawable)val20).Bounds.Value;
					val9 = value.MaxPoint;
					dY = val9.Y;
					value = ((Drawable)val20).Bounds.Value;
					val9 = value.MaxPoint;
					dX = val9.X;
					DBObjectCollection val22 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val20.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val20).Explode(val22);
					((DBObject)val20).Erase();
					foreach (Entity item4 in val22)
					{
						Entity Ent4 = item4;
						Line val23 = (Line)(object)((Ent4 is Line) ? Ent4 : null);
						if (val23 != null)
						{
							Ent4.Layer = DeclaracoesGeral.ativo.Pagina;
							val7.AppendEntity(Ent4);
							DeclaracoesGeral.bAnularEventos = true;
							val3.AddNewlyCreatedDBObject((DBObject)(object)Ent4, true);
							XDataRelatorio.GravarXDataPlaquetas(ref Ent4, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
						}
						((DisposableWrapper)Ent4).Dispose();
					}
					Table val24 = new Table();
					((Entity)val24).Layer = DeclaracoesGeral.ativo.Pagina;
					val24.SetSize(3, 1);
					val24.GenerateLayout();
					val24.RecomputeTableBlock(true);
					((Entity)val24).Layer = DeclaracoesGeral.ativo.Pagina;
					((BlockReference)val24).Position = position;
					val24.Columns[0].Width = Math.Round(dLarguraDoBloco * 0.42, 2);
					val24.SetRowHeight(ConfP.AlturaDoBloco / 3.0);
					((CellRange)val24.Cells[0, 0]).TextHeight = ConfP.TamanhoFonte / 2.0;
					((CellRange)val24.Cells[1, 0]).TextHeight = ConfP.TamanhoFonte / 2.0;
					((CellRange)val24.Cells[2, 0]).TextHeight = ConfP.TamanhoFonte / 2.0;
					bool flag = false;
					bool flag2 = false;
					bool flag3 = false;
					int num = 0;
					bool flag4 = false;
					if (Operators.CompareString(mPlaquetas[iIndice].Desc1.ToString(), "##B##", TextCompare: true) != 0)
					{
						flag = true;
						num++;
					}
					if (Operators.CompareString(mPlaquetas[iIndice].Desc2.ToString(), "##B##", TextCompare: true) != 0)
					{
						flag2 = true;
						num++;
					}
					if (Operators.CompareString(mPlaquetas[iIndice].Desc3.ToString(), "##B##", TextCompare: true) != 0)
					{
						flag3 = true;
						num++;
					}
					if (iIndice != 0)
					{
						if (!(flag & flag2 & flag3))
						{
							if (!(flag & !flag2 & !flag3))
							{
								if (!(!flag & flag2 & !flag3))
								{
									if (!(!flag & !flag2 & flag3))
									{
										if ((Operators.CompareString(mPlaquetas[iIndice].Desc1.ToString(), "##B##", TextCompare: true) == 0) & (Operators.CompareString(mPlaquetas[iIndice].Desc2.ToString(), "##B##", TextCompare: true) != 0))
										{
											mPlaquetas[iIndice].Desc1 = mPlaquetas[iIndice].Desc2;
											mPlaquetas[iIndice].Desc2 = "##B##";
										}
										if ((Operators.CompareString(mPlaquetas[iIndice].Desc2.ToString(), "##B##", TextCompare: true) == 0) & (Operators.CompareString(mPlaquetas[iIndice].Desc3.ToString(), "##B##", TextCompare: true) != 0))
										{
											mPlaquetas[iIndice].Desc2 = mPlaquetas[iIndice].Desc3;
											mPlaquetas[iIndice].Desc3 = "##B##";
										}
										val24.Cells[0, 0].TextString = mPlaquetas[iIndice].Desc1.ToString();
										val24.Cells[1, 0].TextString = mPlaquetas[iIndice].Desc2.ToString();
										val24.Cells[2, 0].TextString = mPlaquetas[iIndice].Desc3.ToString();
										flag4 = true;
									}
									else
									{
										val24.Cells[0, 0].TextString = "##B##";
										val24.Cells[1, 0].TextString = mPlaquetas[iIndice].Desc3.ToString();
										val24.Cells[2, 0].TextString = "##B##";
									}
								}
								else
								{
									val24.Cells[0, 0].TextString = "##B##";
									val24.Cells[1, 0].TextString = mPlaquetas[iIndice].Desc2.ToString();
									val24.Cells[2, 0].TextString = "##B##";
								}
							}
							else
							{
								val24.Cells[0, 0].TextString = "##B##";
								val24.Cells[1, 0].TextString = mPlaquetas[iIndice].Desc1.ToString();
								val24.Cells[2, 0].TextString = "##B##";
							}
						}
						else
						{
							val24.Cells[0, 0].TextString = mPlaquetas[iIndice].Desc1.ToString();
							val24.Cells[1, 0].TextString = mPlaquetas[iIndice].Desc2.ToString();
							val24.Cells[2, 0].TextString = mPlaquetas[iIndice].Desc3.ToString();
						}
					}
					else
					{
						val24.Cells[0, 0].TextString = "##B##";
						val24.Cells[1, 0].TextString = mPlaquetas[iIndice].Desc2.ToString();
						val24.Cells[0, 0].TextString = "##B##";
					}
					((CellRange)val24.Cells[0, 0]).Alignment = (CellAlignment)5;
					((CellRange)val24.Cells[1, 0]).Alignment = (CellAlignment)5;
					((CellRange)val24.Cells[2, 0]).Alignment = (CellAlignment)5;
					((BlockReference)val24).Position = position;
					((Entity)val24).ColorIndex = ConfP.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val24.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val24.GenerateLayout();
					val7.AppendEntity((Entity)(object)val24);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val24, true);
					val24.RecomputeTableBlock(true);
					DBObjectCollection val25 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val24.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val24).Explode(val25);
					((DBObject)val24).Erase();
					foreach (Entity item5 in val25)
					{
						Entity val26 = item5;
						MText val27 = (MText)(object)((val26 is MText) ? val26 : null);
						try
						{
							if (val27 != null && Operators.CompareString(val27.Text, "##B##", TextCompare: true) != 0)
							{
								DBObjectCollection val28 = new DBObjectCollection();
								((Entity)val27).Explode(val28);
								foreach (Entity item6 in val28)
								{
									Entity val29 = item6;
									DBText val30 = (DBText)(object)((val29 is DBText) ? val29 : null);
									if (val30 != null)
									{
										((Entity)val30).ColorIndex = ConfP.CorTexto;
										((Entity)val30).Layer = DeclaracoesGeral.ativo.Pagina;
										val30.Height = ConfP.TamanhoFonte;
										val30.HorizontalMode = (TextHorizontalMode)1;
										val30.VerticalMode = (TextVerticalMode)3;
										double num2 = 0.0;
										if (flag4)
										{
											num2 = ConfP.AlturaDoBloco / 3.0 / (double)num;
										}
										val9 = val27.Location;
										double x2 = val9.X;
										val9 = val27.Location;
										Point3d alignmentPoint2 = new Point3d(x2, val9.Y + ConfP.TamanhoFonte / 2.0 - num2, 0.0);
										val30.AlignmentPoint = alignmentPoint2;
										val7.AppendEntity((Entity)(object)val30);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val30, true);
										Entity Ent2 = (Entity)(object)val30;
										XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
										val30 = (DBText)Ent2;
									}
								}
							}
						}
						finally
						{
							((IDisposable)val27)?.Dispose();
						}
						((DisposableWrapper)val26).Dispose();
					}
					Table val31 = new Table();
					((Entity)val31).Layer = DeclaracoesGeral.ativo.Pagina;
					val31.SetSize(1, 1);
					val31.GenerateLayout();
					val31.RecomputeTableBlock(true);
					position = (((BlockReference)val31).Position = new Point3d(dX, dY, 0.0));
					val31.Columns[0].Width = Math.Round(dLarguraDoBloco * 0.202, 2);
					val31.SetRowHeight(ConfP.AlturaDoBloco);
					((CellRange)val31.Cells[0, 0]).TextHeight = ConfP.TamanhoFonte;
					val31.Cells[0, 0].TextString = mPlaquetas[iIndice].Painel;
					((CellRange)val31.Cells[0, 0]).Alignment = (CellAlignment)5;
					((BlockReference)val31).Position = position;
					dY = 0.0;
					dX = 0.0;
					((Entity)val31).ColorIndex = ConfP.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val31.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val31.GenerateLayout();
					val7.AppendEntity((Entity)(object)val31);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val31, true);
					val31.RecomputeTableBlock(true);
					value = ((Drawable)val31).Bounds.Value;
					val9 = value.MinPoint;
					dY = val9.Y;
					value = ((Drawable)val31).Bounds.Value;
					val9 = value.MaxPoint;
					dX = val9.X;
					DBObjectCollection val33 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val31.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val31).Explode(val33);
					((DBObject)val31).Erase();
					foreach (Entity item7 in val33)
					{
						Entity Ent5 = item7;
						MText val34 = (MText)(object)((Ent5 is MText) ? Ent5 : null);
						try
						{
							if (val34 != null && Operators.CompareString(val34.Text, "##B##", TextCompare: true) != 0)
							{
								DBObjectCollection val35 = new DBObjectCollection();
								((Entity)val34).Explode(val35);
								foreach (Entity item8 in val35)
								{
									Entity val36 = item8;
									DBText val37 = (DBText)(object)((val36 is DBText) ? val36 : null);
									if (val37 != null)
									{
										((Entity)val37).ColorIndex = ConfP.CorTexto;
										((Entity)val37).Layer = DeclaracoesGeral.ativo.Pagina;
										val37.Height = ConfP.TamanhoFonte;
										val37.HorizontalMode = (TextHorizontalMode)1;
										val37.VerticalMode = (TextVerticalMode)3;
										val9 = val34.Location;
										double x3 = val9.X;
										val9 = val34.Location;
										Point3d alignmentPoint3 = new Point3d(x3, val9.Y + ConfP.TamanhoFonte / 2.0, 0.0);
										val37.AlignmentPoint = alignmentPoint3;
										val7.AppendEntity((Entity)(object)val37);
										DeclaracoesGeral.bAnularEventos = true;
										val3.AddNewlyCreatedDBObject((DBObject)(object)val37, true);
										Entity Ent2 = (Entity)(object)val37;
										XDataRelatorio.GravarXDataPlaquetas(ref Ent2, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
										val37 = (DBText)Ent2;
									}
								}
							}
						}
						finally
						{
							((IDisposable)val34)?.Dispose();
						}
						Line val38 = (Line)(object)((Ent5 is Line) ? Ent5 : null);
						try
						{
							if (val38 != null)
							{
								Ent5.Layer = DeclaracoesGeral.ativo.Pagina;
								val7.AppendEntity(Ent5);
								DeclaracoesGeral.bAnularEventos = true;
								val3.AddNewlyCreatedDBObject((DBObject)(object)Ent5, true);
								XDataRelatorio.GravarXDataPlaquetas(ref Ent5, mPlaquetas[iIndice].Indice, mPlaquetas[iIndice].Nome, iPainel);
							}
						}
						finally
						{
							((IDisposable)val38)?.Dispose();
						}
						((DisposableWrapper)Ent5).Dispose();
					}
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
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

	public static void ApagaRelatorioDeplaquetas(int iPainel)
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
						string sDisp = "";
						int iPN = 0;
						string sEti = "";
						if (XDataRelatorio.LerXDataPlaquetas(ref Ent, ref sEti, ref sDisp, ref iPN) && iPainel == iPN)
						{
							if (Operators.CompareString(pag, "", TextCompare: true) == 0)
							{
								pag = Ent.Layer.ToString();
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
			if (Operators.CompareString(pag, "", TextCompare: true) != 0 && Operators.CompareString(pag, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
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

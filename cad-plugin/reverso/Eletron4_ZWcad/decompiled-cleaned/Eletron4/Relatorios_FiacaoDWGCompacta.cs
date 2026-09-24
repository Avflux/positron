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

public class Relatorios_FiacaoDWGCompacta
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

	public static void CriaRelatorioMatrizFiacaoBornesCompactoDWG(DeclaracoesFiacao.structureRelFiacao[] mFiacao, Declaracoes2.ConfRelatorio ConfRelFiacao, string sTipoRelatorio, int iPainel)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		bool flag = true;
		DeclaracoesGeral.bPararRelatorio = false;
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double num = 0.0;
		double num2 = 0.0;
		double YInicio = 0.0;
		bool flag2 = true;
		bool flag3 = false;
		int iIndice = 1;
		double num3 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num3 -= ConfRelFiacao.DistEntreColunas * (double)(ConfRelFiacao.QuantColunas + 1);
			num3 /= (double)ConfRelFiacao.QuantColunas;
			double num4 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - num - (double)ConfRelFiacao.QuantColunas * num3;
			num4 /= (double)(ConfRelFiacao.QuantColunas + 1);
			num3 -= 36.0;
			try
			{
				Point3d pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
				int num5 = 1;
				Dicionario.CriaTableStyleRelatorios(ConfRelFiacao.sFonte, 0.5, 1.0);
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mFiacao);
				DeclaracoesGeral._uscPagina.pbIniciar();
				num = pt.X;
				num2 = pt.Y;
				num2 += ConfRelFiacao.AlturaDoBloco / 2.0;
				bool bTituloTag = true;
				int num6 = Information.UBound(mFiacao);
				int num7 = 1;
				while (num7 <= num6)
				{
					if (!DeclaracoesGeral.bPararRelatorio)
					{
						if (!((Operators.CompareString(mFiacao[num7 - 1].Tag, "", TextCompare: true) != 0) & flag2))
						{
							flag2 = true;
						}
						else
						{
							bTituloTag = true;
							iIndice = num7 - 1;
							pt = new Point3d(num, num2, 0.0);
							CriaTabelaFiacaoCompacta(sTipoRelatorio, num3, pt, mFiacao, iIndice, ref num2, ref num, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
							bTituloTag = false;
						}
						Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
						pt = new Point3d(pt.X, num2, 0.0);
						CriaTabelaFiacaoCompacta(sTipoRelatorio, num3, pt, mFiacao, num7, ref num2, ref num, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
						double num8 = ConfRelFiacao.AlturaDoBloco;
						if (num7 < Information.UBound(mFiacao) && mFiacao[num7 + 1].TipoBorne == 1)
						{
							num8 = ConfRelFiacao.AlturaDoBloco * 2.0;
						}
						if (num2 < RH.AltBase + 21.0 + num8 && Operators.CompareString(mFiacao[num7].Tag, "", TextCompare: true) != 0)
						{
							flag3 = true;
							num2 -= 21.0;
						}
						if ((num2 < RH.AltBase + 1.0 + num8) | flag3)
						{
							flag3 = false;
							if (num5 != ConfRelFiacao.QuantColunas)
							{
								pt = new Point3d(num + ConfRelFiacao.DistEntreColunas + num3 + 36.0, RH.Pti.Y - ConfRelFiacao.AlturaInicial + ConfRelFiacao.AlturaDoBloco / 2.0, 0.0);
								num2 = pt.Y;
								num = pt.X;
								num5++;
							}
							else if (flag)
							{
								Pagina.OrdenaMatrizPaginas();
								string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
								if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) != 0)
								{
									if (DeclaracoesGeral.bPararRelatorio)
									{
										goto IL_025d;
									}
									Pagina.AtivaPagina(pag);
									DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
									num5 = 1;
								}
								else
								{
									if (DeclaracoesGeral.bPararRelatorio)
									{
										goto IL_025d;
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
								pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial + ConfRelFiacao.AlturaDoBloco / 2.0, 0.0);
								num5 = 1;
							}
							else
							{
								if (!Pagina.criarUmaNovaPagina())
								{
									break;
								}
								DeclaracoesGeral._uscPagina.CarregaPG();
								pt = new Point3d(RH.Pti.X + ConfRelFiacao.DistEntreColunas, RH.Pti.Y - ConfRelFiacao.AlturaInicial, 0.0);
								num5 = 1;
							}
							if (num7 < Information.UBound(mFiacao) - 1 && ((Operators.CompareString(mFiacao[num7].Tag, "", TextCompare: true) == 0) | (num5 == 1)))
							{
								bTituloTag = true;
								if (Operators.CompareString(mFiacao[num7].Tag, "", TextCompare: true) != 0)
								{
									iIndice = num7;
								}
								CriaTabelaFiacaoCompacta(sTipoRelatorio, num3, pt, mFiacao, iIndice, ref num2, ref num, ref YInicio, ConfRelFiacao, iPainel, ref bTituloTag);
								flag2 = false;
								bTituloTag = false;
							}
						}
						goto IL_025d;
					}
					Application.DoEvents();
					break;
					IL_025d:
					DeclaracoesGeral._uscPagina.pbPasso();
					if (!DeclaracoesGeral.bPararRelatorio)
					{
						num7++;
						continue;
					}
					break;
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

	public static void CriaTabelaFiacaoCompacta(string sTipoRelatorio, double dLarguraDoBloco, Point3d pt, DeclaracoesFiacao.structureRelFiacao[] mFiacao, int iIndice, ref double dY, ref double dX, ref double YInicio, Declaracoes2.ConfRelatorio ConfRelFiacao, int iPainel, ref bool bTituloTag)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_138c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1393: Expected Obj, but got Unknown
		//IL_13f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1400: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1534: Unknown result type (might be due to invalid IL or missing references)
		//IL_1539: Unknown result type (might be due to invalid IL or missing references)
		//IL_153d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1542: Unknown result type (might be due to invalid IL or missing references)
		//IL_1559: Unknown result type (might be due to invalid IL or missing references)
		//IL_155e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1562: Unknown result type (might be due to invalid IL or missing references)
		//IL_1567: Unknown result type (might be due to invalid IL or missing references)
		//IL_1571: Unknown result type (might be due to invalid IL or missing references)
		//IL_1578: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_1581: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bd: Expected Obj, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected Obj, but got Unknown
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d3: Expected Obj, but got Unknown
		//IL_170b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1710: Unknown result type (might be due to invalid IL or missing references)
		//IL_1714: Unknown result type (might be due to invalid IL or missing references)
		//IL_1607: Unknown result type (might be due to invalid IL or missing references)
		//IL_183a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1870: Unknown result type (might be due to invalid IL or missing references)
		//IL_188b: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1910: Unknown result type (might be due to invalid IL or missing references)
		//IL_1917: Expected Obj, but got Unknown
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected Obj, but got Unknown
		//IL_165e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1920: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0427: Unknown result type (might be due to invalid IL or missing references)
		//IL_042c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0511: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Expected Obj, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0647: Unknown result type (might be due to invalid IL or missing references)
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06af: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b6: Expected Obj, but got Unknown
		//IL_1955: Unknown result type (might be due to invalid IL or missing references)
		//IL_195c: Expected Obj, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fb: Expected Obj, but got Unknown
		//IL_19fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_080e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Expected Obj, but got Unknown
		//IL_0745: Unknown result type (might be due to invalid IL or missing references)
		//IL_0862: Unknown result type (might be due to invalid IL or missing references)
		//IL_0867: Unknown result type (might be due to invalid IL or missing references)
		//IL_086b: Unknown result type (might be due to invalid IL or missing references)
		//IL_079c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0951: Unknown result type (might be due to invalid IL or missing references)
		//IL_0987: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_09db: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Expected Obj, but got Unknown
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a56: Expected Obj, but got Unknown
		//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ada: Unknown result type (might be due to invalid IL or missing references)
		//IL_0adf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b85: Unknown result type (might be due to invalid IL or missing references)
		//IL_105d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1064: Expected Obj, but got Unknown
		//IL_109c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0feb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_119e: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1228: Unknown result type (might be due to invalid IL or missing references)
		//IL_122f: Expected Obj, but got Unknown
		//IL_0e06: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccf: Unknown result type (might be due to invalid IL or missing references)
		//IL_126d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1274: Expected Obj, but got Unknown
		//IL_12be: Unknown result type (might be due to invalid IL or missing references)
		//IL_1315: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				double largura = 5.0;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					try
					{
						BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
						BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
						double num = 0.0;
						Extents3d value;
						Point3d val7;
						if (!bTituloTag)
						{
							Table val6 = new Table();
							((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
							val6.SetSize(1, 1);
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								val6.SetSize(2, 1);
							}
							val6.GenerateLayout();
							val6.RecomputeTableBlock(true);
							Point3d position = new Point3d(pt.X, pt.Y, 0.0);
							double width = 4.0;
							double width2 = 10.0;
							((BlockReference)val6).Position = position;
							val6.Columns[0].Width = width;
							val6.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
							((CellRange)val6.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte * 0.5;
							val6.Cells[0, 0].TextString = "o";
							((CellRange)val6.Cells[0, 0]).Alignment = (CellAlignment)5;
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								((CellRange)val6.Cells[1, 0]).TextHeight = ConfRelFiacao.TamanhoFonte * 0.5;
							}
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								val6.Cells[1, 0].TextString = "o";
							}
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								((CellRange)val6.Cells[1, 0]).Alignment = (CellAlignment)5;
							}
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
							value = ((Drawable)val6).Bounds.Value;
							val7 = value.MaxPoint;
							dY = val7.Y;
							value = ((Drawable)val6).Bounds.Value;
							val7 = value.MaxPoint;
							dX = val7.X;
							value = ((Drawable)val6).Bounds.Value;
							val7 = value.MinPoint;
							num = val7.X;
							value = ((Drawable)val6).Bounds.Value;
							val7 = value.MinPoint;
							YInicio = val7.Y;
							DBObjectCollection val8 = new DBObjectCollection();
							try
							{
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
										if (val10 != null)
										{
											value = ((Drawable)val10).Bounds.Value;
											val7 = value.MinPoint;
											double x = val7.X;
											value = ((Drawable)val10).Bounds.Value;
											val7 = value.MaxPoint;
											double x2 = val7.X;
											value = ((Drawable)val10).Bounds.Value;
											val7 = value.MinPoint;
											double num2 = x + (x2 - val7.X) / 2.0;
											value = ((Drawable)val10).Bounds.Value;
											val7 = value.MinPoint;
											double y = val7.Y;
											value = ((Drawable)val10).Bounds.Value;
											val7 = value.MaxPoint;
											double y2 = val7.Y;
											value = ((Drawable)val10).Bounds.Value;
											val7 = value.MinPoint;
											double num3 = y + (y2 - val7.Y) / 2.0;
											Point3d pt2 = new Point3d(num2, num3, 0.0);
											if (Operators.CompareString(val10.Text.ToUpper(), "O", TextCompare: true) == 0)
											{
												Relatorios_GeralDWG.criarCirculoDoBorne(sTipoRelatorio, pt2, largura, ((Entity)val10).Layer, bHatchCirculo: false, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
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
											((Entity)val11).Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity((Entity)(object)val11);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
											Entity Ent = (Entity)(object)val11;
											XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val11)?.Dispose();
									}
									((DisposableWrapper)val9).Dispose();
								}
							}
							finally
							{
								((IDisposable)val8)?.Dispose();
							}
							((DisposableWrapper)val6).Dispose();
							Table val12 = new Table();
							((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
							val12.SetSize(1, 1);
							val12.GenerateLayout();
							val12.RecomputeTableBlock(true);
							position = (((BlockReference)val12).Position = new Point3d(dX, dY, 0.0));
							val12.Columns[0].Width = width2;
							val12.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								val12.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
							}
							((CellRange)val12.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte;
							val12.Cells[0, 0].TextString = mFiacao[iIndice].Terminal.ToString();
							((CellRange)val12.Cells[0, 0]).Alignment = (CellAlignment)5;
							((BlockReference)val12).Position = position;
							dY = 0.0;
							dX = 0.0;
							((Entity)val12).ColorIndex = ConfRelFiacao.CorLinha;
							DeclaracoesGeral.bAnularEventos = true;
							val12.TableStyle = database.Tablestyle;
							DeclaracoesGeral.bAnularEventos = false;
							val12.GenerateLayout();
							val5.AppendEntity((Entity)(object)val12);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
							val12.RecomputeTableBlock(true);
							value = ((Drawable)val12).Bounds.Value;
							val7 = value.MaxPoint;
							dY = val7.Y;
							value = ((Drawable)val12).Bounds.Value;
							val7 = value.MaxPoint;
							dX = val7.X;
							DBObjectCollection val14 = new DBObjectCollection();
							try
							{
								DeclaracoesGeral.bAnularEventos = true;
								val12.TableStyle = database.Tablestyle;
								DeclaracoesGeral.bAnularEventos = false;
								((Entity)val12).Explode(val14);
								((DBObject)val12).Erase();
								foreach (Entity item2 in val14)
								{
									Entity val15 = item2;
									MText val16 = (MText)(object)((val15 is MText) ? val15 : null);
									try
									{
										if (val16 != null)
										{
											((Entity)val16).ColorIndex = ConfRelFiacao.CorTexto;
											((Entity)val16).Layer = DeclaracoesGeral.ativo.Pagina;
											if (Operators.CompareString(val16.Text, "##B##", TextCompare: true) != 0)
											{
												val5.AppendEntity((Entity)(object)val16);
												DeclaracoesGeral.bAnularEventos = true;
												val2.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
												Entity Ent = (Entity)(object)val16;
												XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
											}
										}
									}
									finally
									{
										((IDisposable)val16)?.Dispose();
									}
									Line val17 = (Line)(object)((val15 is Line) ? val15 : null);
									try
									{
										if (val17 != null)
										{
											((Entity)val17).Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity((Entity)(object)val17);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val17, true);
											Entity Ent = (Entity)(object)val17;
											XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val17)?.Dispose();
									}
									((DisposableWrapper)val15).Dispose();
								}
							}
							finally
							{
								((IDisposable)val14)?.Dispose();
							}
							((DisposableWrapper)val12).Dispose();
							Table val18 = new Table();
							((Entity)val18).Layer = DeclaracoesGeral.ativo.Pagina;
							val18.SetSize(1, 1);
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								val18.SetSize(2, 1);
							}
							val18.GenerateLayout();
							val18.RecomputeTableBlock(true);
							position = (((BlockReference)val18).Position = new Point3d(dX, dY, 0.0));
							val18.Columns[0].Width = width;
							val18.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
							((CellRange)val18.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte * 0.5;
							val18.Cells[0, 0].TextString = "o";
							((CellRange)val18.Cells[0, 0]).Alignment = (CellAlignment)5;
							Color backgroundColor = Color.FromColorIndex((ColorMethod)194, (short)3);
							((CellRange)val18.Cells[0, 0]).BackgroundColor = backgroundColor;
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								((CellRange)val18.Cells[1, 0]).TextHeight = ConfRelFiacao.TamanhoFonte * 0.5;
							}
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								val18.Cells[1, 0].TextString = "b";
							}
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								((CellRange)val18.Cells[1, 0]).Alignment = (CellAlignment)5;
							}
							((BlockReference)val18).Position = position;
							dY = 0.0;
							dX = 0.0;
							((Entity)val18).ColorIndex = ConfRelFiacao.CorLinha;
							DeclaracoesGeral.bAnularEventos = true;
							val18.TableStyle = database.Tablestyle;
							DeclaracoesGeral.bAnularEventos = false;
							val18.GenerateLayout();
							val5.AppendEntity((Entity)(object)val18);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val18, true);
							val18.RecomputeTableBlock(true);
							value = ((Drawable)val18).Bounds.Value;
							val7 = value.MaxPoint;
							dY = val7.Y;
							value = ((Drawable)val18).Bounds.Value;
							val7 = value.MaxPoint;
							dX = val7.X;
							DBObjectCollection val20 = new DBObjectCollection();
							try
							{
								DeclaracoesGeral.bAnularEventos = true;
								val18.TableStyle = database.Tablestyle;
								DeclaracoesGeral.bAnularEventos = false;
								((Entity)val18).Explode(val20);
								((DBObject)val18).Erase();
								foreach (Entity item3 in val20)
								{
									Entity val21 = item3;
									bool bHatchCirculo = false;
									MText val22 = (MText)(object)((val21 is MText) ? val21 : null);
									try
									{
										if (val22 != null)
										{
											((Entity)val22).ColorIndex = ConfRelFiacao.CorTexto;
											((Entity)val22).Layer = DeclaracoesGeral.ativo.Pagina;
											value = ((Drawable)val22).Bounds.Value;
											val7 = value.MinPoint;
											double x3 = val7.X;
											value = ((Drawable)val22).Bounds.Value;
											val7 = value.MaxPoint;
											double x4 = val7.X;
											value = ((Drawable)val22).Bounds.Value;
											val7 = value.MinPoint;
											double num4 = x3 + (x4 - val7.X) / 2.0;
											value = ((Drawable)val22).Bounds.Value;
											val7 = value.MinPoint;
											double y3 = val7.Y;
											value = ((Drawable)val22).Bounds.Value;
											val7 = value.MaxPoint;
											double y4 = val7.Y;
											value = ((Drawable)val22).Bounds.Value;
											val7 = value.MinPoint;
											double num5 = y3 + (y4 - val7.Y) / 2.0;
											Point3d pt3 = new Point3d(num4, num5, 0.0);
											if ((Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) == 0) | (Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0))
											{
												if (mFiacao[iIndice].TipoBorne == 0)
												{
													if ((Operators.CompareString(mFiacao[iIndice].Jumper, "U", TextCompare: true) == 0) | (Operators.CompareString(mFiacao[iIndice].Jumper, "T", TextCompare: true) == 0))
													{
														Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
														bHatchCirculo = true;
													}
													if (Operators.CompareString(mFiacao[iIndice].Jumper, "UD", TextCompare: true) == 0)
													{
														Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
														Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
														bHatchCirculo = true;
													}
													if ((Operators.CompareString(mFiacao[iIndice].Jumper, "D", TextCompare: true) == 0) | (Operators.CompareString(mFiacao[iIndice].Jumper, "T", TextCompare: true) == 0))
													{
														Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
														bHatchCirculo = true;
													}
												}
												if (mFiacao[iIndice].TipoBorne == 1)
												{
													if (Operators.CompareString(mFiacao[iIndice].Jumper, "D", TextCompare: true) == 0 && Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0)
													{
														Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
														bHatchCirculo = true;
													}
													if (Operators.CompareString(mFiacao[iIndice].Jumper, "UD", TextCompare: true) == 0)
													{
														if (Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) == 0)
														{
															Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
															Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
															bHatchCirculo = true;
														}
														if (Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0)
														{
															Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
															Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "B", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
															bHatchCirculo = true;
														}
													}
													if (Operators.CompareString(mFiacao[iIndice].Jumper, "U", TextCompare: true) == 0 && Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) == 0)
													{
														Relatorios_GeralDWG.criarJumperHatch(sTipoRelatorio, "C", pt3, ConfRelFiacao.AlturaDoBloco, largura, ((Entity)val22).Layer, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
														bHatchCirculo = true;
													}
												}
											}
											if ((Operators.CompareString(val22.Text.ToUpper(), "O", TextCompare: true) == 0) | (Operators.CompareString(val22.Text.ToUpper(), "B", TextCompare: true) == 0))
											{
												Relatorios_GeralDWG.criarCirculoDoBorne(sTipoRelatorio, pt3, largura, ((Entity)val22).Layer, bHatchCirculo, mFiacao[iIndice].Terminal, iPainel, ConfRelFiacao);
											}
										}
									}
									finally
									{
										((IDisposable)val22)?.Dispose();
									}
									Line val23 = (Line)(object)((val21 is Line) ? val21 : null);
									try
									{
										if (val23 != null)
										{
											((Entity)val23).Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity((Entity)(object)val23);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val23, true);
											Entity Ent = (Entity)(object)val23;
											XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val23)?.Dispose();
									}
									((DisposableWrapper)val21).Dispose();
								}
							}
							finally
							{
								((IDisposable)val20)?.Dispose();
							}
							((DisposableWrapper)val18).Dispose();
							Table val24 = new Table();
							((Entity)val24).Layer = DeclaracoesGeral.ativo.Pagina;
							val24.SetSize(1, 2);
							val24.GenerateLayout();
							val24.RecomputeTableBlock(true);
							position = (((BlockReference)val24).Position = new Point3d(dX, dY, 0.0));
							val24.Columns[0].Width = dLarguraDoBloco;
							val24.Columns[1].Width = 18.0;
							double rowHeight = ConfRelFiacao.AlturaDoBloco;
							if (mFiacao[iIndice].TipoBorne == 1)
							{
								rowHeight = ConfRelFiacao.AlturaDoBloco * 2.0;
							}
							val24.SetRowHeight(rowHeight);
							int num6 = 0;
							do
							{
								((CellRange)val24.Cells[0, num6]).TextHeight = ConfRelFiacao.TamanhoFonte;
								((CellRange)val24.Cells[0, num6]).Alignment = (CellAlignment)5;
								num6++;
							}
							while (num6 <= 1);
							val24.Cells[0, 0].TextString = clsTextos.TiraNothing(mFiacao[iIndice].sLM);
							val24.Cells[0, 1].TextString = mFiacao[iIndice].Pagina12.ToString();
							val24.SetRowHeight(rowHeight);
							((BlockReference)val24).Position = position;
							dY = 0.0;
							dX = 0.0;
							((Entity)val24).ColorIndex = ConfRelFiacao.CorLinha;
							DeclaracoesGeral.bAnularEventos = true;
							val24.TableStyle = database.Tablestyle;
							DeclaracoesGeral.bAnularEventos = false;
							val24.GenerateLayout();
							val5.AppendEntity((Entity)(object)val24);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val24, true);
							val24.RecomputeTableBlock(true);
							((DBObject)val24).UpgradeOpen();
							val24.SetRowHeight(rowHeight);
							dX = num;
							dY = YInicio;
							DBObjectCollection val26 = new DBObjectCollection();
							try
							{
								DeclaracoesGeral.bAnularEventos = true;
								val24.TableStyle = database.Tablestyle;
								DeclaracoesGeral.bAnularEventos = false;
								((Entity)val24).Explode(val26);
								((DBObject)val24).Erase();
								foreach (Entity item4 in val26)
								{
									Entity val27 = item4;
									MText val28 = (MText)(object)((val27 is MText) ? val27 : null);
									try
									{
										if (val28 != null)
										{
											((Entity)val28).ColorIndex = ConfRelFiacao.CorTexto;
											((Entity)val28).Layer = DeclaracoesGeral.ativo.Pagina;
											if (Operators.CompareString(val28.Text, "##B##", TextCompare: true) != 0)
											{
												val5.AppendEntity((Entity)(object)val28);
												DeclaracoesGeral.bAnularEventos = true;
												val2.AddNewlyCreatedDBObject((DBObject)(object)val28, true);
												Entity Ent = (Entity)(object)val28;
												XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
											}
										}
									}
									finally
									{
										((IDisposable)val28)?.Dispose();
									}
									Line val29 = (Line)(object)((val27 is Line) ? val27 : null);
									try
									{
										if (val29 != null)
										{
											((Entity)val29).Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity((Entity)(object)val29);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val29, true);
											Entity Ent = (Entity)(object)val29;
											XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val29)?.Dispose();
									}
									((DisposableWrapper)val27).Dispose();
								}
							}
							finally
							{
								((IDisposable)val26)?.Dispose();
							}
							((DisposableWrapper)val24).Dispose();
						}
						else
						{
							Table val30 = new Table();
							((Entity)val30).Layer = DeclaracoesGeral.ativo.Pagina;
							val30.SetSize(1, 1);
							val30.GenerateLayout();
							val30.RecomputeTableBlock(true);
							dX = pt.X;
							dY = pt.Y;
							dY -= ConfRelFiacao.AlturaDoBloco / 2.0;
							Point3d position = (((BlockReference)val30).Position = new Point3d(dX, dY, 0.0));
							val30.Columns[0].Width = dLarguraDoBloco + 36.0;
							val30.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
							((CellRange)val30.Cells[0, 0]).TextHeight = ConfRelFiacao.TamanhoFonte + ConfRelFiacao.TamanhoFonte / 2.0;
							((CellRange)val30.Cells[0, 0]).Alignment = (CellAlignment)5;
							val30.Cells[0, 0].TextString = mFiacao[iIndice].Tag.ToString();
							((BlockReference)val30).Position = position;
							dY = 0.0;
							dX = 0.0;
							((Entity)val30).ColorIndex = ConfRelFiacao.CorLinha;
							DeclaracoesGeral.bAnularEventos = true;
							val30.TableStyle = database.Tablestyle;
							DeclaracoesGeral.bAnularEventos = false;
							val30.GenerateLayout();
							val5.AppendEntity((Entity)(object)val30);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val30, true);
							val30.RecomputeTableBlock(true);
							((DBObject)val30).UpgradeOpen();
							val30.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
							value = ((Drawable)val30).Bounds.Value;
							val7 = value.MinPoint;
							dX = val7.X;
							value = ((Drawable)val30).Bounds.Value;
							val7 = value.MinPoint;
							dY = val7.Y;
							DBObjectCollection val32 = new DBObjectCollection();
							try
							{
								DeclaracoesGeral.bAnularEventos = true;
								val30.TableStyle = database.Tablestyle;
								DeclaracoesGeral.bAnularEventos = false;
								((Entity)val30).Explode(val32);
								((DBObject)val30).Erase();
								foreach (Entity item5 in val32)
								{
									Entity Ent2 = item5;
									MText val33 = (MText)(object)((Ent2 is MText) ? Ent2 : null);
									try
									{
										if (val33 != null && Operators.CompareString(val33.Text, "##B##", TextCompare: true) != 0)
										{
											((Entity)val33).ColorIndex = ConfRelFiacao.CorTexto;
											((Entity)val33).Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity((Entity)(object)val33);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val33, true);
											Entity Ent = (Entity)(object)val33;
											XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val33)?.Dispose();
									}
									Line val34 = (Line)(object)((Ent2 is Line) ? Ent2 : null);
									try
									{
										if (val34 != null)
										{
											Ent2.Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity(Ent2);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)Ent2, true);
											XDataRelatorio.GravarXDataFiacao(ref Ent2, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val34)?.Dispose();
									}
									((DisposableWrapper)Ent2).Dispose();
								}
							}
							finally
							{
								((IDisposable)val32)?.Dispose();
							}
							((DisposableWrapper)val30).Dispose();
							Table val35 = new Table();
							((Entity)val35).Layer = DeclaracoesGeral.ativo.Pagina;
							val35.SetSize(1, 3);
							val35.GenerateLayout();
							val35.RecomputeTableBlock(true);
							position = (((BlockReference)val35).Position = new Point3d(dX, dY, 0.0));
							val35.Columns[0].Width = 18.0;
							val35.Columns[1].Width = dLarguraDoBloco;
							val35.Columns[2].Width = 18.0;
							val35.SetRowHeight(ConfRelFiacao.AlturaDoBloco * 2.0);
							int num7 = 0;
							do
							{
								((CellRange)val35.Cells[0, num7]).TextHeight = ConfRelFiacao.TamanhoFonte;
								((CellRange)val35.Cells[0, num7]).Alignment = (CellAlignment)5;
								num7++;
							}
							while (num7 <= 2);
							val35.Cells[0, 0].TextString = mFiacao[0].Terminal.ToString();
							val35.Cells[0, 1].TextString = DeclaracoesGeral.mMensagem[1, 262].ToString();
							val35.Cells[0, 2].TextString = DeclaracoesGeral.mMensagem[1, 254].ToString();
							((BlockReference)val35).Position = position;
							dY = 0.0;
							dX = 0.0;
							((Entity)val35).ColorIndex = ConfRelFiacao.CorLinha;
							DeclaracoesGeral.bAnularEventos = true;
							val35.TableStyle = database.Tablestyle;
							DeclaracoesGeral.bAnularEventos = false;
							val35.GenerateLayout();
							val5.AppendEntity((Entity)(object)val35);
							DeclaracoesGeral.bAnularEventos = true;
							val2.AddNewlyCreatedDBObject((DBObject)(object)val35, true);
							val35.RecomputeTableBlock(true);
							((DBObject)val35).UpgradeOpen();
							val35.SetRowHeight(ConfRelFiacao.AlturaDoBloco);
							value = ((Drawable)val35).Bounds.Value;
							val7 = value.MinPoint;
							dX = val7.X;
							value = ((Drawable)val35).Bounds.Value;
							val7 = value.MinPoint;
							dY = val7.Y - ConfRelFiacao.AlturaDoBloco;
							DBObjectCollection val37 = new DBObjectCollection();
							try
							{
								DeclaracoesGeral.bAnularEventos = true;
								val35.TableStyle = database.Tablestyle;
								DeclaracoesGeral.bAnularEventos = false;
								((Entity)val35).Explode(val37);
								((DBObject)val35).Erase();
								foreach (Entity item6 in val37)
								{
									Entity val38 = item6;
									MText val39 = (MText)(object)((val38 is MText) ? val38 : null);
									try
									{
										if (val39 != null && Operators.CompareString(val39.Text, "##B##", TextCompare: true) != 0)
										{
											((Entity)val39).ColorIndex = ConfRelFiacao.CorTexto;
											((Entity)val39).Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity((Entity)(object)val39);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val39, true);
											Entity Ent = (Entity)(object)val39;
											XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val39)?.Dispose();
									}
									Line val40 = (Line)(object)((val38 is Line) ? val38 : null);
									try
									{
										if (val40 != null)
										{
											((Entity)val40).Layer = DeclaracoesGeral.ativo.Pagina;
											val5.AppendEntity((Entity)(object)val40);
											DeclaracoesGeral.bAnularEventos = true;
											val2.AddNewlyCreatedDBObject((DBObject)(object)val40, true);
											Entity Ent = (Entity)(object)val40;
											XDataRelatorio.GravarXDataFiacao(ref Ent, sTipoRelatorio, iPainel);
										}
									}
									finally
									{
										((IDisposable)val40)?.Dispose();
									}
									((DisposableWrapper)val38).Dispose();
								}
							}
							finally
							{
								((IDisposable)val37)?.Dispose();
							}
							((DisposableWrapper)val35).Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val3)?.Dispose();
					}
					Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError(ex);
					Exception ex2 = ex;
					Interaction.MsgBox(ex2.Message);
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

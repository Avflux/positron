using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;

namespace Eletron4;

public class Relatorios_VeiasCopelDWG
{
	public static void CriaListaVeiasCOPEL(clsVeias.StructureVeias[] MCabos, Declaracoes2.ConfRelatorio ConfRel, bool cBComprimento)
	{
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0415: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		double dX = 0.0;
		double dY = 0.0;
		double num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num -= ConfRel.DistEntreColunas * (double)(ConfRel.QuantColunas + 1);
			num /= (double)ConfRel.QuantColunas;
			double num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - dX - (double)ConfRel.QuantColunas * num;
			num2 /= (double)(ConfRel.QuantColunas + 1);
			string sTipoRelatorio = "VEIASCOPEL";
			Point3d pt = new Point3d(RH.Pti.X + 3.0, RH.Pti.Y - ConfRel.AlturaInicial, 0.0);
			Point3d pt2 = new Point3d(RH.Pti.X + 3.0, RH.Pti.Y - ConfRel.AlturaInicial, 0.0);
			try
			{
				Dicionario.CriaTableStyleRelatorios(ConfRel.sFonte);
				double dProxLinha = 1.0;
				DeclaracoesGeral._uscPagina.pbIniciar();
				DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(MCabos);
				dProxLinha = CriaTituloVeia(num, pt, 0, ref dY, ref dX, sTipoRelatorio, ConfRel, dProxLinha, cBComprimento);
				double num3 = dX;
				List<string> list = new List<string>();
				List<string> lValor = new List<string>();
				int num4 = Information.UBound(MCabos);
				for (int i = 1; i <= num4; i++)
				{
					if (!list.Contains(MCabos[i].sTag))
					{
						list.Add(MCabos[i].sTag);
					}
				}
				int num5 = 0;
				foreach (string item in list)
				{
					int num6 = 0;
					clsVeias.StructureVeias[] array = new clsVeias.StructureVeias[1];
					num5++;
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
					int num7 = Information.UBound(MCabos);
					for (int j = 1; j <= num7; j++)
					{
						if (Operators.CompareString(MCabos[j].sTag, item, TextCompare: true) == 0)
						{
							num6++;
							array = (clsVeias.StructureVeias[])Utils.CopyArray(array, new clsVeias.StructureVeias[num6 + 1]);
							array[num6] = MCabos[j];
						}
					}
					pt = new Point3d(num3, dProxLinha, 0.0);
					if (Operators.CompareString(array[1].sTag, "", TextCompare: true) != 0)
					{
						dProxLinha = CriaVeiaUmaLinha(array, ref array[1].sTag, sTipoRelatorio, num, 0.07, "C", ref pt, ConfRel, num5, dProxLinha);
						if (dProxLinha < RH.AltBase)
						{
							string pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, pag, TextCompare: true) == 0)
							{
								if (!Pagina.criarUmaNovaPagina())
								{
									break;
								}
								DeclaracoesGeral._uscPagina.CarregaPG();
								pag = Pagina.montaNumeroPagina(Pagina.EncontraProximaPagina(DeclaracoesGeral.ativo.Pagina));
							}
							Pagina.AtivaPagina(pag);
							DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref pag);
							ApagaRelatorioDeVeiasCopel(num5.ToString());
							dProxLinha = CriaTituloVeia(num, pt2, 0, ref dY, ref dX, sTipoRelatorio, ConfRel, dProxLinha, cBComprimento);
							num3 = dX;
							pt = new Point3d(num3, dProxLinha, 0.0);
							dProxLinha = CriaVeiaUmaLinha(array, ref array[1].sTag, sTipoRelatorio, num, 0.07, "C", ref pt, ConfRel, num5, dProxLinha);
						}
						dProxLinha = CriaVeiaUmaLinha(array, ref array[1].sFormacao, sTipoRelatorio, num, 0.07, "C", ref pt, ConfRel, num5, dProxLinha);
						dProxLinha = CriaVeiaUmaLinha(array, ref array[1].sFuncao, sTipoRelatorio, num, 0.15, "E", ref pt, ConfRel, num5, dProxLinha);
						lValor.Clear();
						clsVeias.StructureVeias[] array2 = array;
						for (int k = 0; k < array2.Length; k++)
						{
							clsVeias.StructureVeias structureVeias = array2[k];
							lValor.Add(structureVeias.sVeia);
						}
						dProxLinha = CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.04, "C", ref pt, ConfRel, num5, dProxLinha);
						dProxLinha = CriaVeiaUmaLinha(array, ref array[1].sPainel1, sTipoRelatorio, num, 0.07, "C", ref pt, ConfRel, num5, dProxLinha);
						lValor.Clear();
						clsVeias.StructureVeias[] array3 = array;
						for (int l = 0; l < array3.Length; l++)
						{
							clsVeias.StructureVeias structureVeias2 = array3[l];
							lValor.Add(structureVeias2.sDisp1);
						}
						dProxLinha = CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.06, "C", ref pt, ConfRel, num5, dProxLinha);
						lValor.Clear();
						clsVeias.StructureVeias[] array4 = array;
						for (int m = 0; m < array4.Length; m++)
						{
							clsVeias.StructureVeias structureVeias3 = array4[m];
							lValor.Add(structureVeias3.sBorne1);
						}
						dProxLinha = CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.05, "C", ref pt, ConfRel, num5, dProxLinha);
						lValor.Clear();
						clsVeias.StructureVeias[] array5 = array;
						for (int n = 0; n < array5.Length; n++)
						{
							clsVeias.StructureVeias structureVeias4 = array5[n];
							lValor.Add(structureVeias4.sAterrar1);
						}
						dProxLinha = CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.06, "C", ref pt, ConfRel, num5, dProxLinha);
						dProxLinha = CriaVeiaUmaLinha(array, ref array[1].sPainel2, sTipoRelatorio, num, 0.07, "C", ref pt, ConfRel, num5, dProxLinha);
						lValor.Clear();
						clsVeias.StructureVeias[] array6 = array;
						for (int num8 = 0; num8 < array6.Length; num8++)
						{
							clsVeias.StructureVeias structureVeias5 = array6[num8];
							lValor.Add(structureVeias5.sDisp2);
						}
						dProxLinha = CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.06, "C", ref pt, ConfRel, num5, dProxLinha);
						lValor.Clear();
						clsVeias.StructureVeias[] array7 = array;
						for (int num9 = 0; num9 < array7.Length; num9++)
						{
							clsVeias.StructureVeias structureVeias6 = array7[num9];
							lValor.Add(structureVeias6.sBorne2);
						}
						dProxLinha = CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.05, "C", ref pt, ConfRel, num5, dProxLinha);
						lValor.Clear();
						clsVeias.StructureVeias[] array8 = array;
						for (int num10 = 0; num10 < array8.Length; num10++)
						{
							clsVeias.StructureVeias structureVeias7 = array8[num10];
							lValor.Add(structureVeias7.sAterrar2);
						}
						dProxLinha = CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.06, "C", ref pt, ConfRel, num5, dProxLinha);
						dProxLinha = ((!cBComprimento) ? CriaVeiaUmaLinha(array, ref array[1].sDiagrama, sTipoRelatorio, num, 0.13, "C", ref pt, ConfRel, num5, dProxLinha) : CriaVeiaUmaLinha(array, ref array[1].sDiagrama, sTipoRelatorio, num, 0.1, "C", ref pt, ConfRel, num5, dProxLinha));
						lValor.Clear();
						clsVeias.StructureVeias[] array9 = array;
						for (int num11 = 0; num11 < array9.Length; num11++)
						{
							clsVeias.StructureVeias structureVeias8 = array9[num11];
							string text = "";
							string text2 = clsTextos.TiraNothing(structureVeias8.sPagina1);
							string text3 = clsTextos.TiraNothing(structureVeias8.sPagina2);
							if (!((Operators.CompareString(text2, "", TextCompare: true) != 0) & (Operators.CompareString(text3, "", TextCompare: true) != 0)))
							{
								if (Operators.CompareString(text2, "", TextCompare: true) != 0)
								{
									text = text2;
								}
								if (Operators.CompareString(text3, "", TextCompare: true) != 0)
								{
									text = ((Operators.CompareString(text, "", TextCompare: true) != 0) ? (text + "; " + text3) : text3);
								}
							}
							else if (Operators.CompareString(text2, text3, TextCompare: true) != 0)
							{
								text = ((Operators.CompareString(text2, text3, TextCompare: true) < 0) ? (text2 + "; " + text3) : (text3 + "; " + text2));
							}
							else
							{
								text = text2;
							}
							lValor.Add(text);
						}
						dProxLinha = ((!cBComprimento) ? CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.06, "C", ref pt, ConfRel, num5, dProxLinha) : CriaVeiaVariasLinha(array, ref lValor, sTipoRelatorio, num, 0.05, "C", ref pt, ConfRel, num5, dProxLinha));
						if (cBComprimento)
						{
							lValor.Clear();
							lValor.Add("");
							lValor.Add(Conversions.ToString(array[1].dComprimento));
							clsVeias.StructureVeias[] cabo = array;
							ref double dComprimento = ref array[1].dComprimento;
							string sValor = Conversions.ToString(dComprimento);
							double num12 = CriaVeiaUmaLinha(cabo, ref sValor, sTipoRelatorio, num, 0.04, "C", ref pt, ConfRel, num5, dProxLinha);
							dComprimento = Conversions.ToDouble(sValor);
							dProxLinha = num12;
						}
						pt = new Point3d(num3, dProxLinha, 0.0);
					}
					DeclaracoesGeral._uscPagina.pbPasso();
					if (DeclaracoesGeral.bPararRelatorio)
					{
						break;
					}
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

	public static double CriaTituloVeia(double dLargura, Point3d pt, int iIndice, ref double dY, ref double dX, string sTipoRelatorio, Declaracoes2.ConfRelatorio confRel, double dProxLinha, bool cbComprimento)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected Obj, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Expected Obj, but got Unknown
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Expected Obj, but got Unknown
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c6: Expected Obj, but got Unknown
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_09fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acb: Expected Obj, but got Unknown
		//IL_0ad4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b10: Expected Obj, but got Unknown
		//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c41: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c23: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c28: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				dProxLinha = 0.0;
				int num = 14;
				if (cbComprimento)
				{
					num = 15;
				}
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					_ = ((SymbolTable)val3)[confRel.sFonte];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(1, 4);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
					val6.Columns[0].Width = dLargura * 0.33;
					val6.Columns[1].Width = dLargura * 0.24;
					val6.Columns[2].Width = dLargura * 0.24;
					val6.Columns[3].Width = dLargura * 0.19;
					val6.SetRowHeight(confRel.AlturaDoBloco);
					int num2 = 0;
					do
					{
						((CellRange)val6.Cells[0, num2]).TextHeight = confRel.TamanhoFonte;
						((CellRange)val6.Cells[0, num2]).Alignment = (CellAlignment)5;
						num2++;
					}
					while (num2 <= 3);
					val6.Cells[0, 0].TextString = DeclaracoesGeral.mMensagem[1, 1288].ToString().ToUpper();
					val6.Cells[0, 1].TextString = DeclaracoesGeral.mMensagem[1, 48].ToString().ToUpper();
					val6.Cells[0, 2].TextString = DeclaracoesGeral.mMensagem[1, 49].ToString().ToUpper();
					val6.Cells[0, 3].TextString = DeclaracoesGeral.mMensagem[1, 115].ToString().ToUpper();
					((BlockReference)val6).Position = position;
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d val8 = value.MinPoint;
					dX = val8.X;
					value = ((Drawable)val6).Bounds.Value;
					val8 = value.MinPoint;
					dY = val8.Y;
					((Entity)val6).ColorIndex = confRel.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					((DBObject)val6).UpgradeOpen();
					val6.SetRowHeight(confRel.AlturaDoBloco);
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
								((Entity)val10).ColorIndex = confRel.CorTexto;
								((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
								if (Operators.CompareString(val10.Text, "##B##", TextCompare: true) != 0)
								{
									val5.AppendEntity((Entity)(object)val10);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
									Entity Ent2 = (Entity)(object)val10;
									XDataRelatorio.GravarXDataVeiasCopel(ref Ent2, sTipoRelatorio, iIndice);
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
								double num3 = dY;
								value = ((Drawable)val11).Bounds.Value;
								val8 = value.MinPoint;
								if (num3 > val8.Y)
								{
									value = ((Drawable)val11).Bounds.Value;
									val8 = value.MinPoint;
									dY = val8.Y;
								}
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
								XDataRelatorio.GravarXDataVeiasCopel(ref Ent, sTipoRelatorio, iIndice);
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
					val12.SetSize(1, num);
					val12.GenerateLayout();
					val12.RecomputeTableBlock(true);
					position = (((BlockReference)val12).Position = new Point3d(dX, dY, 0.0));
					val12.Columns[0].Width = dLargura * 0.07;
					val12.Columns[1].Width = dLargura * 0.07;
					val12.Columns[2].Width = dLargura * 0.15;
					val12.Columns[3].Width = dLargura * 0.04;
					val12.Columns[4].Width = dLargura * 0.07;
					val12.Columns[5].Width = dLargura * 0.06;
					val12.Columns[6].Width = dLargura * 0.05;
					val12.Columns[7].Width = dLargura * 0.06;
					val12.Columns[8].Width = dLargura * 0.07;
					val12.Columns[9].Width = dLargura * 0.06;
					val12.Columns[10].Width = dLargura * 0.05;
					val12.Columns[11].Width = dLargura * 0.06;
					val12.Columns[12].Width = dLargura * 0.13;
					val12.Columns[13].Width = dLargura * 0.06;
					if (cbComprimento)
					{
						val12.Columns[12].Width = dLargura * 0.1;
						val12.Columns[13].Width = dLargura * 0.05;
						val12.Columns[14].Width = dLargura * 0.04;
					}
					val12.SetRowHeight(confRel.AlturaDoBloco);
					int num4 = num - 1;
					for (int i = 0; i <= num4; i++)
					{
						((CellRange)val12.Cells[0, i]).TextHeight = confRel.TamanhoFonte;
						((CellRange)val12.Cells[0, i]).Alignment = (CellAlignment)5;
					}
					val12.Cells[0, 0].TextString = DeclaracoesGeral.mMensagem[1, 371].ToString().ToUpper();
					val12.Cells[0, 1].TextString = DeclaracoesGeral.mMensagem[1, 1285].ToString().ToUpper();
					val12.Cells[0, 2].TextString = DeclaracoesGeral.mMensagem[1, 1244].ToString().ToUpper();
					val12.Cells[0, 3].TextString = DeclaracoesGeral.mMensagem[1, 1569].ToString().ToUpper();
					val12.Cells[0, 4].TextString = DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper();
					val12.Cells[0, 5].TextString = DeclaracoesGeral.mMensagem[1, 1336].ToString().ToUpper();
					val12.Cells[0, 6].TextString = DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper();
					val12.Cells[0, 7].TextString = DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper();
					val12.Cells[0, 8].TextString = DeclaracoesGeral.mMensagem[1, 1081].ToString().ToUpper();
					val12.Cells[0, 9].TextString = DeclaracoesGeral.mMensagem[1, 1336].ToString().ToUpper();
					val12.Cells[0, 10].TextString = DeclaracoesGeral.mMensagem[1, 1429].ToString().ToUpper();
					val12.Cells[0, 11].TextString = DeclaracoesGeral.mMensagem[1, 1243].ToString().ToUpper();
					val12.Cells[0, 12].TextString = DeclaracoesGeral.mMensagem[1, 373].ToString().ToUpper();
					val12.Cells[0, 13].TextString = DeclaracoesGeral.mMensagem[1, 9].ToString().ToUpper();
					if (cbComprimento)
					{
						val12.Cells[0, 14].TextString = DeclaracoesGeral.mMensagem[1, 1246].ToString().ToUpper();
					}
					val12.SetRowHeight(confRel.AlturaDoBloco);
					((BlockReference)val12).Position = position;
					value = ((Drawable)val6).Bounds.Value;
					val8 = value.MinPoint;
					dY = val8.Y;
					value = ((Drawable)val6).Bounds.Value;
					val8 = value.MinPoint;
					dX = val8.X;
					pt = new Point3d(dX, dY, 0.0);
					((Entity)val12).ColorIndex = confRel.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val12.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val12.GenerateLayout();
					val5.AppendEntity((Entity)(object)val12);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
					val12.RecomputeTableBlock(true);
					((DBObject)val12).UpgradeOpen();
					val12.SetRowHeight(confRel.AlturaDoBloco);
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
							if (val15 != null)
							{
								((Entity)val15).ColorIndex = confRel.CorTexto;
								((Entity)val15).Layer = DeclaracoesGeral.ativo.Pagina;
								if (Operators.CompareString(val15.Text, "##B##", TextCompare: true) != 0)
								{
									val5.AppendEntity((Entity)(object)val15);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val15, true);
									Entity Ent2 = (Entity)(object)val15;
									XDataRelatorio.GravarXDataVeiasCopel(ref Ent2, sTipoRelatorio, iIndice);
								}
							}
						}
						finally
						{
							((IDisposable)val15)?.Dispose();
						}
						Line val16 = (Line)(object)((Ent3 is Line) ? Ent3 : null);
						try
						{
							if (val16 != null)
							{
								Ent3.Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity(Ent3);
								double num5 = dY;
								value = ((Drawable)val16).Bounds.Value;
								val8 = value.MinPoint;
								if (num5 > val8.Y)
								{
									value = ((Drawable)val16).Bounds.Value;
									val8 = value.MinPoint;
									dY = val8.Y;
								}
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)Ent3, true);
								XDataRelatorio.GravarXDataVeiasCopel(ref Ent3, sTipoRelatorio, iIndice);
								if (dProxLinha == 0.0)
								{
									val8 = val16.StartPoint;
									dProxLinha = val8.Y;
								}
								val8 = val16.StartPoint;
								if (val8.Y < dProxLinha)
								{
									val8 = val16.StartPoint;
									dProxLinha = val8.Y;
								}
							}
						}
						finally
						{
							((IDisposable)val16)?.Dispose();
						}
						((DisposableWrapper)Ent3).Dispose();
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
			return dProxLinha;
		}
	}

	public static double CriaVeiaUmaLinha(clsVeias.StructureVeias[] Cabo, ref string sValor, string sTipoRelatorio, double dLarguraDoBloco, double dLarguraDaColuna, string sOrientacao, ref Point3d pt, Declaracoes2.ConfRelatorio confRel, int iIndice, double dProxLinha)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected Obj, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Expected Obj, but got Unknown
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_035c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
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
					double num = 0.0;
					double num2 = 0.0;
					try
					{
						TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
						_ = ((SymbolTable)val3)[confRel.sFonte];
						new DBObjectCollection();
						BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
						BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
						Table val6 = new Table();
						((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
						val6.SetSize(1, 1);
						val6.GenerateLayout();
						val6.RecomputeTableBlock(true);
						((BlockReference)val6).Position = pt;
						val6.Columns[0].Width = dLarguraDoBloco * dLarguraDaColuna;
						val6.SetRowHeight(confRel.AlturaDoBloco * 2.0);
						int num3 = 0;
						do
						{
							((CellRange)val6.Cells[0, num3]).TextHeight = confRel.TamanhoFonte;
							if (Operators.CompareString(sOrientacao, "E", TextCompare: true) != 0)
							{
								if (Operators.CompareString(sOrientacao, "C", TextCompare: true) != 0)
								{
									if (Operators.CompareString(sOrientacao, "D", TextCompare: true) == 0)
									{
										((CellRange)val6.Cells[0, num3]).Alignment = (CellAlignment)6;
									}
								}
								else
								{
									((CellRange)val6.Cells[0, num3]).Alignment = (CellAlignment)5;
								}
							}
							else
							{
								((CellRange)val6.Cells[0, num3]).Alignment = (CellAlignment)4;
							}
							num3++;
						}
						while (num3 <= 0);
						val6.Cells[0, 0].TextString = sValor;
						val6.SetRowHeight(confRel.AlturaDoBloco * (double)(Cabo.Count() - 1));
						((BlockReference)val6).Position = pt;
						((Entity)val6).ColorIndex = confRel.CorLinha;
						DeclaracoesGeral.bAnularEventos = true;
						val6.TableStyle = database.Tablestyle;
						DeclaracoesGeral.bAnularEventos = false;
						val6.GenerateLayout();
						val5.AppendEntity((Entity)(object)val6);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
						val6.RecomputeTableBlock(true);
						((DBObject)val6).UpgradeOpen();
						val6.SetRowHeight(confRel.AlturaDoBloco * 2.0);
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
									((Entity)val8).ColorIndex = confRel.CorTexto;
									((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
									val5.AppendEntity((Entity)(object)val8);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
									Entity Ent2 = (Entity)(object)val8;
									XDataRelatorio.GravarXDataVeiasCopel(ref Ent2, sTipoRelatorio, iIndice);
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
									XDataRelatorio.GravarXDataVeiasCopel(ref Ent, sTipoRelatorio, iIndice);
									Point3d val10;
									if (dProxLinha == 0.0)
									{
										val10 = val9.StartPoint;
										dProxLinha = val10.Y;
									}
									val10 = val9.StartPoint;
									if (val10.Y < dProxLinha)
									{
										val10 = val9.StartPoint;
										dProxLinha = val10.Y;
									}
									if (num2 == 0.0)
									{
										val10 = val9.EndPoint;
										num2 = val10.X;
									}
									val10 = val9.EndPoint;
									if (val10.X > num2)
									{
										val10 = val9.EndPoint;
										num2 = val10.X;
									}
									val10 = val9.StartPoint;
									if (val10.X > num2)
									{
										val10 = val9.StartPoint;
										num2 = val10.X;
									}
									if (num == 0.0)
									{
										val10 = val9.EndPoint;
										num = val10.Y;
									}
									val10 = val9.EndPoint;
									if (val10.Y > num2)
									{
										val10 = val9.EndPoint;
										num = val10.Y;
									}
									val10 = val9.StartPoint;
									if (val10.Y > num2)
									{
										val10 = val9.StartPoint;
										num = val10.Y;
									}
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
						pt = new Point3d(num2, num, 0.0);
						Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						val2.Abort();
						ProjectData.ClearProjectError();
					}
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
			return dProxLinha;
		}
	}

	public static double CriaVeiaVariasLinha(clsVeias.StructureVeias[] Cabo, ref List<string> lValor, string sTipoRelatorio, double dLarguraDoBloco, double dLarguraDaColuna, string sOrientacao, ref Point3d pt, Declaracoes2.ConfRelatorio confRel, int iIndice, double dProxLinha)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Obj, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected Obj, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected Obj, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected Obj, but got Unknown
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected Obj, but got Unknown
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Unknown result type (might be due to invalid IL or missing references)
		//IL_0519: Unknown result type (might be due to invalid IL or missing references)
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Unknown result type (might be due to invalid IL or missing references)
		//IL_052b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_049f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		lValor.RemoveAt(0);
		checked
		{
			int num = lValor.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				lValor[i] = clsTextos.TiraNothing(lValor[i]);
				if (Operators.CompareString(lValor[i], "", TextCompare: true) == 0)
				{
					lValor[i] = "#B#";
				}
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				Database database = mdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					_ = ((SymbolTable)val3)[confRel.sFonte];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					double num2 = 0.0;
					double num3 = 0.0;
					Table val6 = new Table();
					int num4 = Cabo.Count() - 1;
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(num4, 1);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					((BlockReference)val6).Position = pt;
					val6.Columns[0].Width = dLarguraDoBloco * dLarguraDaColuna;
					val6.SetRowHeight(confRel.AlturaDoBloco);
					int num5 = -1;
					foreach (string item in lValor)
					{
						num5++;
						((CellRange)val6.Cells[num5, 0]).TextHeight = confRel.TamanhoFonte;
						if (Operators.CompareString(sOrientacao, "E", TextCompare: true) != 0)
						{
							if (Operators.CompareString(sOrientacao, "C", TextCompare: true) != 0)
							{
								if (Operators.CompareString(sOrientacao, "D", TextCompare: true) == 0)
								{
									((CellRange)val6.Cells[num5, 0]).Alignment = (CellAlignment)6;
								}
							}
							else
							{
								((CellRange)val6.Cells[num5, 0]).Alignment = (CellAlignment)5;
							}
						}
						else
						{
							((CellRange)val6.Cells[num5, 0]).Alignment = (CellAlignment)4;
						}
						val6.Cells[num5, 0].TextString = item;
					}
					val6.SetRowHeight(confRel.AlturaDoBloco);
					((BlockReference)val6).Position = pt;
					((Entity)val6).ColorIndex = confRel.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					((DBObject)val6).UpgradeOpen();
					val6.SetRowHeight(confRel.AlturaDoBloco);
					DBObjectCollection val7 = new DBObjectCollection();
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					((Entity)val6).Explode(val7);
					((DBObject)val6).Erase();
					foreach (Entity item2 in val7)
					{
						Entity Ent = item2;
						MText val8 = (MText)(object)((Ent is MText) ? Ent : null);
						try
						{
							if (val8 != null && Operators.CompareString(val8.Text, "#B#", TextCompare: true) != 0)
							{
								((Entity)val8).ColorIndex = confRel.CorTexto;
								((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
								val5.AppendEntity((Entity)(object)val8);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
								Entity Ent2 = (Entity)(object)val8;
								XDataRelatorio.GravarXDataVeiasCopel(ref Ent2, sTipoRelatorio, iIndice);
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
								XDataRelatorio.GravarXDataVeiasCopel(ref Ent, sTipoRelatorio, iIndice);
								Point3d val10;
								if (dProxLinha == 0.0)
								{
									val10 = val9.StartPoint;
									dProxLinha = val10.Y;
								}
								val10 = val9.StartPoint;
								if (val10.Y < dProxLinha)
								{
									val10 = val9.StartPoint;
									dProxLinha = val10.Y;
								}
								if (num3 == 0.0)
								{
									val10 = val9.EndPoint;
									num3 = val10.X;
								}
								val10 = val9.EndPoint;
								if (val10.X > num3)
								{
									val10 = val9.EndPoint;
									num3 = val10.X;
								}
								val10 = val9.StartPoint;
								if (val10.X > num3)
								{
									val10 = val9.StartPoint;
									num3 = val10.X;
								}
								if (num2 == 0.0)
								{
									val10 = val9.EndPoint;
									num2 = val10.Y;
								}
								val10 = val9.EndPoint;
								if (val10.Y > num3)
								{
									val10 = val9.EndPoint;
									num2 = val10.Y;
								}
								val10 = val9.StartPoint;
								if (val10.Y > num3)
								{
									val10 = val9.StartPoint;
									num2 = val10.Y;
								}
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
					pt = new Point3d(num3, num2, 0.0);
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
			return dProxLinha;
		}
	}

	public static void ApagaRelatorioDeVeiasCopel(string sIndex)
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
						int iIndice = 0;
						string sRel = "VEIASCOPEL";
						if (!XDataRelatorio.LerXDataVeiasCopel(ref Ent, ref sRel, ref iIndice))
						{
							continue;
						}
						if (Operators.CompareString(sIndex, "0", TextCompare: true) != 0)
						{
							if (Operators.CompareString(iIndice.ToString(), sIndex, TextCompare: true) == 0)
							{
								((DBObject)Ent).UpgradeOpen();
								((DBObject)Ent).Erase();
							}
						}
						else
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

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

public class Relatorios_Rev
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

		public int i1;

		public int i2;

		public int i3;
	}

	public static string EncontraPaginasUsadasEmUmaRevisao(string sRevisao, bool bAgrupa)
	{
		string text = "";
		List<string> list = new List<string>();
		List<string> list2 = new List<string>();
		Revisao.capturaRevisoesSimplificadas();
		int num = Information.UBound(DeclaracoesGeral.mRevSimplificada, 2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				list2.Add(Conversions.ToString(DeclaracoesGeral.mRevSimplificada[0, i]));
				if (Operators.ConditionalCompareObjectEqual(DeclaracoesGeral.mRevSimplificada[1, i], sRevisao, TextCompare: true) && !list.Contains(Conversions.ToString(DeclaracoesGeral.mRevSimplificada[0, i])))
				{
					list.Add(Conversions.ToString(DeclaracoesGeral.mRevSimplificada[0, i]));
				}
			}
			bool flag = true;
			foreach (string item in list2)
			{
				if (!list.Contains(item))
				{
					flag = false;
				}
				else
				{
					text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? item : (text + "; " + item));
				}
			}
			if (flag)
			{
				text = "TODAS";
			}
			if (bAgrupa)
			{
				if (text.Contains(";") | flag)
				{
					text = "";
				}
				string text2 = list[0];
				string text3 = list[0];
				string text4 = "";
				int num2 = list.Count - 2;
				for (int j = 0; j <= num2; j++)
				{
					if (Pagina.calculaPaginaDecimal(text3) + 1.0 != Pagina.calculaPaginaDecimal(list[j + 1]))
					{
						if (Pagina.calculaPaginaDecimal(text2) + 1.0 == Pagina.calculaPaginaDecimal(text3))
						{
							text4 = text2 + "; " + text3;
						}
						if (Operators.CompareString(text, "", TextCompare: true) != 0)
						{
							text = text + "; " + text4;
							text4 = list[j + 1];
						}
						else
						{
							text = text4;
							text4 = list[j + 1];
						}
						text2 = list[j + 1];
						text3 = list[j + 1];
					}
					else
					{
						text3 = list[j + 1];
						text4 = text2 + " a " + text3;
					}
				}
				if (Operators.CompareString(text4, "", TextCompare: true) != 0)
				{
					text = ((Operators.CompareString(text, "", TextCompare: true) == 0) ? text4 : (text + "; " + text4));
				}
			}
			return text;
		}
	}

	public static string capturaDescricaoRevCompleta(string sRev)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		string result = "";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			BlockTableRecordEnumerator enumerator = default;
			try
			{
				enumerator = val3.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
					BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (blockRef != null)
					{
						DeclaracoesGeral.Revisoes revC = default;
						if (XDataRelatorio.LeXDataRevisao(ref blockRef, ref revC) && Operators.CompareString(sRev, revC.Revisao, TextCompare: true) == 0)
						{
							result = revC.Descricao;
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
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			val.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static void CriaRelatorioREvisaoDWG(ConfigReV confRelRev, string sRevisao, string sPaginasRel, string sDescricao)
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.Reguas RH = default;
		XDataGeral.LeXDataReguaH(ref RH);
		if (Operators.CompareString(sDescricao, "", TextCompare: true) == 0)
		{
			sDescricao = "##B##";
		}
		if (Operators.CompareString(sPaginasRel, "", TextCompare: true) == 0)
		{
			sPaginasRel = "##B##";
		}
		if (Operators.CompareString(sRevisao, "", TextCompare: true) == 0)
		{
			sRevisao = "##B##";
		}
		double dX = 0.0;
		double dY = 0.0;
		double YInicio = 0.0;
		double num = 0.0;
		num = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
		checked
		{
			num -= confRelRev.DistEntreColunas * (double)(confRelRev.QuantColunas + 1);
			num /= (double)confRelRev.QuantColunas;
			double num2 = 0.0;
			num2 = (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta - dX - (double)confRelRev.QuantColunas * num;
			num2 /= (double)(confRelRev.QuantColunas + 1);
			Point3d val = new Point3d(RH.Pti.X + confRelRev.DistEntreColunas, RH.Pti.Y - confRelRev.AlturaInicial, 0.0);
			Point3d pt = new Point3d(0.0, 0.0, 0.0);
			int iIndice = 0;
			try
			{
				Dicionario.CriaTableStyleRelatorios(confRelRev.sFonte, 1.0, 1.0);
				int maxcoluna = 1;
				encontraProximaInsercaoRelatorioRevisao(ref pt, ref maxcoluna, ref iIndice);
				if (maxcoluna != -1)
				{
					val = pt;
					double dLarguraDoBloco = num;
					Point3d pt2 = val;
					int iColuna = maxcoluna;
					bool bTitulo = false;
					CriaTabelaRevCompleta(dLarguraDoBloco, pt2, iColuna, ref dY, ref dX, ref YInicio, ref bTitulo, sRevisao, sPaginasRel, sDescricao, iIndice, confRelRev);
					encontraProximaInsercaoRelatorioRevisao(ref pt, ref maxcoluna, ref iIndice);
					if (!(Math.Round(pt.Y, 2) < Math.Round(RH.AltBase, 2)))
					{
						return;
					}
					ApagaUmIndice(sRevisao, maxcoluna, iIndice);
					if (maxcoluna >= confRelRev.QuantColunas)
					{
						maxcoluna = 1;
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
								return;
							}
							DeclaracoesGeral._uscPagina.CarregaPG();
						}
						val = new Point3d(RH.Pti.X + confRelRev.DistEntreColunas, RH.Pti.Y - confRelRev.AlturaInicial, 0.0);
					}
					else
					{
						maxcoluna++;
						val = new Point3d(RH.Pti.X + confRelRev.DistEntreColunas * (double)maxcoluna + num * (double)(maxcoluna - 1), RH.Pti.Y - confRelRev.AlturaInicial, 0.0);
					}
					double dLarguraDoBloco2 = num;
					Point3d pt3 = val;
					int iColuna2 = maxcoluna;
					bTitulo = true;
					CriaTabelaRevCompleta(dLarguraDoBloco2, pt3, iColuna2, ref dY, ref dX, ref YInicio, ref bTitulo, sRevisao, sPaginasRel, sDescricao, iIndice, confRelRev);
					encontraProximaInsercaoRelatorioRevisao(ref pt, ref maxcoluna, ref iIndice);
					val = pt;
					double dLarguraDoBloco3 = num;
					Point3d pt4 = val;
					int iColuna3 = maxcoluna;
					bTitulo = false;
					CriaTabelaRevCompleta(dLarguraDoBloco3, pt4, iColuna3, ref dY, ref dX, ref YInicio, ref bTitulo, sRevisao, sPaginasRel, sDescricao, iIndice, confRelRev);
				}
				else
				{
					maxcoluna = 1;
					double dLarguraDoBloco4 = num;
					Point3d pt5 = val;
					bool bTitulo = true;
					CriaTabelaRevCompleta(dLarguraDoBloco4, pt5, 1, ref dY, ref dX, ref YInicio, ref bTitulo, sRevisao, sPaginasRel, sDescricao, iIndice, confRelRev);
					val = new Point3d(val.X, dY, 0.0);
					double dLarguraDoBloco5 = num;
					Point3d pt6 = val;
					bTitulo = false;
					CriaTabelaRevCompleta(dLarguraDoBloco5, pt6, 1, ref dY, ref dX, ref YInicio, ref bTitulo, sRevisao, sPaginasRel, sDescricao, iIndice, confRelRev);
				}
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				DeclaracoesGeral._uscPagina.pbFim();
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void ApagaUmIndice(string sRevisao, int iColuna, int iIndice)
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
						string sRevisao2 = "";
						int iColuna2 = 0;
						int iIndice2 = 0;
						if (XDataRelatorio.leXDataRevisaoCompleta(ref Ent, ref sRevisao2, ref iColuna2, ref iIndice2) && ((Operators.CompareString(sRevisao2, sRevisao, TextCompare: true) == 0) & (iColuna2 == iColuna) & (iIndice2 == iIndice)))
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

	public static void ApagaRelatorioRevisaoCompleta(string sRevSel)
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
						int iColuna = 0;
						int iIndice = 0;
						if (XDataRelatorio.leXDataRevisaoCompleta(ref Ent, ref sRevisao, ref iColuna, ref iIndice) && Operators.CompareString(sRevSel, sRevisao, TextCompare: true) == 0)
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

	public static void CriaTabelaRevCompleta(double dLarguraDoBloco, Point3d pt, int iColuna, ref double dY, ref double dX, ref double YInicio, ref bool bTitulo, string sRevisao, string sPaginasRel, string sDescricao, int iIndiceRel, ConfigReV confRelRev)
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
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected Obj, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Expected Obj, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Unknown result type (might be due to invalid IL or missing references)
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_043b: Unknown result type (might be due to invalid IL or missing references)
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
					_ = ((SymbolTable)val3)[confRelRev.sFonte];
					new DBObjectCollection();
					BlockTable val4 = (BlockTable)val2.GetObject(mdiActiveDocument.Database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					iIndiceRel++;
					Table val6 = new Table();
					((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.SetSize(1, 3);
					val6.GenerateLayout();
					val6.RecomputeTableBlock(true);
					Point3d position = (((BlockReference)val6).Position = new Point3d(pt.X, pt.Y, 0.0));
					val6.Columns[0].Width = (double)confRelRev.i1 * dLarguraDoBloco / 100.0;
					val6.Columns[1].Width = (double)confRelRev.i2 * dLarguraDoBloco / 100.0;
					val6.Columns[2].Width = (double)confRelRev.i3 * dLarguraDoBloco / 100.0;
					val6.SetRowHeight(confRelRev.AlturaDoBloco);
					int num = 0;
					do
					{
						if (num != 2)
						{
							((CellRange)val6.Cells[0, num]).TextHeight = confRelRev.TamanhoFonte;
							((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)5;
						}
						else
						{
							((CellRange)val6.Cells[0, num]).TextHeight = confRelRev.TamanhoFonte;
							((CellRange)val6.Cells[0, num]).Alignment = (CellAlignment)4;
						}
						num++;
					}
					while (num <= 2);
					if (!bTitulo)
					{
						val6.Cells[0, 0].TextString = sPaginasRel;
						val6.Cells[0, 1].TextString = sRevisao;
						val6.Cells[0, 2].TextString = sDescricao;
					}
					else
					{
						val6.Cells[0, 0].TextString = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 287]);
						val6.Cells[0, 1].TextString = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 380]);
						val6.Cells[0, 2].TextString = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 390]);
					}
					val6.SetRowHeight(confRelRev.AlturaDoBloco);
					((BlockReference)val6).Position = position;
					dY = 100000.0;
					dX = 0.0;
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d minPoint = value.MinPoint;
					dX = minPoint.X;
					((Entity)val6).ColorIndex = confRelRev.CorLinha;
					DeclaracoesGeral.bAnularEventos = true;
					val6.TableStyle = database.Tablestyle;
					DeclaracoesGeral.bAnularEventos = false;
					val6.GenerateLayout();
					val5.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					val6.RecomputeTableBlock(true);
					((DBObject)val6).UpgradeOpen();
					val6.SetRowHeight(confRelRev.AlturaDoBloco);
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
								((Entity)val9).ColorIndex = confRelRev.CorTexto;
								((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
								if (Operators.CompareString(val9.Text, "##B##", TextCompare: true) != 0)
								{
									val5.AppendEntity((Entity)(object)val9);
									DeclaracoesGeral.bAnularEventos = true;
									val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
									Entity Ent2 = (Entity)(object)val9;
									XDataRelatorio.GravarXDataRevisaoCompleta(ref Ent2, sRevisao, iColuna, iIndiceRel, confRelRev.i1, confRelRev.i2, confRelRev.i3);
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
								double num2 = dY;
								value = ((Drawable)val10).Bounds.Value;
								minPoint = value.MinPoint;
								if (num2 > minPoint.Y)
								{
									value = ((Drawable)val10).Bounds.Value;
									minPoint = value.MinPoint;
									dY = minPoint.Y;
								}
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)Ent, true);
								XDataRelatorio.GravarXDataRevisaoCompleta(ref Ent, sRevisao, iColuna, iIndiceRel, confRelRev.i1, confRelRev.i2, confRelRev.i3);
							}
						}
						finally
						{
							((IDisposable)val10)?.Dispose();
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

	public static void encontraProximaInsercaoRelatorioRevisao(ref Point3d pt, ref int maxcoluna, ref int iIndice)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		pt = new Point3d(100000.0, 100000.0, 0.0);
		maxcoluna = -1;
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
						if (Operators.CompareString(Ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
						{
							continue;
						}
						Line val5 = (Line)(object)((Ent is Line) ? Ent : null);
						if (val5 == null)
						{
							continue;
						}
						string sRevisao = "";
						int iColuna = 0;
						int iIndice2 = 0;
						if (!XDataRelatorio.leXDataRevisaoCompleta(ref Ent, ref sRevisao, ref iColuna, ref iIndice2))
						{
							continue;
						}
						Extents3d value;
						Point3d minPoint;
						if (iColuna > maxcoluna)
						{
							maxcoluna = iColuna;
							value = ((Drawable)val5).Bounds.Value;
							minPoint = value.MinPoint;
							double x = minPoint.X;
							value = ((Drawable)val5).Bounds.Value;
							minPoint = value.MinPoint;
							pt = new Point3d(x, minPoint.Y, 0.0);
							iIndice = iIndice2;
						}
						if (maxcoluna == iColuna)
						{
							double x2 = pt.X;
							value = ((Drawable)val5).Bounds.Value;
							minPoint = value.MinPoint;
							if (x2 > minPoint.X)
							{
								value = ((Drawable)val5).Bounds.Value;
								minPoint = value.MinPoint;
								pt = new Point3d(minPoint.X, pt.Y, 0.0);
								iIndice = iIndice2;
							}
							double y = pt.Y;
							value = ((Drawable)val5).Bounds.Value;
							minPoint = value.MinPoint;
							if (y > minPoint.Y)
							{
								double x3 = pt.X;
								value = ((Drawable)val5).Bounds.Value;
								minPoint = value.MinPoint;
								pt = new Point3d(x3, minPoint.Y, 0.0);
								iIndice = iIndice2;
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
	}

	public static void encontraTamanhosDasColunas(ref ConfigReV confRelRev)
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				confRelRev.i1 = 10;
				confRelRev.i2 = 15;
				confRelRev.i3 = 75;
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
						try
						{
							MText val6 = (MText)(object)((val5 is MText) ? val5 : null);
							try
							{
								if (val6 != null)
								{
									Entity Ent = val5;
									if (XDataRelatorio.leXDataBuscaTamanhoColunasRevisaoCompleta(ref Ent, ref confRelRev))
									{
										break;
									}
								}
							}
							finally
							{
								((IDisposable)val6)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)val5)?.Dispose();
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

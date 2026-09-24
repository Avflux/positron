using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class Relatorios_DistribuicaoPot
{
	public struct StructurePotenciais
	{
		public string sNome;

		public int iPotencial;
	}

	public struct StructurePontos
	{
		public string sNome;

		public string sT1;

		public string sSentido;

		public Point3d pt;
	}

	public struct StructurePosicaoBlocos
	{
		public string sNome;

		public string sT1;

		public double sX;

		public double sY;
	}

	public struct StructureTag
	{
		public string sTag;

		public string sRegua;

		public string Terminal;

		public string Pagina;

		public string Indice;

		public string Tipo;

		public string Handle;

		public string POTENCIAL;

		public string sHandle;

		public string sPainel;

		public int iPainel;
	}

	public struct StructureBloco
	{
		public int iPot;

		public int iDwg;

		public string sTipo;

		public int iPn;

		public string sCorr;

		public string sCorrComp;

		public string sDispComp;

		public string sPn;

		public string sRegua;

		public string sNome;

		public string sT1;

		public string sT2;

		public string sHandle;

		public string sRevisao;

		public int Eletron;

		public bool bPrimeiro;

		public bool bMostraPainel;
	}

	public static void CarregaBlocos(ref object mBlocos, string sTipoBloco)
	{
		mBlocos = new object[3, 1];
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 0, 0, "Bloco" }, null);
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 1, 0, "Caminho" }, null);
		NewLateBinding.LateIndexSet(mBlocos, new object[3] { 2, 0, "Nome Completo" }, null);
		DirectoryInfo directoryInfo = new DirectoryInfo(DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Potenciais\\");
		FileInfo[] files = directoryInfo.GetFiles();
		string text = "";
		string sNomeDWGVisivel = "";
		string sDiretorio = "";
		string sTipo = "";
		string sNomeCompleto = "";
		FileInfo[] array = files;
		checked
		{
			foreach (FileInfo fileInfo in array)
			{
				text = fileInfo.FullName;
				if (Operators.CompareString(Strings.UCase(Strings.Mid(text, Strings.Len(text) - 2, 3)), "DWG", TextCompare: true) == 0)
				{
					clsDispositivo.ExtraiNomeCaminhoDwgPorTipo(text, ref sDiretorio, ref sNomeCompleto, ref sNomeDWGVisivel, ref sTipo);
					if (Operators.CompareString(Strings.Mid(sNomeCompleto, 1, 2), "P_", TextCompare: true) == 0)
					{
						mBlocos = Utils.CopyArray((Array)mBlocos, new object[3, Information.UBound((Array)mBlocos, 2) + 1 + 1]);
						NewLateBinding.LateIndexSet(mBlocos, new object[3]
						{
							0,
							Information.UBound((Array)mBlocos, 2),
							Strings.Mid(sNomeCompleto, 3, Strings.Len(sNomeCompleto))
						}, null);
						NewLateBinding.LateIndexSet(mBlocos, new object[3]
						{
							1,
							Information.UBound((Array)mBlocos, 2),
							text
						}, null);
						NewLateBinding.LateIndexSet(mBlocos, new object[3]
						{
							2,
							Information.UBound((Array)mBlocos, 2),
							sNomeCompleto
						}, null);
					}
				}
			}
		}
	}

	public static void ApagaDistribuicaoPotenciais(string sRevF, ref int iDwg, ref int iPot)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected Obj, but got Unknown
		StructureBloco Bloco = default;
		try
		{
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
							bool flag = false;
							if (XDataRelatorio.LerXDataDistPot(ref Ent, ref Bloco))
							{
								flag = true;
							}
							if (!flag && XDataRelatorio.LerXDataDistPotLinhas(ref Ent, ref Bloco))
							{
								flag = true;
							}
							if (flag && ((Bloco.iDwg == iDwg) & (Bloco.iPot == iPot)) && (Bloco.Eletron != 4 || Operators.CompareString(Bloco.sRevisao, sRevF, TextCompare: true) == 0))
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
		catch (Exception projectError2)
		{
			ProjectData.SetProjectError(projectError2);
			throw;
		}
		finally
		{
		}
	}

	public static void CarregaNomeDosBlocos(int i, ref string sTipo, ref string sCaminho, ref string sBloco)
	{
		try
		{
			if (i != 0)
			{
				if (Strings.Len(sTipo) != 1)
				{
					return;
				}
				string left = sTipo;
				if (Operators.CompareString(left, "B", TextCompare: true) != 0)
				{
					if (Operators.CompareString(left, "P", TextCompare: true) != 0)
					{
						if (Operators.CompareString(left, "E", TextCompare: true) != 0)
						{
							if (Operators.CompareString(left, "A", TextCompare: true) == 0)
							{
								sCaminho = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Potenciais\\Contato.dwg";
								sBloco = "Contato";
							}
						}
						else
						{
							sCaminho = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Potenciais\\Porta.dwg";
							sBloco = "Porta";
						}
					}
					else
					{
						sCaminho = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Potenciais\\Disp.dwg";
						sBloco = "Disp";
					}
				}
				else
				{
					sCaminho = DeclaracoesGeral.Conf.dirSimbologiaRelatorios + "Potenciais\\Borne.dwg";
					sBloco = "Borne";
				}
			}
			else
			{
				sBloco = "P_" + sBloco;
				sBloco = "P_Disj";
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	public static string insereUmBlocoDoRelatorioDePotenciais(string sCaminhoBloco, double lIncremento, string sNomeDoBloco, string sSentido, StructureBloco Bloco, ref Point3d Point, ref Point3d PointBloco, ref StructurePosicaoBlocos[] posBlocosADD)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Obj, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Obj, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Expected Obj, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Expected Obj, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected Obj, but got Unknown
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Expected Obj, but got Unknown
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		ObjectId val = ObjectId.Null;
		string result = "";
		DocumentLock val2 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val3 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				try
				{
					BlockTable val4 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val3.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Database val6 = new Database(false, true);
					val6.ReadDwgFile(sCaminhoBloco, FileShare.Read, true, "");
					DeclaracoesGeral.bAnularEventos = true;
					val = database.Insert(sNomeDoBloco, val6, false);
					((DisposableWrapper)val6).Dispose();
					BlockReference val7 = new BlockReference(Point, val);
					PointBloco = Point;
					adicionaPontoNaLista(ref posBlocosADD, Point, Bloco.sHandle, Bloco.sT1);
					((Entity)val7).Layer = DeclaracoesGeral.ativo.Pagina;
					val5.AppendEntity((Entity)(object)val7);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
					Entity Ent = (Entity)(object)val7;
					XDataRelatorio.gravaXDataDistPot(ref Ent, Bloco);
					val7 = (BlockReference)Ent;
					BlockTableRecord val8 = null;
					val8 = (BlockTableRecord)val3.GetObject(val, (OpenMode)0);
					if (((Operators.CompareString(Bloco.sTipo, "B", TextCompare: true) == 0) | (Operators.CompareString(Bloco.sTipo, "A", TextCompare: true) == 0) | !Bloco.bPrimeiro) && Operators.CompareString(Strings.Trim(Bloco.sT1), "", TextCompare: true) == 0)
					{
						Bloco.sT1 = Bloco.sT2;
						Bloco.sT2 = "?";
					}
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val8.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val9 = (Entity)val3.GetObject(current, (OpenMode)0);
							if (!(val9 is AttributeDefinition))
							{
								continue;
							}
							AttributeDefinition val10 = (AttributeDefinition)val9;
							AttributeReference val11 = new AttributeReference();
							val11.SetAttributeFromBlock(val10, val7.BlockTransform);
							string textString = "";
							string left = val11.Tag.ToUpper();
							if (Operators.CompareString(left, "NOME", TextCompare: true) != 0)
							{
								if (Operators.CompareString(left, "DISP", TextCompare: true) != 0)
								{
									if (Operators.CompareString(left, "CORR", TextCompare: true) != 0)
									{
										if (Operators.CompareString(left, "T1", TextCompare: true) != 0)
										{
											if (Operators.CompareString(left, "T2", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "R1", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "PAINEL", TextCompare: true) == 0 && Bloco.bMostraPainel)
													{
														textString = Bloco.sPn;
													}
												}
												else
												{
													textString = Bloco.sRegua;
												}
											}
											else
											{
												textString = Bloco.sT2;
											}
										}
										else
										{
											textString = Bloco.sT1;
										}
									}
									else
									{
										textString = Bloco.sCorrComp + Bloco.sCorr;
									}
								}
								else
								{
									textString = Bloco.sDispComp;
									if (Operators.CompareString(sNomeDoBloco, "P_Disj", TextCompare: true) == 0)
									{
										textString = "%%U" + Bloco.sRegua;
									}
								}
							}
							else
							{
								textString = Bloco.sNome;
							}
							((DBText)val11).TextString = textString;
							((DBText)val11).AdjustAlignment(database);
							val7.AttributeCollection.AppendAttribute(val11);
							DeclaracoesGeral.bAnularEventos = true;
							val3.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
							((Entity)val11).Draw();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					((Entity)val7).Draw();
					if (Operators.CompareString(sSentido, "D", TextCompare: true) != 0)
					{
						Point = new Point3d(Point.X, Point.Y + lIncremento, 0.0);
					}
					else
					{
						Point = new Point3d(Point.X, Point.Y - lIncremento, 0.0);
					}
					result = ((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString();
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					Application.UpdateScreen();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val3.Abort();
					ProjectData.ClearProjectError();
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
			((IDisposable)val2)?.Dispose();
		}
		return result;
	}

	public static string insereLinhadORelatorioDePotenciais(double dComprimentoDaLinha, double dAlturaDoBloco, ref string sSentido, StructureBloco Bloco, ref Point3d Point)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected Obj, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		_ = ObjectId.Null;
		string result = "";
		Point3d val = new Point3d(0.0, 0.0, 0.0);
		DocumentLock val2 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val3 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				try
				{
					BlockTable val4 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val3.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					val = new Point3d(Point.X, Point.Y - dComprimentoDaLinha, 0.0);
					Point2d val6 = new Point2d(Point.X, Point.Y);
					Point2d val7 = new Point2d(val.X, val.Y);
					Point2d val8 = new Point2d(Point.X, Point.Y - dAlturaDoBloco);
					Point2d val9 = new Point2d(val.X, val.Y - dAlturaDoBloco);
					Polyline val10 = new Polyline();
					((Entity)val10).SetDatabaseDefaults();
					((Entity)val10).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
					if (Operators.CompareString(sSentido, "U", TextCompare: true) != 0)
					{
						val10.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
						val10.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
						Point = val;
					}
					else
					{
						val10.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
						val10.AddVertexAt(1, val9, 0.0, 0.0, 0.0);
						Point = val;
					}
					((Entity)val10).ColorIndex = 7;
					((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
					val5.AppendEntity((Entity)(object)val10);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
					Entity Ent = (Entity)(object)val10;
					XDataRelatorio.gravaXDataDistPot(ref Ent, Bloco);
					val10 = (Polyline)Ent;
					((Entity)val10).Draw();
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					result = ((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val3.Abort();
					ProjectData.ClearProjectError();
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
			((IDisposable)val2)?.Dispose();
		}
		Application.UpdateScreen();
		return result;
	}

	public static string insereUmLinhaRelPot2(double dComprimentoDaLinha, double dAlturaDoBloco, ref string sSentido, StructureBloco Bloco, ref Point3d Point)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected Obj, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected Obj, but got Unknown
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Expected Obj, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		sSentido = "D";
		_ = ObjectId.Null;
		string result = "";
		Point3d val = new Point3d(0.0, 0.0, 0.0);
		DocumentLock val2 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val3 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				try
				{
					BlockTable val4 = (BlockTable)val3.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val3.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					val = new Point3d(Point.X, Point.Y - dComprimentoDaLinha, 0.0);
					Point2d val6 = new Point2d(Point.X, Point.Y);
					Point2d val7 = new Point2d(val.X, val.Y);
					Point2d val8 = new Point2d(Point.X, Point.Y - dAlturaDoBloco);
					Point2d val9 = new Point2d(val.X, val.Y - dAlturaDoBloco);
					Polyline val10 = new Polyline();
					((Entity)val10).SetDatabaseDefaults();
					((Entity)val10).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
					if (Operators.CompareString(sSentido, "D", TextCompare: true) != 0)
					{
						val10.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
						val10.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
						Point = val;
					}
					else
					{
						val10.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
						val10.AddVertexAt(1, val9, 0.0, 0.0, 0.0);
						Point = val;
					}
					((Entity)val10).ColorIndex = 7;
					((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
					val5.AppendEntity((Entity)(object)val10);
					DeclaracoesGeral.bAnularEventos = true;
					val3.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
					Entity Ent = (Entity)(object)val10;
					XDataRelatorio.gravaXDataDistPot(ref Ent, Bloco);
					val10 = (Polyline)Ent;
					((Entity)val10).Draw();
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					result = ((object)((DBObject)val10).Handle/*cast due to constrained. prefix*/).ToString();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val3.Abort();
					ProjectData.ClearProjectError();
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
			((IDisposable)val2)?.Dispose();
		}
		Application.UpdateScreen();
		return result;
	}

	public static void insereUmLinhaRelPotDeslocamento(double dAlturaDaLinha, double dAlturaDoBloco, string sU_D, string sD_E, double dDeslocamento, StructureBloco Bloco, ref Point3d Point)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected Obj, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		_ = ObjectId.Null;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				double num = 2.5;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Polyline val5 = new Polyline();
					Point2d val6 = new Point2d(Point.X, Point.Y);
					Point2d val7 = new Point2d(Point.X + 2.0, Point.Y - num);
					Point2d val8 = new Point2d(Point.X + dDeslocamento, Point.Y - num);
					Point2d val9 = new Point2d(Point.X + dDeslocamento, Point.Y - 7.0);
					sD_E = "D";
					if (dDeslocamento < 0.0)
					{
						val6 = new Point2d(Point.X, Point.Y);
						val7 = new Point2d(Point.X - 2.0, Point.Y - num);
						val8 = new Point2d(Point.X + dDeslocamento, Point.Y - num);
						val9 = new Point2d(Point.X + dDeslocamento, Point.Y - 7.0);
						sD_E = "E";
					}
					((Entity)val5).SetDatabaseDefaults();
					val5.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
					val5.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
					val5.AddVertexAt(2, val8, 0.0, 0.0, 0.0);
					val5.AddVertexAt(3, val9, 0.0, 0.0, 0.0);
					((Entity)val5).ColorIndex = 7;
					((Entity)val5).Linetype = "DASHDOT";
					((Entity)val5).Layer = DeclaracoesGeral.ativo.Pagina;
					val4.AppendEntity((Entity)(object)val5);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
					Entity Ent = (Entity)(object)val5;
					XDataRelatorio.gravaXDataDistPot(ref Ent, Bloco);
					val5 = (Polyline)Ent;
					((Entity)val5).Draw();
					Application.UpdateScreen();
					Point3d pt = new Point3d(val7.X + dDeslocamento / 2.3, val7.Y, 0.0);
					criarHatchTriangulo(pt, DeclaracoesGeral.ativo.Pagina, sD_E, Bloco);
					Point = new Point3d(val9.X, val9.Y, 0.0);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
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
	}

	public static void criarHatchTriangulo(Point3d pt, string layer, string sSentido, StructureBloco Bloco)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected Obj, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected Obj, but got Unknown
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected Obj, but got Unknown
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			BlockTable val = (BlockTable)topTransaction.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val2 = (BlockTableRecord)topTransaction.GetObject(((SymbolTable)val)[BlockTableRecord.ModelSpace], (OpenMode)1);
			Point2d val3 = new Point2d(pt.X, pt.Y);
			Point2d val4 = new Point2d(pt.X, pt.Y);
			Point2d val5 = new Point2d(pt.X, pt.Y);
			Point2d val6 = new Point2d(pt.X, pt.Y);
			if (Operators.CompareString(sSentido, "D", TextCompare: true) != 0)
			{
				val4 = new Point2d(pt.X + 2.5, pt.Y + 0.75);
				val5 = new Point2d(pt.X + 2.5, pt.Y - 0.75);
			}
			else
			{
				val4 = new Point2d(pt.X - 2.5, pt.Y + 0.75);
				val5 = new Point2d(pt.X - 2.5, pt.Y - 0.75);
			}
			Polyline val7 = new Polyline();
			((Entity)val7).SetDatabaseDefaults();
			val7.AddVertexAt(0, val3, 0.0, 0.0, 0.0);
			val7.AddVertexAt(1, val4, 0.0, 0.0, 0.0);
			val7.AddVertexAt(2, val5, 0.0, 0.0, 0.0);
			val7.AddVertexAt(3, val6, 0.0, 0.0, 0.0);
			((Entity)val7).ColorIndex = 7;
			((Entity)val7).Layer = DeclaracoesGeral.ativo.Pagina;
			val2.AppendEntity((Entity)(object)val7);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val7, true);
			((Entity)val7).Draw();
			Application.UpdateScreen();
			ObjectIdCollection val8 = new ObjectIdCollection();
			val8.Add(((DBObject)val7).ObjectId);
			Hatch val9 = new Hatch();
			val2.AppendEntity((Entity)(object)val9);
			DeclaracoesGeral.bAnularEventos = true;
			topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
			((Entity)val9).SetDatabaseDefaults();
			((Entity)val9).ColorIndex = DeclaracoesGeral.Conf.CorConexao;
			((Entity)val9).LineWeight = (LineWeight)9;
			((Entity)val9).Layer = layer;
			val9.SetHatchPattern((HatchPatternType)1, "SOLID");
			val9.Associative = true;
			val9.AppendLoop((HatchLoopTypes)16, val8);
			val9.EvaluateHatch(true);
			Application.UpdateScreen();
			((DBObject)val7).Erase();
			Entity Ent = (Entity)(object)val9;
			XDataRelatorio.gravaXDataDistPot(ref Ent, Bloco);
			val9 = (Hatch)Ent;
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			throw;
		}
		finally
		{
			((IDisposable)topTransaction)?.Dispose();
		}
	}

	public static string insereUmLinhaRelPotRetorno(double dAlturaDaLinha, double dAlturaDoBloco, ref string sU_D, ref string sD_E, double dDeslocamento, StructureBloco Bloco, ref Point3d Point)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Obj, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ec: Expected Obj, but got Unknown
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Unknown result type (might be due to invalid IL or missing references)
		_ = ObjectId.Null;
		string result = "";
		double num = 1.0;
		if (Operators.CompareString(sU_D, "U", TextCompare: true) == 0)
		{
			num = 2.0;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					Polyline val5 = new Polyline();
					Point2d val6 = default;
					Point2d val7 = default;
					Point2d val8 = default;
					Point2d val9 = default;
					((Entity)val5).SetDatabaseDefaults();
					if (Operators.CompareString(sU_D, "D", TextCompare: true) != 0)
					{
						if (Operators.CompareString(sU_D, "U", TextCompare: true) == 0)
						{
							Point = new Point3d(Point.X, Point.Y - 2.0, 0.0);
							val6 = new Point2d(Point.X, Point.Y);
							val7 = new Point2d(Point.X, Point.Y + num);
							val8 = new Point2d(Point.X + dDeslocamento, Point.Y + num);
							val9 = new Point2d(Point.X + dDeslocamento, Point.Y);
							val5.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
							val5.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
							val5.AddVertexAt(2, val8, 0.0, 0.0, 0.0);
							val5.AddVertexAt(3, val9, 0.0, 0.0, 0.0);
							Point = new Point3d(val9.X, val9.Y, 0.0);
							sU_D = "D";
						}
					}
					else
					{
						Point = new Point3d(Point.X, Point.Y, 0.0);
						val6 = new Point2d(Point.X, Point.Y);
						val7 = new Point2d(Point.X, Point.Y - num);
						val8 = new Point2d(Point.X + dDeslocamento, Point.Y - num);
						val9 = new Point2d(Point.X + dDeslocamento, Point.Y);
						val5.AddVertexAt(0, val6, 0.0, 0.0, 0.0);
						val5.AddVertexAt(1, val7, 0.0, 0.0, 0.0);
						val5.AddVertexAt(2, val8, 0.0, 0.0, 0.0);
						val5.AddVertexAt(3, val9, 0.0, 0.0, 0.0);
						Point = new Point3d(val9.X, val9.Y + 2.0, 0.0);
						sU_D = "U";
					}
					((Entity)val5).ColorIndex = 7;
					((Entity)val5).Layer = DeclaracoesGeral.ativo.Pagina;
					val4.AppendEntity((Entity)(object)val5);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
					Entity Ent = (Entity)(object)val5;
					XDataRelatorio.gravaXDataDistPot(ref Ent, Bloco);
					val5 = (Polyline)Ent;
					((Entity)val5).Draw();
					Application.UpdateScreen();
					result = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					val2.Abort();
					ProjectData.ClearProjectError();
				}
				finally
				{
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
		return result;
	}

	public static bool ExistePontoNaLista(ref StructurePosicaoBlocos[] posBlocosADD, Point3d pt)
	{
		bool result = false;
		double num = Math.Round(pt.X, 1);
		double num2 = Math.Round(pt.Y, 1);
		List<string> list = new List<string>();
		int num3 = Information.UBound(posBlocosADD);
		checked
		{
			for (int i = 1; i <= num3; i++)
			{
				if (posBlocosADD[i].sX == num)
				{
					list.Add(Conversions.ToString(posBlocosADD[i].sY));
				}
			}
			int num4 = Information.UBound(posBlocosADD);
			for (int j = 1; j <= num4; j++)
			{
				if (posBlocosADD[j].sX == num && posBlocosADD[j].sY == num2)
				{
					result = true;
					break;
				}
			}
			return result;
		}
	}

	public static bool adicionaPontoNaLista(ref StructurePosicaoBlocos[] posBlocosADD, Point3d pt, string sNome, string sT)
	{
		double sX = Math.Round(pt.X, 1);
		double sY = Math.Round(pt.Y, 1);
		checked
		{
			int num = Information.UBound(posBlocosADD) + 1;
			posBlocosADD = (StructurePosicaoBlocos[])Utils.CopyArray(posBlocosADD, new StructurePosicaoBlocos[num + 1]);
			posBlocosADD[num].sNome = sNome;
			posBlocosADD[num].sT1 = sT;
			posBlocosADD[num].sX = sX;
			posBlocosADD[num].sY = sY;
			return true;
		}
	}
}

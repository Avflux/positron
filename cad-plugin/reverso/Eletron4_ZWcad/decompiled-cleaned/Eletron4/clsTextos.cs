using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.EditorInput;
using ZwSoft.ZwCAD.Geometry;
using ZwSoft.ZwCAD.GraphicsInterface;
using ZwSoft.ZwCAD.Runtime;
using oADsu33FpCEasW73ADP;

namespace Eletron4;

public class clsTextos
{
	public struct mTitulos
	{
		public string shandle;

		public int indice;

		public string sTitulo;

		public string sPagina;
	}

	public struct mTextos
	{
		public string sIndice;

		public string shandle;

		public string sTipo;

		public string sTexto;

		public string sPagina;
	}

	public struct structureTextoCaderno
	{
		public string sHandleTexto;

		public string sHandleVeia;
	}

	public static string TiraNothing(string Value)
	{
		string result = "";
		if (!Information.IsNothing(Value))
		{
			result = Value;
		}
		return result;
	}

	public static string TiraDBNull(object Value)
	{
		string result = "";
		if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(Value)))
		{
			result = Conversions.ToString(Value);
		}
		return result;
	}

	public static object TiraDBNullNumero(object Value)
	{
		int num = 0;
		if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(Value)))
		{
			num = Conversions.ToInteger(Value);
		}
		return num;
	}

	public static bool criaMTextoLP(ref Declaracoes2.StructureDescricaoLP[] PortasSelecionadas, int iIndex, double DistLinha, double Fonte, double Largura, double OrdenadaY, double OrdenadaX, bool bAdicionaLinha, string sTipo, bool bMline2, bool bMline3, bool bPorta, ref string sHandleultimaline, int linhas = 2)
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_0722: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_075e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		//IL_0793: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Obj, but got Unknown
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected Obj, but got Unknown
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected Obj, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected Obj, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a5: Expected Obj, but got Unknown
		//IL_04e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Expected Obj, but got Unknown
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_040a: Expected Obj, but got Unknown
		//IL_0445: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected Obj, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Expected Obj, but got Unknown
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected Obj, but got Unknown
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0552: Expected Obj, but got Unknown
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05da: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e1: Expected Obj, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected Obj, but got Unknown
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		double x = PortasSelecionadas[iIndex].X;
		string sDesc = PortasSelecionadas[iIndex].sDesc;
		double num = 5.0;
		double width = Largura - 2.0;
		double num2 = DistLinha / 2.0 - Fonte / 2.0;
		Point3d val = new Point3d(x - Largura / 2.0 + 1.0, OrdenadaY - num2, 0.0);
		num = Largura / 4.0;
		Point3d val2 = default;
		if (Operators.CompareString(sTipo, "V", TextCompare: true) == 0)
		{
			if (bPorta)
			{
				val2 = new Point3d(x, OrdenadaY + num2, 0.0);
			}
			else
			{
				val2 = ((Largura == 0.0) ? new Point3d(x, OrdenadaY + num2, 0.0) : new Point3d(x + num, OrdenadaY + num2, 0.0));
			}
		}
		else if (Operators.CompareString(sTipo, "H", TextCompare: true) == 0)
		{
			val2 = (bPorta ? new Point3d(x, OrdenadaY - num2, 0.0) : new Point3d(x + num, OrdenadaY - num2, 0.0));
		}
		else if (Operators.CompareString(sTipo, "L", TextCompare: true) == 0)
		{
			val2 = new Point3d(OrdenadaX, PortasSelecionadas[iIndex].point.Y + Fonte / 2.0, 0.0);
		}
		DocumentLock val3 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val4 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val5 = (BlockTable)val4.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val6 = (BlockTableRecord)val4.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
				TextStyleTable val7 = (TextStyleTable)val4.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId val8 = (((SymbolTable)val7).Has("Romans") ? ((SymbolTable)val7)["Romans"] : ((SymbolTable)val7)["Standard"]);
				_ = (TextStyleTableRecord)val4.GetObject(val8, (OpenMode)0);
				if (Operators.CompareString(sTipo, "H", TextCompare: true) != 0)
				{
					if (Operators.CompareString(sTipo, "V", TextCompare: true) != 0)
					{
						if (Operators.CompareString(sTipo, "L", TextCompare: true) == 0)
						{
							if (bMline3)
							{
								MText val9 = new MText();
								((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
								val9.Contents = sDesc;
								val9.TextHeight = Fonte;
								val9.Attachment = (AttachmentPoint)4;
								val9.Rotation = 0.0;
								val9.TextStyleId = val8;
								val9.Location = val2;
								val9.Width = width;
								val6.AppendEntity((Entity)(object)val9);
								DeclaracoesGeral.bAnularEventos = true;
								val4.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
								Entity Ent = (Entity)(object)val9;
								XDataDispositivosMaster.GravarXDataTextoLP(ref Ent, PortasSelecionadas[iIndex].chavePri);
								val9 = (MText)Ent;
							}
							else
							{
								DBText val10 = new DBText();
								((Entity)val10).Layer = DeclaracoesGeral.ativo.Pagina;
								val10.TextString = sDesc;
								val10.Height = Fonte;
								val10.HorizontalMode = (TextHorizontalMode)0;
								val10.VerticalMode = (TextVerticalMode)2;
								val10.Rotation = 0.0;
								val10.TextStyleId = val8;
								val10.AlignmentPoint = val2;
								val6.AppendEntity((Entity)(object)val10);
								DeclaracoesGeral.bAnularEventos = true;
								val4.AddNewlyCreatedDBObject((DBObject)(object)val10, true);
								Entity Ent = (Entity)(object)val10;
								XDataDispositivosMaster.GravarXDataTextoLP(ref Ent, PortasSelecionadas[iIndex].chavePri);
								val10 = (DBText)Ent;
							}
						}
					}
					else if (bMline2)
					{
						MText val11 = new MText();
						((Entity)val11).Layer = DeclaracoesGeral.ativo.Pagina;
						val11.Contents = sDesc;
						val11.TextHeight = Fonte;
						val11.Attachment = (AttachmentPoint)4;
						val11.Rotation = Math.PI / 2.0;
						val11.TextStyleId = val8;
						val11.Location = val2;
						val11.Width = width;
						val6.AppendEntity((Entity)(object)val11);
						DeclaracoesGeral.bAnularEventos = true;
						val4.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
						Entity Ent = (Entity)(object)val11;
						XDataDispositivosMaster.GravarXDataTextoLP(ref Ent, PortasSelecionadas[iIndex].chavePri);
						val11 = (MText)Ent;
					}
					else
					{
						DBText val12 = new DBText();
						((Entity)val12).Layer = DeclaracoesGeral.ativo.Pagina;
						val12.TextString = sDesc;
						val12.Height = Fonte;
						val12.HorizontalMode = (TextHorizontalMode)0;
						val12.VerticalMode = (TextVerticalMode)2;
						val12.Rotation = Math.PI / 2.0;
						val12.TextStyleId = val8;
						val12.AlignmentPoint = val2;
						((Entity)val12).LineWeight = (LineWeight)20;
						val6.AppendEntity((Entity)(object)val12);
						DeclaracoesGeral.bAnularEventos = true;
						val4.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
						Entity Ent = (Entity)(object)val12;
						XDataDispositivosMaster.GravarXDataTextoLP(ref Ent, PortasSelecionadas[iIndex].chavePri);
						val12 = (DBText)Ent;
					}
				}
				else
				{
					MText val13 = new MText();
					((Entity)val13).SetDatabaseDefaults();
					val13.Location = val2;
					val13.Attachment = (AttachmentPoint)2;
					val13.Width = width;
					val13.Contents = sDesc;
					((Entity)val13).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
					val13.TextHeight = Fonte;
					val13.TextStyleId = val8;
					val13.LineSpaceDistance = DistLinha;
					val13.LineSpacingStyle = (LineSpacingStyle)2;
					((Entity)val13).LineWeight = (LineWeight)9;
					((Entity)val13).Layer = DeclaracoesGeral.ativo.Pagina;
					val6.AppendEntity((Entity)(object)val13);
					DeclaracoesGeral.bAnularEventos = true;
					val4.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
					Entity Ent = (Entity)(object)val13;
					XDataDispositivosMaster.GravarXDataTextoLP(ref Ent, PortasSelecionadas[iIndex].chavePri);
					val13 = (MText)Ent;
					if (bAdicionaLinha)
					{
						Line val14 = new Line();
						switch (linhas)
						{
						case 3:
							DistLinha *= 1.5;
							break;
						case 1:
							DistLinha *= 0.5;
							break;
						case 2:
							DistLinha = DistLinha;
							break;
						}
						((Entity)val14).Layer = DeclaracoesGeral.ativo.Pagina;
						if (!bPorta)
						{
							val14.StartPoint = new Point3d(val[0] + num - 1.0, OrdenadaY, 0.0);
							val14.EndPoint = new Point3d(val[0] + num - 1.0, OrdenadaY - 2.0 * DistLinha, 0.0);
						}
						else
						{
							val14.StartPoint = new Point3d(val[0] - 1.0, OrdenadaY, 0.0);
							val14.EndPoint = new Point3d(val[0] - 1.0, OrdenadaY - 2.0 * DistLinha, 0.0);
						}
						val6.AppendEntity((Entity)(object)val14);
						DeclaracoesGeral.bAnularEventos = true;
						val4.AddNewlyCreatedDBObject((DBObject)(object)val14, true);
						Ent = (Entity)(object)val14;
						XDataDispositivosMaster.GravarXDataLinhaTextoLP(ref Ent, PortasSelecionadas[iIndex].chavePri);
						val14 = (Line)Ent;
						sHandleultimaline = ((object)((DBObject)val14).Handle/*cast due to constrained. prefix*/).ToString();
					}
				}
				result = true;
				DeclaracoesGeral.bAnularEventos = true;
				val4.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				val4.Abort();
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val4)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val3)?.Dispose();
		}
		return result;
	}

	public static void criaLinhaFinalDoTextoLP(ref string sUltimaline, string chavePri, double Largura)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected Obj, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				Line val5 = (Line)Geral.HandleToObject(sUltimaline);
				Line val6 = new Line();
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				Line val7 = val6;
				Point3d val8 = val5.StartPoint;
				double num = val8.X + Largura;
				val8 = val5.StartPoint;
				val7.StartPoint = new Point3d(num, val8.Y, 0.0);
				Line val9 = val6;
				val8 = val5.EndPoint;
				double num2 = val8.X + Largura;
				val8 = val5.EndPoint;
				val9.EndPoint = new Point3d(num2, val8.Y, 0.0);
				val4.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				Entity Ent = (Entity)(object)val6;
				XDataDispositivosMaster.GravarXDataLinhaTextoLP(ref Ent, chavePri);
				val6 = (Line)Ent;
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

	public static void ApagaTextoDasPortas(ref Declaracoes2.StructureDescricaoLP[] PortasSelecionadas)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		if (Information.UBound(PortasSelecionadas) <= 0)
		{
			return;
		}
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string text = "";
							if (Ent == null)
							{
								continue;
							}
							text = XDataDispositivosMaster.LerXDataTextoLP(ref Ent);
							if (Operators.CompareString(text, "", TextCompare: true) == 0)
							{
								text = XDataDispositivosMaster.LerXDataLinhaTextoLP(ref Ent);
								if (Operators.CompareString(text, "", TextCompare: true) == 0)
								{
									continue;
								}
								int num = Information.UBound(PortasSelecionadas);
								for (int i = 1; i <= num; i++)
								{
									if (Operators.CompareString(PortasSelecionadas[i].chavePri, text, TextCompare: true) == 0)
									{
										((DBObject)Ent).UpgradeOpen();
										((DBObject)Ent).Erase();
										break;
									}
								}
								continue;
							}
							int num2 = Information.UBound(PortasSelecionadas);
							for (int j = 1; j <= num2; j++)
							{
								if (Operators.CompareString(PortasSelecionadas[j].chavePri, text, TextCompare: true) == 0)
								{
									((DBObject)Ent).UpgradeOpen();
									((DBObject)Ent).Erase();
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

	public static void AtualizarTexto(DBText Texto, string NovoValor)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				_ = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				((DBObject)Texto).UpgradeOpen();
				Texto.TextString = NovoValor;
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	public static void AtualizaUmTexto(string sHandle, string NovoValor)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)Geral.HandleToObject(sHandle);
				if (val3 != null)
				{
					DBText val4 = (DBText)(object)((val3 is DBText) ? val3 : null);
					if (val4 != null)
					{
						((DBObject)val4).UpgradeOpen();
						val4.TextString = NovoValor;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	public static string LeUmTexto(string sHandle)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)Geral.HandleToObject(sHandle);
				if (val3 != null)
				{
					DBText val4 = (DBText)(object)((val3 is DBText) ? val3 : null);
					if (val4 != null)
					{
						result = val4.TextString;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	public static string EncontraPaginaDoTexto(string sHandle)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)Geral.HandleToObject(sHandle);
				if (val3 != null)
				{
					DBText val4 = (DBText)(object)((val3 is DBText) ? val3 : null);
					if (val4 != null)
					{
						result = DeclaracoesGeral.Conf.PrefixoCruzInterno + ((Entity)val4).Layer.ToString() + DeclaracoesGeral.Conf.SufixoCruzInterno;
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	public static void AtualizarMTexto(MText Texto, string NovoValor)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				_ = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				((DBObject)Texto).UpgradeOpen();
				Texto.Contents = NovoValor;
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	public static void capturaTodosTextosETitulos(ref mTextos[] mTextos, bool bIncluirNumero, string tbQuant)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected Obj, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		mTextos = new mTextos[1];
		int num2 = Conversions.ToInteger(tbQuant);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		checked
		{
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
						DBText text = (DBText)(object)((val4 is DBText) ? val4 : null);
						if (!((DisposableWrapper)(object)text != (DisposableWrapper)null))
						{
							MText val5 = (MText)(object)((val4 is MText) ? val4 : null);
							if (!((DisposableWrapper)(object)val5 != (DisposableWrapper)null) || !(((DBObject)val5).XData == (ResultBuffer)null))
							{
								continue;
							}
							string contents = val5.Contents;
							bool flag = true;
							if (Versioned.IsNumeric(contents))
							{
								flag = true;
								if (!bIncluirNumero)
								{
									flag = bIncluirNumero;
								}
							}
							int num3 = Strings.Len(contents);
							if (num3 <= num2)
							{
								flag = false;
							}
							if (Operators.CompareString(contents, "", TextCompare: true) == 0)
							{
								flag = false;
							}
							if (flag)
							{
								num++;
								mTextos = (mTextos[])Utils.CopyArray(mTextos, new mTextos[num + 1]);
								mTextos[num].shandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
								mTextos[num].sPagina = ((Entity)val5).Layer;
								mTextos[num].sTexto = val5.Contents;
								mTextos[num].sTipo = "MTXT";
							}
							continue;
						}
						XDataGeral.LeXDataTitulo(ref text);
						if (((DBObject)text).XData != null)
						{
							continue;
						}
						string textString = text.TextString;
						bool flag2 = true;
						if (Versioned.IsNumeric(textString))
						{
							flag2 = true;
							if (!bIncluirNumero)
							{
								flag2 = bIncluirNumero;
							}
						}
						int num4 = Strings.Len(textString);
						if (num4 <= num2)
						{
							flag2 = false;
						}
						if (Operators.CompareString(textString, "", TextCompare: true) == 0)
						{
							flag2 = false;
						}
						if (flag2)
						{
							num++;
							mTextos = (mTextos[])Utils.CopyArray(mTextos, new mTextos[num + 1]);
							mTextos[num].shandle = ((object)((DBObject)text).Handle/*cast due to constrained. prefix*/).ToString();
							mTextos[num].sPagina = ((Entity)text).Layer;
							mTextos[num].sTexto = text.TextString;
							mTextos[num].sTipo = "TXT";
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
				throw;
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void capturaTodosTextosDeCabos(ref List<string> lHandleCabos)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected Obj, but got Unknown
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
				short tipo = default;
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val4 = (Entity)val.GetObject(current, (OpenMode)0);
					DBText val5 = (DBText)(object)((val4 is DBText) ? val4 : null);
					if (!((DisposableWrapper)(object)val5 != (DisposableWrapper)null))
					{
						continue;
					}
					string handle = "";
					Entity ent = (Entity)(object)val5;
					string THandle = "";
					string sOpcionais = "";
					bool flag = XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sOpcionais);
					val5 = (DBText)ent;
					if (flag)
					{
						string item = handle + "|" + tipo;
						if (!lHandleCabos.Contains(item))
						{
							lHandleCabos.Add(item);
						}
						item = handle;
						if (!lHandleCabos.Contains(item))
						{
							lHandleCabos.Add(item);
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
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void EditaTodosTextosETitulos(ref DataGridView dg, ref mTextos[] mTextos)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Expected Obj, but got Unknown
		List<string> list = new List<string>();
		int num = Information.UBound(mTextos);
		checked
		{
			for (int i = 0; i <= num; i++)
			{
				list.Add(mTextos[i].shandle);
			}
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					int num2 = 0;
					DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mTextos);
					DeclaracoesGeral._uscPagina.pbIniciar();
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							if (!list.Contains(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								continue;
							}
							int num3 = Information.UBound(mTextos);
							for (int j = 1; j <= num3; j++)
							{
								if (Operators.CompareString(mTextos[j].shandle, ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)
								{
									continue;
								}
								string sTipo = mTextos[j].sTipo;
								if (Operators.CompareString(sTipo, "TXT", TextCompare: true) != 0)
								{
									if (Operators.CompareString(sTipo, "TIT", TextCompare: true) != 0)
									{
										if (Operators.CompareString(sTipo, "MTXT", TextCompare: true) == 0)
										{
											MText val6 = (MText)(object)((val5 is MText) ? val5 : null);
											if (val6 != null && Operators.CompareString(val6.Contents, mTextos[j].sTexto, TextCompare: true) != 0)
											{
												((DBObject)val6).UpgradeOpen();
												val6.Contents = mTextos[j].sTexto;
												num2++;
											}
										}
										continue;
									}
									DBText val7 = (DBText)(object)((val5 is DBText) ? val5 : null);
									if (Operators.CompareString(val7.TextString, mTextos[j].sTexto, TextCompare: true) != 0)
									{
										int Tipo = 0;
										Entity Ent = (Entity)(object)val7;
										clsEditaTitulosTextos.LeXDataTitulo(ref Ent, ref Tipo);
										val7 = (DBText)Ent;
										((DBObject)val7).UpgradeOpen();
										XDataGeral.gravarXDataTitulo(ref val7, Tipo, val7.TextString);
										val7.TextString = mTextos[j].sTexto;
										num2++;
									}
								}
								else
								{
									DBText val8 = (DBText)(object)((val5 is DBText) ? val5 : null);
									if (Operators.CompareString(val8.TextString, mTextos[j].sTexto, TextCompare: true) != 0)
									{
										((DBObject)val8).UpgradeOpen();
										val8.TextString = mTextos[j].sTexto;
										num2++;
									}
								}
							}
							DeclaracoesGeral._uscPagina.pbPasso();
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					Interaction.MsgBox(Operators.ConcatenateObject(Conversions.ToString(num2) + " ", DeclaracoesGeral.mMensagem[1, 1221]), MsgBoxStyle.Information, "Elétron");
					DeclaracoesGeral._uscPagina.pbFim();
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
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

	public static void ExportaPaginas(ref Worksheet oSheet, ref DataGridView dg, DeclaracoesGeral.Titulos tit, bool bAlternativo)
	{
		string text = "";
		string text2 = "";
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		DeclaracoesGeral._uscPagina.pbPasso();
		checked
		{
			text = "A1:G" + Conversions.ToString(dg.RowCount + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
			text = "E2:G" + Conversions.ToString(dg.RowCount + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
			int num = 1;
			text = "A" + Conversions.ToString(1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 9]));
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			if (!tit.bTitulo1)
			{
				text = "B" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":B" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 50;
			}
			else
			{
				text = "B" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":B" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 50;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 40]));
			}
			if (!tit.bTitulo2)
			{
				text = "C" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":C" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
			}
			else
			{
				text = "C" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":C" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 50;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 41]));
			}
			if (!tit.bTitulo3)
			{
				text = "D" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
			}
			else
			{
				text = "D" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 50;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 42]));
			}
			if (!tit.bTitulo4)
			{
				text = "E" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
			}
			else
			{
				text = "E" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 50;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 43]));
			}
			text = "F" + Conversions.ToString(num);
			text2 = "A" + Conversions.ToString(num) + ":F" + Conversions.ToString(num);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 15;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 11]));
			if (!bAlternativo)
			{
				text = "G" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":G" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 0;
			}
			else
			{
				text = "G" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":G" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 20;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 10]));
			}
			ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
			num++;
			bool flag = false;
			DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount - 1;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num2 = dg.RowCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				text = "A" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[0].Value.ToString()));
				if (tit.bTitulo1)
				{
					text = "B" + Conversions.ToString(num);
					text2 = "A" + Conversions.ToString(num) + ":B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[1].Value.ToString()));
				}
				if (tit.bTitulo2)
				{
					text = "C" + Conversions.ToString(num);
					text2 = "A" + Conversions.ToString(num) + ":C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[2].Value.ToString()));
				}
				if (tit.bTitulo3)
				{
					text = "D" + Conversions.ToString(num);
					text2 = "A" + Conversions.ToString(num) + ":D" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[3].Value.ToString()));
				}
				if (tit.bTitulo4)
				{
					text = "E" + Conversions.ToString(num);
					text2 = "A" + Conversions.ToString(num) + ":E" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[4].Value.ToString()));
				}
				text = "F" + Conversions.ToString(num);
				text2 = "A" + Conversions.ToString(num) + ":F" + Conversions.ToString(num);
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
				((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[5].Value.ToString()));
				if (bAlternativo)
				{
					text = "G" + Conversions.ToString(num);
					text2 = "A" + Conversions.ToString(num) + ":G" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[6].Value.ToString()));
				}
				if (!flag)
				{
					((_Worksheet)oSheet).get_Range((object)text2, RuntimeHelpers.GetObjectValue(Missing.Value)).Interior.ColorIndex = 36;
				}
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text2);
				flag = !flag;
				num++;
				DeclaracoesGeral._uscPagina.pbPasso();
			}
			text = "F";
			if (bAlternativo)
			{
				text = "G";
			}
			text = "B2:" + text + Conversions.ToString(ExcFuncoesExcel.BuscaIndiceMaximoUsado(ref oSheet, "A"));
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void ImportaTitulos(ref Worksheet oSheet, ref mTitulos[] mTitulos, DeclaracoesGeral.Titulos tit, bool balternativo)
	{
		mTitulos = new mTitulos[1];
		int num = ExcFuncoesExcel.BuscaIndiceMaximoUsado(ref oSheet, "A");
		int num2 = num;
		checked
		{
			for (int i = 2; i <= num2; i++)
			{
				string sPagina = "";
				string sTitulo = "";
				string sTitulo2 = "";
				string sTitulo3 = "";
				string sTitulo4 = "";
				string sTitulo5 = "";
				string text = "";
				string cell = "A" + i;
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					sPagina = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
					cell = "B" + i;
					sTitulo = TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "C" + i;
					sTitulo2 = TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "D" + i;
					sTitulo3 = TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "E" + i;
					sTitulo4 = TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "F" + i;
					sTitulo5 = TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					cell = "G" + i;
					text = TiraNothing(Conversions.ToString(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value))));
					if (Strings.Len(text) > 20)
					{
						text = Strings.Mid(text, 1, 20);
						ExcFuncoesExcel.PintaCelula(ref oSheet, ExcFuncoesExcel.mudaNumeroAsc(7L), Conversions.ToString(i), Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1927]), 3);
					}
				}
				int num3 = 0;
				if (tit.bTitulo1)
				{
					num3 = Information.UBound(mTitulos) + 1;
					mTitulos = (mTitulos[])Utils.CopyArray(mTitulos, new mTitulos[num3 + 1]);
					mTitulos[num3].sPagina = sPagina;
					mTitulos[num3].indice = 1;
					mTitulos[num3].shandle = "";
					mTitulos[num3].sTitulo = sTitulo;
				}
				if (tit.bTitulo2)
				{
					num3 = Information.UBound(mTitulos) + 1;
					mTitulos = (mTitulos[])Utils.CopyArray(mTitulos, new mTitulos[num3 + 1]);
					mTitulos[num3].sPagina = sPagina;
					mTitulos[num3].indice = 2;
					mTitulos[num3].shandle = "";
					mTitulos[num3].sTitulo = sTitulo2;
				}
				if (tit.bTitulo3)
				{
					num3 = Information.UBound(mTitulos) + 1;
					mTitulos = (mTitulos[])Utils.CopyArray(mTitulos, new mTitulos[num3 + 1]);
					mTitulos[num3].sPagina = sPagina;
					mTitulos[num3].indice = 3;
					mTitulos[num3].shandle = "";
					mTitulos[num3].sTitulo = sTitulo3;
				}
				if (tit.bTitulo4)
				{
					num3 = Information.UBound(mTitulos) + 1;
					mTitulos = (mTitulos[])Utils.CopyArray(mTitulos, new mTitulos[num3 + 1]);
					mTitulos[num3].sPagina = sPagina;
					mTitulos[num3].indice = 4;
					mTitulos[num3].shandle = "";
					mTitulos[num3].sTitulo = sTitulo4;
				}
				num3 = Information.UBound(mTitulos) + 1;
				mTitulos = (mTitulos[])Utils.CopyArray(mTitulos, new mTitulos[num3 + 1]);
				mTitulos[num3].sPagina = sPagina;
				mTitulos[num3].indice = 5;
				mTitulos[num3].shandle = "";
				mTitulos[num3].sTitulo = sTitulo5;
				if (balternativo)
				{
					num3 = Information.UBound(mTitulos) + 1;
					mTitulos = (mTitulos[])Utils.CopyArray(mTitulos, new mTitulos[num3 + 1]);
					mTitulos[num3].sPagina = sPagina;
					mTitulos[num3].indice = 6;
					mTitulos[num3].shandle = "";
					mTitulos[num3].sTitulo = text;
				}
			}
		}
	}

	public static void ExportaTextos(ref Worksheet oSheet, ref DataGridView dg)
	{
		string text = "";
		ExcFuncoesExcel.LimpaSheet(ref oSheet);
		DeclaracoesGeral._uscPagina.pbPasso();
		checked
		{
			text = "A1:C" + Conversions.ToString(dg.RowCount + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 10;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 2;
			text = "C2:C" + Conversions.ToString(dg.RowCount + 1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).WrapText = true;
			int num = 1;
			text = "A" + Conversions.ToString(1);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 915]));
			ExcFuncoesExcel.PintaCelula(ref oSheet, "A", num.ToString(), "", 15);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			text = "B" + Conversions.ToString(num);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 9]));
			ExcFuncoesExcel.PintaCelula(ref oSheet, "B", num.ToString(), "", 15);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 10;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			text = "C" + Conversions.ToString(num);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mMensagem[1, 97]));
			ExcFuncoesExcel.PintaCelula(ref oSheet, "C", num.ToString(), "", 15);
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).ColumnWidth = 80;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).VerticalAlignment = 2;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).HorizontalAlignment = 3;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Size = 12;
			((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).Font.Bold = true;
			text = "A" + Conversions.ToString(num) + ":C" + Conversions.ToString(num);
			num++;
			DeclaracoesGeral._uscPagina.Quantidade = dg.RowCount - 1;
			DeclaracoesGeral._uscPagina.pbIniciar();
			try
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = (int)(dg.RowCount - 1L);
				for (int i = 0; i <= num4; i++)
				{
					text = "A" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[0].Value.ToString()));
					text = "B" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[1].Value.ToString()));
					text = "C" + Conversions.ToString(num);
					((_Worksheet)oSheet).get_Range((object)text, RuntimeHelpers.GetObjectValue(Missing.Value)).set_Value(RuntimeHelpers.GetObjectValue(Missing.Value), (object)("'" + dg.Rows[i].Cells[3].Value.ToString()));
					num2++;
					if (num2 == 2)
					{
						num2 = 0;
						ExcFuncoesExcel.PintaCelula(ref oSheet, "A" + num, ":C" + num, "", 36);
					}
					num3++;
					num++;
					if (num3 == 20)
					{
						num3 = 0;
						string cell = "A" + Conversions.ToString(num + 21);
						((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
					}
					DeclaracoesGeral._uscPagina.pbPasso();
				}
				text = "A1:C" + Conversions.ToString(num - 1);
				ExcFuncoesExcel.CriaLinhasInterna(ref oSheet, text);
				string cell2 = "A1";
				((_Worksheet)oSheet).get_Range((object)cell2, RuntimeHelpers.GetObjectValue(Missing.Value)).Select();
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				ProjectData.ClearProjectError();
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void ImportaTextos(ref Worksheet oSheet, ref DataGridView dg, ref mTextos[] mTextosAtualizados)
	{
		int num = 1;
		string cell = "A1";
		checked
		{
			while (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
			{
				num++;
				cell = "A" + Conversions.ToString(num);
			}
			DeclaracoesGeral._uscPagina.Quantidade = num;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num2 = num - 1;
			for (int i = 2; i <= num2; i++)
			{
				string text = "";
				string text2 = "";
				string text3 = "";
				cell = "A" + i;
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					text = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
				}
				cell = "B" + i;
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					text2 = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
				}
				cell = "C" + i;
				if (Operators.ConditionalCompareObjectNotEqual(((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)), null, TextCompare: true))
				{
					text3 = ((_Worksheet)oSheet).get_Range((object)cell, RuntimeHelpers.GetObjectValue(Missing.Value)).get_Value(RuntimeHelpers.GetObjectValue(Missing.Value)).ToString();
				}
				DeclaracoesGeral._uscPagina.pbPasso();
				int num3 = Information.UBound(mTextosAtualizados);
				for (int j = 1; j <= num3; j++)
				{
					if ((Operators.CompareString(text.ToString().ToUpper().Trim(), j.ToString(), TextCompare: true) == 0) & (Operators.CompareString(text2.ToString().ToUpper().Trim(), mTextosAtualizados[j].sPagina, TextCompare: true) == 0))
					{
						if (Operators.CompareString(mTextosAtualizados[j].sTexto, text3.ToString(), TextCompare: true) != 0)
						{
							mTextosAtualizados[j].sTexto = text3.ToString();
						}
						break;
					}
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static string EncontraTextoDoCabo(structureTextoCaderno[] Texto, string sHandleLinha)
	{
		string result = "";
		int num = Information.UBound(Texto);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			if (Operators.CompareString(Texto[i].sHandleVeia, sHandleLinha, TextCompare: true) == 0)
			{
				result = Texto[i].sHandleTexto;
				break;
			}
		}
		return result;
	}

	public static void AtualizaUnidadeAlternativo(string pagina, string unidade, string alternativo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
		Database database = mdiActiveDocument.Database;
		_ = mdiActiveDocument.Editor;
		DocumentLock val = mdiActiveDocument.LockDocument();
		try
		{
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				LayerTable val3 = (LayerTable)val2.GetObject(database.LayerTableId, (OpenMode)0);
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = val3.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						LayerTableRecord layer = (LayerTableRecord)val2.GetObject(current, (OpenMode)0);
						if (Operators.CompareString(((SymbolTableRecord)layer).Name.ToString(), pagina, TextCompare: true) == 0)
						{
							((DBObject)layer).UpgradeOpen();
							XDataGeral.GravarXDataUnidadeAlternativo(ref layer, unidade, alternativo);
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
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void ApagaTextoEmBrabcoSemXdata()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
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
						DBText val5 = (DBText)(object)((val4 is DBText) ? val4 : null);
						if (!((DisposableWrapper)(object)val5 != (DisposableWrapper)null))
						{
							MText val6 = (MText)(object)((val4 is MText) ? val4 : null);
							if ((DisposableWrapper)(object)val6 != (DisposableWrapper)null && ((DBObject)val6).XData == (ResultBuffer)null && Operators.CompareString(val6.Contents.Trim(), "", TextCompare: true) == 0)
							{
								list.Add(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString());
							}
						}
						else if (((DBObject)val5).XData == null && Operators.CompareString(val5.TextString.Trim(), "", TextCompare: true) == 0)
						{
							list.Add(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString());
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
				throw;
			}
			foreach (string item in list)
			{
				ApagaUmTexto(item);
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void ApagaUmTexto(string sHandle)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Entity val3 = (Entity)Geral.HandleToObject(sHandle);
				if (val3 != null)
				{
					((DBObject)val3).UpgradeOpen();
					((DBObject)val3).Erase();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
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

	public static void CriarUmTexto(ref string sTipo, string sTexto, string sHandlePL, string sXdata)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected Obj, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Invalid comparison between Unknown and I4
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Invalid comparison between Unknown and I4
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Invalid comparison between Unknown and I4
		//IL_03a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				TextStyleTable val5 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)1);
				ObjectId textStyleId = (((SymbolTable)val5).Has("Romans") ? ((SymbolTable)val5)["Romans"] : ((SymbolTable)val5)["Standard"]);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				DBText val6 = new DBText();
				val6.TextString = sTexto;
				((Entity)val6).ColorIndex = DeclaracoesGeral.Conf.CorTextoInterligacao;
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				val6.Height = DeclaracoesGeral.Conf.FonteCabos;
				if (Operators.CompareString(sTipo, "V", TextCompare: true) == 0)
				{
					val6.Rotation = Math.PI / 2.0;
				}
				double dDiferencaH = 0.0;
				double dDiferencaV = 0.0;
				val6.HorizontalMode = (TextHorizontalMode)4;
				Extents3d value;
				Point3d val7;
				if (Operators.CompareString(sTipo, "V", TextCompare: true) != 0)
				{
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MaxPoint;
					double x = val7.X;
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MinPoint;
					dDiferencaH = (x - val7.X) / 2.0 + DeclaracoesGeral.Conf.FonteCabos / 2.0;
				}
				else
				{
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MaxPoint;
					double y = val7.Y;
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MinPoint;
					dDiferencaV = (y - val7.Y) / 2.0;
				}
				val6.VerticalMode = (TextVerticalMode)1;
				val6.TextStyleId = textStyleId;
				val6.Position = new Point3d(0.0, 0.0, 0.0);
				JigTextoADD jigTextoADD = new JigTextoADD(val6, ref dDiferencaH, ref dDiferencaV, DeclaracoesGeral.Conf.FonteCabos);
				PromptResult val8 = editor.Drag((Jig)(object)jigTextoADD);
				PromptStatus status = val8.Status;
				if ((int)status == -5002)
				{
					((DisposableWrapper)val6).Dispose();
				}
				else if ((int)status == -5001)
				{
					((DisposableWrapper)val6).Dispose();
				}
				else
				{
					if ((int)status != 5100)
					{
					}
					if (Operators.CompareString(sTipo, "V", TextCompare: true) != 0)
					{
						DBText val9 = val6;
						val7 = val6.Position;
						double num = val7.X + dDiferencaH;
						val7 = val6.Position;
						val9.AlignmentPoint = new Point3d(num, val7.Y + DeclaracoesGeral.Conf.FonteCabos / 2.0, 0.0);
						DBText val10 = val6;
						val7 = val6.Position;
						double num2 = val7.X + dDiferencaH;
						val7 = val6.Position;
						val10.Position = new Point3d(num2, val7.Y, 0.0);
					}
					else
					{
						DBText val11 = val6;
						val7 = val6.Position;
						double num3 = val7.X + dDiferencaH - DeclaracoesGeral.Conf.FonteCabos / 2.0;
						val7 = val6.Position;
						val11.AlignmentPoint = new Point3d(num3, val7.Y + dDiferencaV, 0.0);
						DBText val12 = val6;
						val7 = val6.Position;
						double num4 = val7.X + dDiferencaH;
						val7 = val6.Position;
						val12.Position = new Point3d(num4, val7.Y, 0.0);
					}
					val4.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					Entity ent = (Entity)(object)val6;
					XDataInterligacao.GravarXDataAuxInterligacao(ref ent, sHandlePL, 3, "", sXdata);
					val6 = (DBText)ent;
					((Entity)val6).Draw();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val2.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
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
		PointMonitorToolTips.StartMonitor();
	}

	public static ObjectId CriarUmTextoSimples(Point3d pt, ref string sTipoHV, string sTexto)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		sTipoHV = sTipoHV.ToUpper();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)1);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				TextStyleTable val5 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)1);
				ObjectId textStyleId = (((SymbolTable)val5).Has("Romans") ? ((SymbolTable)val5)["Romans"] : ((SymbolTable)val5)["Standard"]);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				DBText val6 = new DBText();
				val6.TextString = sTexto;
				((Entity)val6).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
				((Entity)val6).Layer = DeclaracoesGeral.ativo.Pagina;
				val6.Height = 1.1;
				if (Operators.CompareString(sTipoHV, "V", TextCompare: true) == 0)
				{
					val6.Rotation = Math.PI / 2.0;
				}
				double num = 0.0;
				double num2 = 0.0;
				val6.HorizontalMode = (TextHorizontalMode)0;
				val6.VerticalMode = (TextVerticalMode)1;
				val6.TextStyleId = textStyleId;
				val6.Position = new Point3d(0.0, 0.0, 0.0);
				if (Operators.CompareString(sTipoHV, "V", TextCompare: true) != 0)
				{
					val6.AlignmentPoint = new Point3d(pt.X + num, pt.Y + DeclaracoesGeral.Conf.FonteCabos / 2.0, 0.0);
					val6.Position = new Point3d(pt.X + num, pt.Y, 0.0);
				}
				else
				{
					val6.AlignmentPoint = new Point3d(pt.X + num - DeclaracoesGeral.Conf.FonteCabos / 2.0, pt.Y + num2, 0.0);
					val6.Position = new Point3d(pt.X + num, pt.Y, 0.0);
				}
				val4.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				((Entity)val6).Draw();
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				result = ((DBObject)val6).ObjectId;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val2.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
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
		return result;
	}

	public static void NomeValido(ref TextBox tbNome)
	{
		string text = tbNome.Text;
		string text2 = "";
		bool flag = false;
		int num = Strings.Len(text);
		for (int i = 1; i <= num; i = checked(i + 1))
		{
			string text3 = Strings.Mid(text, i, 1);
			flag = false;
			if (!Versioned.IsNumeric(text3))
			{
				int charCode = Strings.Asc(Strings.UCase(text3));
				if (Strings.InStr("AÃÁBCÇDEÉÊFGHIÍJKLMNOPQRSTUÚVWXYZ", Conversions.ToString(Strings.Chr(charCode)), CompareMethod.Text) != 0)
				{
					flag = true;
				}
				else
				{
					string left = text3;
					if (Operators.CompareString(left, "-", TextCompare: true) == 0 || Operators.CompareString(left, "_", TextCompare: true) == 0 || Operators.CompareString(left, " ", TextCompare: true) == 0 || Operators.CompareString(left, ".", TextCompare: true) == 0 || Operators.CompareString(left, "/", TextCompare: true) == 0 || Operators.CompareString(left, "\\", TextCompare: true) == 0 || Operators.CompareString(left, "|", TextCompare: true) == 0 || Operators.CompareString(left, "+", TextCompare: true) == 0 || Operators.CompareString(left, "(", TextCompare: true) == 0 || Operators.CompareString(left, ")", TextCompare: true) == 0 || Operators.CompareString(left, "[", TextCompare: true) == 0 || Operators.CompareString(left, "]", TextCompare: true) == 0)
					{
						flag = true;
					}
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				text2 += text3;
			}
		}
		tbNome.Text = text2;
	}

	public static double RetornaPrimeiroTerminal(string T)
	{
		double result = 1000000.0;
		string text = "";
		text = T.Trim().ToUpper();
		if (Operators.CompareString(text, "", TextCompare: true) != 0)
		{
			if (!Versioned.IsNumeric(text))
			{
				goto IL_003b;
			}
			int length = text.Length;
			int num = 1;
			while (num <= length)
			{
				if (Operators.CompareString(Strings.Mid(text, num, 1), ".", TextCompare: true) == 0 || Versioned.IsNumeric(Strings.Mid(text, num, 1)))
				{
					num = checked(num + 1);
					continue;
				}
				goto IL_003b;
			}
			string text2 = text;
			if (!int.TryParse(text2, out var _))
			{
				string[] array = text2.Split('.');
				string text3 = array[0];
				string text4 = array[1];
				if (Operators.CompareString(text3, "", TextCompare: true) == 0)
				{
					text3 = Conversions.ToString(0);
				}
				if (Operators.CompareString(text4, "", TextCompare: true) == 0)
				{
					text4 = Conversions.ToString(0);
				}
				double num2 = Conversions.ToDouble(text3);
				double num3 = Conversions.ToDouble(text4);
				num3 /= 10000.0;
				num2 += num3;
				result = num2;
			}
			else
			{
				result = Conversions.ToDouble(text);
			}
		}
		else
		{
			result = 0.0;
		}
		goto IL_05d7;
		IL_05d7:
		return result;
		IL_003b:
		checked
		{
			if (!((text.Length == 1) & (Strings.Asc(Strings.Mid(text, 1, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, 1, 1)) <= 90)))
			{
				if (!(Versioned.IsNumeric(Strings.Mid(text, 1, text.Length - 1)) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, text.Length, 1)) <= 90)))
				{
					if ((Strings.Asc(Strings.Mid(text, 1, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, 1, 1)) <= 90) & Versioned.IsNumeric(Strings.Mid(text, 2, text.Length - 1)))
					{
						string text5 = Strings.Mid(text, 2, text.Length - 1);
						if (int.TryParse(text5, out var _))
						{
							result = (double)Strings.Asc(Strings.Mid(text, 1, 1)) * 1000.0;
							result += Conversions.ToDouble(text5);
							goto IL_05d7;
						}
					}
					object left = Strings.InStr(1, text, ":", CompareMethod.Text);
					if (Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: true))
					{
						left = Strings.InStr(1, text, "-", CompareMethod.Text);
					}
					if (Operators.ConditionalCompareObjectEqual(left, 0, TextCompare: true))
					{
						left = Strings.InStr(1, text, ".", CompareMethod.Text);
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectGreater(left, 0, TextCompare: true), Operators.CompareObjectLess(left, text.Length, TextCompare: true))) && ((Strings.Asc(Strings.Mid(text, 1, 1)) >= 65) & (Strings.Asc(Strings.Mid(text, 1, 1)) <= 90)))
					{
						string text6 = Strings.Mid(text, 1, 1);
						string text7 = Strings.Mid(text, 2, Conversions.ToInteger(Operators.SubtractObject(left, 2)));
						if (Versioned.IsNumeric(text7))
						{
							string text8 = Strings.Mid(text, Conversions.ToInteger(Operators.AddObject(left, 1)));
							if (Versioned.IsNumeric(text8))
							{
								result = (double)Strings.Asc(text6) * 1000.0;
								result += Conversions.ToDouble(text7);
								result += Conversions.ToDouble(text8) / 1000.0;
								goto IL_05d7;
							}
						}
					}
					string text9 = "";
					string text10 = "";
					string text11 = "";
					int num4 = 1;
					int length2 = text.Length;
					for (int i = 1; i <= length2; i++)
					{
						if (!Versioned.IsNumeric(Strings.Mid(text, i, 1)))
						{
							text10 = Strings.Mid(text, i, 1);
							num4++;
							continue;
						}
						switch (num4)
						{
						case 2:
							text11 += Strings.Mid(text, i, 1);
							break;
						case 1:
							text9 += Strings.Mid(text, i, 1);
							break;
						}
					}
					if (!((num4 == 2) & (Operators.CompareString(text9, "", TextCompare: true) != 0) & (Operators.CompareString(text11, "", TextCompare: true) != 0)))
					{
						if ((Strings.InStr(1, text, "+", CompareMethod.Text) > 0) | (Strings.InStr(1, text, "-", CompareMethod.Text) > 0))
						{
							string text8 = Conversions.ToString(text.Length);
							string text12 = "";
							int num5 = Conversions.ToInteger(text8);
							for (int j = 1; j <= num5 && Versioned.IsNumeric(Strings.Mid(text, j, 1)); j++)
							{
								text12 += Strings.Mid(text, j, 1);
							}
							if (Operators.CompareString(text12, "", TextCompare: true) != 0)
							{
								string numberDecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
								if (Strings.InStr(1, text, "+", CompareMethod.Text) <= 0)
								{
									if (Strings.InStr(1, text, "-", CompareMethod.Text) > 0)
									{
										text12 = text12 + numberDecimalSeparator + "0";
										result = Conversions.ToDouble(text12);
									}
								}
								else
								{
									text12 = text12 + numberDecimalSeparator + "1";
									result = Conversions.ToDouble(text12);
								}
							}
						}
					}
					else
					{
						result = Conversions.ToDouble(text9) * 1000.0;
						result += (double)Strings.Asc(text10);
						result += Conversions.ToDouble(text11) / 100.0;
					}
				}
				else
				{
					result = Conversions.ToDouble(Strings.Mid(text, 1, text.Length - 1));
					result += (double)Strings.Asc(Strings.Mid(text, text.Length, 1)) / 100.0;
				}
			}
			else
			{
				result = (double)Strings.Asc(text) / 100.0;
			}
			goto IL_05d7;
		}
	}

	public static string RetornaValorMais0000MaisNum(string sValor)
	{
		string result = sValor;
		string text = "";
		string text2 = "";
		int length = sValor.Length;
		checked
		{
			for (int i = length; i >= 1; i += -1)
			{
				if (!Versioned.IsNumeric(Strings.Mid(sValor, i, 1)))
				{
					string text3 = "";
					if (Operators.CompareString(text2, "", TextCompare: true) == 0)
					{
						result = sValor;
						break;
					}
					text = Strings.Mid(sValor, 1, sValor.Length - text2.Length);
					int length2 = text2.Length;
					for (int j = length2; j <= 2; j++)
					{
						text3 += "0";
					}
					result = text + text3 + text2;
					break;
				}
				text2 = ((Operators.CompareString(text2, "", TextCompare: true) == 0) ? Strings.Mid(sValor, i, 1) : (Strings.Mid(sValor, i, 1) + text2));
			}
			return result;
		}
	}

	public static void EncontraAlturadoTexto_Linha(ref double dLinha, ref double dTexto)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected Obj, but got Unknown
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				try
				{
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					try
					{
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								try
								{
									MText val6 = (MText)(object)((val5 is MText) ? val5 : null);
									if (val6 != null)
									{
										Entity Ent = val5;
										if (Operators.CompareString(XDataDispositivosMaster.LerXDataTextoLP(ref Ent), "", TextCompare: true) != 0)
										{
											dTexto = Conversions.ToDouble(val6.Ascent.ToString());
										}
									}
									Line val7 = (Line)(object)((val5 is Line) ? val5 : null);
									if (val7 != null)
									{
										Entity Ent = (Entity)(object)val7;
										string left = XDataDispositivosMaster.LerXDataLinhaTextoLP(ref Ent);
										val7 = (Line)Ent;
										if (Operators.CompareString(left, "", TextCompare: true) != 0)
										{
											Point3d val8 = val7.StartPoint;
											double y = val8.Y;
											val8 = val7.EndPoint;
											if (!(y > val8.Y))
											{
												val8 = val7.EndPoint;
												double y2 = val8.Y;
												val8 = val7.StartPoint;
												dLinha = y2 - val8.Y;
											}
											else
											{
												val8 = val7.StartPoint;
												double y3 = val8.Y;
												val8 = val7.EndPoint;
												dLinha = y3 - val8.Y;
											}
										}
									}
								}
								finally
								{
									((IDisposable)val5)?.Dispose();
								}
								DeclaracoesGeral._uscPagina.pbPasso();
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						dTexto = Math.Round(dTexto, 2);
						dLinha /= 2.0;
						dLinha = Math.Round(dLinha, 2);
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
				}
				finally
				{
					((IDisposable)val3)?.Dispose();
				}
				DeclaracoesGeral._uscPagina.pbFim();
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

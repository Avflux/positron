using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
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

public class clsLayoutMec
{
	public struct StructureDisps
	{
		public string nome;

		public double X;

		public double Y;

		public string Handle;
	}

	public struct StructurePlaquetas
	{
		public int iOrdem;

		public int indice_OrdemPL;

		public int indice_OrdemLM;

		public int indice_OrdemLAY;

		public string Disp;

		public string Etiq;

		public string Painel;

		public int iTipo;

		public double dPG;

		public double dX;

		public double dY;

		public string Handle;
	}

	public struct StructurePlaquetasPainel
	{
		public int indice_OrdemPL;

		public string Disp;

		public string Etiq;

		public string Painel;
	}

	public struct StructureLmPainel
	{
		public int indice_OrdemLM;

		public string Disp;

		public string Painel;
	}

	public static string InserirBlocoDispLayout(int painel, string tag, string alternativo, string nomeBloco, bool bAlternativo, string sEtiqueta, bool bETQ, bool bNomeVisivel, string sHandle)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected Obj, but got Unknown
		//IL_03ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Invalid comparison between Unknown and I4
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected Obj, but got Unknown
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected Obj, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected Obj, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected Obj, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected Obj, but got Unknown
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Expected Obj, but got Unknown
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomeBloco.Substring(0, checked(nomeBloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaLayout + nomeBloco;
					if (!((SymbolTable)val4).Has(text))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text2, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					BlockReference blockRef = new BlockReference(Point3d.Origin, val3);
					((Entity)blockRef).Layer = DeclaracoesGeral.ativo.Pagina;
					Jig jig = new Jig((Entity)(object)blockRef);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val8 = editor.Drag((Jig)(object)jig);
					if (!(((int)val8.Status == -5002) | ((int)val8.Status == -5001)))
					{
						val5.AppendEntity((Entity)(object)blockRef);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
						BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
						bool flag = false;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val9.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val10 = (Entity)val2.GetObject(current, (OpenMode)0);
								if (val10 is AttributeDefinition)
								{
									AttributeDefinition val11 = (AttributeDefinition)val10;
									AttributeReference val12 = new AttributeReference();
									val12.SetAttributeFromBlock(val11, blockRef.BlockTransform);
									if (Operators.CompareString(val11.Tag, "ALTERNATIVO", TextCompare: true) == 0)
									{
										flag = true;
										break;
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						BlockTableRecordEnumerator enumerator2 = default;
						try
						{
							enumerator2 = val9.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val13 = (Entity)val2.GetObject(current2, (OpenMode)0);
								if (!(val13 is AttributeDefinition))
								{
									continue;
								}
								AttributeDefinition val14 = (AttributeDefinition)val13;
								AttributeReference val15 = new AttributeReference();
								val15.SetAttributeFromBlock(val14, blockRef.BlockTransform);
								string tag2 = val14.Tag;
								if (Operators.CompareString(tag2, "NOME1", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag2, "NUM", TextCompare: true) != 0)
									{
										if (Operators.CompareString(tag2, "ALTERNATIVO", TextCompare: true) != 0)
										{
											((DBText)val15).TextString = val14.Tag;
										}
										else
										{
											((DBText)val15).TextString = alternativo;
										}
									}
									else
									{
										if (Operators.CompareString(sEtiqueta, "#B#", TextCompare: true) == 0)
										{
											sEtiqueta = "";
										}
										((DBText)val15).TextString = sEtiqueta;
										((Entity)val15).Visible = bETQ;
									}
								}
								else
								{
									if (!(bAlternativo & (Operators.CompareString(alternativo, "", TextCompare: true) != 0) & !flag))
									{
										((DBText)val15).TextString = tag;
									}
									else
									{
										((DBText)val15).TextString = alternativo;
									}
									((Entity)val15).Visible = bNomeVisivel;
								}
								((DBText)val15).AdjustAlignment(database);
								blockRef.AttributeCollection.AppendAttribute(val15);
								DeclaracoesGeral.bAnularEventos = true;
								val2.AddNewlyCreatedDBObject((DBObject)(object)val15, true);
								((Entity)val15).Draw();
								((DBObject)val15).XData = ((DBObject)val14).XData;
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						((Entity)blockRef).Draw();
						XDataLayout.GravarXDataDispLayout(ref blockRef, painel, tag, alternativo, sEtiqueta, sHandle);
						result = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static ObjectId InserirPrimeiroBorneLayout(string nomebloco, int painel, string regua, string borne, int tipoBorne, bool bVertical, double dFonte)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Expected Obj, but got Unknown
		//IL_039f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected Obj, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Invalid comparison between Unknown and I4
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected Obj, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected Obj, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0451: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0344: Expected Obj, but got Unknown
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected Obj, but got Unknown
		ObjectId result = ObjectId.Null;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomebloco.Substring(0, checked(nomebloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaLayout + nomebloco;
					if (!((SymbolTable)val4).Has(text))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text2, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					BlockReference val8 = new BlockReference(Point3d.Origin, val3);
					((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
					Jig jig = new Jig((Entity)(object)val8);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val9 = editor.Drag((Jig)(object)jig);
					if (!(((int)val9.Status == -5002) | ((int)val9.Status == -5001)))
					{
						val5.AppendEntity((Entity)(object)val8);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
						((Entity)val8).Draw();
						Entity ENT = (Entity)(object)val8;
						XDataLayout.GravarXDataBorneLayout(ref ENT, painel, regua, borne, tipoBorne);
						val8 = (BlockReference)ENT;
						result = ((DBObject)val8).ObjectId;
						TextStyleTable val10 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
						ObjectId textStyleId = (((SymbolTable)val10).Has("Romans") ? ((SymbolTable)val10)["Romans"] : ((SymbolTable)val10)["Standard"]);
						DBText val11 = new DBText();
						DBText val12 = new DBText();
						val11.TextString = regua;
						((Entity)val11).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
						((Entity)val11).Layer = ((Entity)val8).Layer;
						val11.Height = dFonte;
						val11.TextStyleId = textStyleId;
						val11.WidthFactor = 1.0;
						val12.TextString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						((Entity)val12).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
						((Entity)val12).Layer = ((Entity)val8).Layer;
						val12.Height = dFonte;
						val12.TextStyleId = textStyleId;
						val12.WidthFactor = 1.0;
						Point3d position;
						Point3d alignmentPoint;
						Point3d alignmentPoint2;
						if (bVertical)
						{
							position = val8.Position;
							double x = position.X;
							position = val8.Position;
							alignmentPoint = new Point3d(x, position.Y + 2.0, 0.0);
							val11.HorizontalMode = (TextHorizontalMode)1;
							val11.VerticalMode = (TextVerticalMode)0;
							position = val8.Position;
							double num = position.X + 5.0;
							position = val8.Position;
							alignmentPoint2 = new Point3d(num, position.Y + 2.0, 0.0);
							val12.HorizontalMode = (TextHorizontalMode)1;
							val12.VerticalMode = (TextVerticalMode)0;
						}
						else
						{
							position = val8.Position;
							double num2 = position.X - 2.0;
							position = val8.Position;
							alignmentPoint = new Point3d(num2, position.Y + 2.0, 0.0);
							val11.HorizontalMode = (TextHorizontalMode)1;
							val11.VerticalMode = (TextVerticalMode)0;
							position = val8.Position;
							double num3 = position.X - 2.0 + 5.0;
							position = val8.Position;
							alignmentPoint2 = new Point3d(num3, position.Y + 2.0, 0.0);
							val12.HorizontalMode = (TextHorizontalMode)1;
							val12.VerticalMode = (TextVerticalMode)0;
						}
						val11.AlignmentPoint = alignmentPoint;
						val5.AppendEntity((Entity)(object)val11);
						ENT = (Entity)(object)val11;
						XDataLayout.GravarXDataBorneLayout(ref ENT, painel, regua, Conversions.ToString(0), tipoBorne);
						val11 = (DBText)ENT;
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
						val12.AlignmentPoint = alignmentPoint2;
						val5.AppendEntity((Entity)(object)val12);
						ENT = (Entity)(object)val12;
						XDataLayout.GravarXDataBorneLayout(ref ENT, painel, regua, Conversions.ToString(0), 3);
						val12 = (DBText)ENT;
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static ObjectId InserirOutroBorneLayout(string nomebloco, Point3d ptIns, int painel, string regua, string borne, int tipoBorne)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Obj, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		ObjectId result = ObjectId.Null;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					ObjectId val3 = ObjectId.Null;
					BlockTable val4 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val5 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[BlockTableRecord.ModelSpace], (OpenMode)1);
					string text = nomebloco.Substring(0, checked(nomebloco.Length - 4));
					string text2 = DeclaracoesGeral.Conf.dirSimbologiaLayout + nomebloco;
					if (!((SymbolTable)val4).Has(text))
					{
						Database val6 = new Database(false, true);
						val6.ReadDwgFile(text2, FileShare.Read, true, "");
						DeclaracoesGeral.bAnularEventos = true;
						val3 = database.Insert(text, val6, false);
						((DisposableWrapper)val6).Dispose();
					}
					else
					{
						BlockTableRecord val7 = (BlockTableRecord)val2.GetObject(((SymbolTable)val4)[text], (OpenMode)0);
						val3 = ((DBObject)val7).Id;
					}
					BlockReference val8 = new BlockReference(ptIns, val3);
					((Entity)val8).Layer = DeclaracoesGeral.ativo.Pagina;
					val5.AppendEntity((Entity)(object)val8);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val8, true);
					_ = (BlockTableRecord)val2.GetObject(val3, (OpenMode)0);
					((Entity)val8).Draw();
					Entity ENT = (Entity)(object)val8;
					XDataLayout.GravarXDataBorneLayout(ref ENT, painel, regua, borne, tipoBorne);
					val8 = (BlockReference)ENT;
					result = ((DBObject)val8).ObjectId;
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void CarregaDispositivosInseridos(int painel, List<string> lTags)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
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
					Entity val4 = (Entity)current.GetObject((OpenMode)0);
					BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (blockRef != null)
					{
						int painel2 = 0;
						string tag = "";
						string alternativo = "";
						string Handle = "";
						if (XDataLayout.lerXDataDispLayout(ref blockRef, ref painel2, ref tag, ref alternativo, ref Handle) && painel == painel2)
						{
							lTags.Add(Conversions.ToString(painel2) + "-" + tag);
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static string BuscaHandleDoDispLayout(int painel, string sTags)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
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
					Entity val4 = (Entity)current.GetObject((OpenMode)0);
					BlockReference blockRef = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (blockRef != null)
					{
						int painel2 = 0;
						string tag = "";
						string alternativo = "";
						string Handle = "";
						if (XDataLayout.lerXDataDispLayout(ref blockRef, ref painel2, ref tag, ref alternativo, ref Handle) && ((painel == painel2) & (Operators.CompareString(sTags, tag, TextCompare: true) == 0)))
						{
							result = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		return result;
	}

	public static void CarregaBornesInseridos(int painel, string regua, List<string> lBornes)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
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
				int tipoBorne = default;
				while (enumerator.MoveNext())
				{
					ObjectId current = enumerator.Current;
					Entity val4 = (Entity)current.GetObject((OpenMode)0);
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (val5 != null)
					{
						int painel2 = 0;
						string regua2 = "";
						string borne = "";
						Entity ent = (Entity)(object)val5;
						bool flag = XDataLayout.lerXDataBorneLayout(ref ent, ref painel2, ref regua2, ref borne, ref tipoBorne);
						val5 = (BlockReference)ent;
						if (flag && ((painel == painel2) & (Operators.CompareString(regua, regua2, TextCompare: true) == 0)))
						{
							lBornes.Add(borne);
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
			ProjectData.ClearProjectError();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void ApagaReguaSelecionada(int painel, string regua)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
					int tipoBorne = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity ent = (Entity)current.GetObject((OpenMode)0);
						int painel2 = 0;
						string regua2 = "";
						string borne = "";
						if (XDataLayout.lerXDataBorneLayout(ref ent, ref painel2, ref regua2, ref borne, ref tipoBorne) && ((painel == painel2) & (Operators.CompareString(regua, regua2, TextCompare: true) == 0)))
						{
							((DBObject)ent).UpgradeOpen();
							((DBObject)ent).Erase();
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

	public static void EditaNomeAlternativoLayoutMec(int painel, string TagOriginal, string TagNovo, string Alternativo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (blockRef == null)
						{
							continue;
						}
						int painel2 = 0;
						string tag = "";
						string alternativo = "";
						string Handle = "";
						if (!XDataLayout.lerXDataDispLayout(ref blockRef, ref painel2, ref tag, ref alternativo, ref Handle) || !((painel == painel2) & (Operators.CompareString(tag, TagOriginal, TextCompare: true) == 0)))
						{
							continue;
						}
						((DBObject)blockRef).UpgradeOpen();
						XDataLayout.GravarXDataDispLayout(ref blockRef, painel, TagNovo, Alternativo, "", ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
						foreach (object item in blockRef.AttributeCollection)
						{
							ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
							string left = val7.Tag.ToUpper();
							if (Operators.CompareString(left, "NOME1", TextCompare: true) == 0)
							{
								((DBText)val7).TextString = TagNovo;
							}
						}
						break;
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

	public static void AdicionaQuantidadeDosBornes(Point3d PtIni, Point3d PtFim, string SQuantidade, bool BVertical, bool BDireitaOuCima, int Painel, string Regua, string Borne, int TipoBorne, double DFonte)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected Obj, but got Unknown
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
		//IL_062d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0706: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0744: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected Obj, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected Obj, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected Obj, but got Unknown
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected Obj, but got Unknown
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_051c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0521: Unknown result type (might be due to invalid IL or missing references)
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Unknown result type (might be due to invalid IL or missing references)
		//IL_052d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_056a: Expected Obj, but got Unknown
		Point2d val = default;
		Point2d val2 = default;
		Point2d val3 = default;
		Point2d val4 = default;
		Polyline val5 = new Polyline();
		((Entity)val5).SetDatabaseDefaults();
		if (!BVertical)
		{
			if (!BDireitaOuCima)
			{
				val = new Point2d(PtIni.X, PtIni.Y);
				val2 = new Point2d(PtIni.X + 0.7, PtIni.Y - 0.7);
				val3 = new Point2d(PtFim.X - 0.7, PtFim.Y - 0.7);
				val4 = new Point2d(PtFim.X, PtFim.Y);
			}
			else
			{
				val = new Point2d(PtIni.X, PtIni.Y);
				val2 = new Point2d(PtIni.X + 0.7, PtIni.Y + 0.7);
				val3 = new Point2d(PtFim.X - 0.7, PtFim.Y + 0.7);
				val4 = new Point2d(PtFim.X, PtFim.Y);
			}
		}
		else if (!BDireitaOuCima)
		{
			val = new Point2d(PtIni.X, PtIni.Y);
			val2 = new Point2d(PtIni.X - 0.7, PtIni.Y - 0.7);
			val3 = new Point2d(PtFim.X - 0.7, PtFim.Y + 0.7);
			val4 = new Point2d(PtFim.X, PtFim.Y);
		}
		else
		{
			val = new Point2d(PtIni.X, PtIni.Y);
			val2 = new Point2d(PtIni.X + 0.7, PtIni.Y - 0.7);
			val3 = new Point2d(PtFim.X + 0.7, PtFim.Y + 0.7);
			val4 = new Point2d(PtFim.X, PtFim.Y);
		}
		val5.AddVertexAt(0, val, 0.0, 0.0, 0.0);
		val5.AddVertexAt(1, val2, 0.0, 0.0, 0.0);
		val5.AddVertexAt(2, val3, 0.0, 0.0, 0.0);
		val5.AddVertexAt(3, val4, 0.0, 0.0, 0.0);
		DocumentLock val6 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val7 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val8 = (BlockTable)val7.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val9 = (BlockTableRecord)val7.GetObject(((SymbolTable)val8)[BlockTableRecord.ModelSpace], (OpenMode)1);
				val9.AppendEntity((Entity)(object)val5);
				DeclaracoesGeral.bAnularEventos = true;
				val7.AddNewlyCreatedDBObject((DBObject)(object)val5, true);
				Entity ENT = (Entity)(object)val5;
				XDataLayout.GravarXDataBorneLayout(ref ENT, Painel, Regua, Borne, TipoBorne);
				val5 = (Polyline)ENT;
				double num = Math.Round(Math.PI, 2);
				TextStyleTable val10 = (TextStyleTable)val7.GetObject(database.TextStyleTableId, (OpenMode)0);
				ObjectId textStyleId = (((SymbolTable)val10).Has("Romans") ? ((SymbolTable)val10)["Romans"] : ((SymbolTable)val10)["Standard"]);
				DBText val11 = new DBText();
				Point3d point3dAt = val5.GetPoint3dAt(1);
				Point3d point3dAt2 = val5.GetPoint3dAt(2);
				double num2 = point3dAt.DistanceTo(point3dAt2) / 2.0;
				double num3 = 1.0;
				double x = point3dAt2.X - point3dAt.X;
				double y = point3dAt2.Y - point3dAt.Y;
				double num4 = Math.Round(Math.Atan2(y, x), 2);
				if (!((num4 <= num / 2.0) & (num4 > num / 2.0 * -1.0)))
				{
					val11.VerticalMode = (TextVerticalMode)1;
					val11.HorizontalMode = (TextHorizontalMode)1;
				}
				else
				{
					val11.VerticalMode = (TextVerticalMode)1;
					val11.HorizontalMode = (TextHorizontalMode)1;
				}
				double num5 = num2 * Math.Cos(num4);
				double num6 = num2 * Math.Sin(num4);
				double num7 = num3 * Math.Cos(Math.PI / 2.0 - num4);
				double num8 = num3 * Math.Sin(Math.PI / 2.0 - num4);
				if (num8 < 0.0)
				{
					num8 *= -1.0;
				}
				if (num4 == num / 2.0)
				{
					num7 *= -1.0;
				}
				if (((num4 > 0.0) & (num4 < num / 2.0)) | ((num4 < 0.0) & (num4 > num / 2.0 * -1.0)))
				{
					num7 *= -1.0;
				}
				Point3d alignmentPoint = new Point3d(point3dAt.X + num5 + num7, point3dAt.Y + num6 + num8, 0.0);
				((Entity)val11).Layer = DeclaracoesGeral.ativo.Pagina;
				val11.TextString = SQuantidade;
				val11.Height = DFonte;
				val11.TextStyleId = textStyleId;
				((Entity)val11).LineWeight = (LineWeight)9;
				if (!BVertical)
				{
					if (!BDireitaOuCima)
					{
						alignmentPoint = new Point3d(alignmentPoint.X, alignmentPoint.Y - 3.2, 0.0);
						val11.HorizontalMode = (TextHorizontalMode)1;
					}
					else
					{
						alignmentPoint = new Point3d(alignmentPoint.X, alignmentPoint.Y - 0.7, 0.0);
						val11.HorizontalMode = (TextHorizontalMode)1;
					}
				}
				else if (!BDireitaOuCima)
				{
					alignmentPoint = new Point3d(alignmentPoint.X, alignmentPoint.Y, 0.0);
					val11.HorizontalMode = (TextHorizontalMode)2;
				}
				else
				{
					alignmentPoint = new Point3d(alignmentPoint.X + 2.0, alignmentPoint.Y, 0.0);
					val11.HorizontalMode = (TextHorizontalMode)0;
				}
				val11.AlignmentPoint = alignmentPoint;
				val9.AppendEntity((Entity)(object)val11);
				DeclaracoesGeral.bAnularEventos = true;
				val7.AddNewlyCreatedDBObject((DBObject)(object)val11, true);
				ENT = (Entity)(object)val11;
				XDataLayout.GravarXDataBorneLayout(ref ENT, Painel, Regua, Borne, TipoBorne);
				val11 = (DBText)ENT;
				DeclaracoesGeral.bAnularEventos = true;
				val7.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				val7.Abort();
				Interaction.MsgBox(ex2.Message, MsgBoxStyle.Information);
				ProjectData.ClearProjectError();
			}
			finally
			{
				((IDisposable)val7)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val6)?.Dispose();
		}
	}

	public static void CriarNumeroDoPrimeiroBorne(BlockReference blockRef, string sNumero, bool bVertical, bool bDireita, int painel, string regua, string borne, int tipoBorne, double dFonte)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected Obj, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					_ = ObjectId.Null;
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					TextStyleTable val5 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)0);
					ObjectId textStyleId = (((SymbolTable)val5).Has("Romans") ? ((SymbolTable)val5)["Romans"] : ((SymbolTable)val5)["Standard"]);
					DBText val6 = new DBText();
					val6.TextString = sNumero;
					((Entity)val6).ColorIndex = DeclaracoesGeral.Conf.CorTextoCircuito;
					((Entity)val6).Layer = ((Entity)blockRef).Layer;
					val6.Height = dFonte;
					val6.TextStyleId = textStyleId;
					val6.WidthFactor = 1.0;
					Extents3d value;
					Point3d val7;
					Point3d alignmentPoint;
					if (bVertical)
					{
						if (!bDireita)
						{
							value = ((Drawable)blockRef).Bounds.Value;
							val7 = value.MaxPoint;
							double num = val7.X + 1.0;
							value = ((Drawable)blockRef).Bounds.Value;
							val7 = value.MaxPoint;
							alignmentPoint = new Point3d(num, val7.Y, 0.0);
							val6.VerticalMode = (TextVerticalMode)3;
							val6.HorizontalMode = (TextHorizontalMode)0;
						}
						else
						{
							value = ((Drawable)blockRef).Bounds.Value;
							val7 = value.MinPoint;
							double num2 = val7.X - 1.0;
							value = ((Drawable)blockRef).Bounds.Value;
							val7 = value.MaxPoint;
							alignmentPoint = new Point3d(num2, val7.Y, 0.0);
							val6.HorizontalMode = (TextHorizontalMode)2;
							val6.VerticalMode = (TextVerticalMode)3;
						}
					}
					else if (!bDireita)
					{
						value = ((Drawable)blockRef).Bounds.Value;
						val7 = value.MinPoint;
						double x = val7.X;
						value = ((Drawable)blockRef).Bounds.Value;
						val7 = value.MaxPoint;
						alignmentPoint = new Point3d(x, val7.Y + val6.Height + 0.5, 0.0);
						val6.HorizontalMode = (TextHorizontalMode)0;
						val6.VerticalMode = (TextVerticalMode)3;
					}
					else
					{
						value = ((Drawable)blockRef).Bounds.Value;
						val7 = value.MinPoint;
						double x2 = val7.X;
						value = ((Drawable)blockRef).Bounds.Value;
						val7 = value.MinPoint;
						alignmentPoint = new Point3d(x2, val7.Y - 0.5, 0.0);
						val6.HorizontalMode = (TextHorizontalMode)0;
						val6.VerticalMode = (TextVerticalMode)3;
					}
					val6.AlignmentPoint = alignmentPoint;
					val4.AppendEntity((Entity)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					Entity ENT = (Entity)(object)val6;
					XDataLayout.GravarXDataBorneLayout(ref ENT, painel, regua, borne, tipoBorne);
					val6 = (DBText)ENT;
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
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static double CriaTabelaLayout(bool bTitulo, ref Point3d pt, int ix, int iPainel, string sFuncional, string sPlaqueta, bool bAlternativo, int iTipo)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected Obj, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected Obj, but got Unknown
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected Obj, but got Unknown
		//IL_05c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_0447: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Unknown result type (might be due to invalid IL or missing references)
		//IL_0455: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0408: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected Obj, but got Unknown
		//IL_047c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048a: Unknown result type (might be due to invalid IL or missing references)
		double num = 0.0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
				val6.SetSize(1, 3);
				val6.GenerateLayout();
				val6.RecomputeTableBlock(true);
				int num2 = 0;
				int num3 = 1;
				int num4 = 2;
				switch (iTipo)
				{
				case 2:
					num2 = 2;
					num3 = 1;
					num4 = 0;
					break;
				case 0:
					num2 = 0;
					num3 = 1;
					num4 = 2;
					break;
				case 1:
					num2 = 1;
					num3 = 0;
					num4 = 2;
					break;
				}
				((BlockReference)val6).Position = pt;
				val6.Columns[num2].Width = 10.0;
				num = val6.Columns[num2].Width;
				val6.Columns[num3].Width = 25.0;
				num += val6.Columns[num3].Width;
				val6.Columns[num4].Width = 20.0;
				num += val6.Columns[num4].Width;
				int num5 = 2;
				for (int i = 0; i <= num5; i = checked(i + 1))
				{
					((CellRange)val6.Cells[0, i]).TextHeight = 2.0;
					((CellRange)val6.Cells[0, i]).Alignment = (CellAlignment)5;
				}
				if (!bTitulo)
				{
					val6.SetRowHeight(5.0);
					if (!((ix == 0) | (ix > 9999)))
					{
						string text = "";
						if (Strings.Len(ix.ToString()) == 1)
						{
							text = "0";
						}
						val6.Cells[0, num2].TextString = text + ix;
					}
					else
					{
						val6.Cells[0, num2].TextString = "-";
					}
					val6.Cells[0, num3].TextString = sFuncional;
					if (Operators.CompareString(sPlaqueta.Trim(), "", TextCompare: true) == 0)
					{
						sPlaqueta = "-";
					}
					val6.Cells[0, num4].TextString = sPlaqueta;
				}
				else
				{
					val6.SetRowHeight(7.5);
					val6.Cells[0, num2].TextString = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1154]);
					if (!bAlternativo)
					{
						val6.Cells[0, num3].TextString = DeclaracoesGeral.mMensagem[1, 176].ToString().ToUpper();
					}
					else
					{
						val6.Cells[0, num3].TextString = DeclaracoesGeral.mMensagem[1, 10].ToString().ToUpper();
					}
					val6.Cells[0, num4].TextString = DeclaracoesGeral.mMensagem[1, 582].ToString().ToUpper();
				}
				((BlockReference)val6).Position = pt;
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				val6.GenerateLayout();
				val5.AppendEntity((Entity)(object)val6);
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				val6.RecomputeTableBlock(true);
				((DBObject)val6).UpgradeOpen();
				Extents3d value = ((Drawable)val6).Bounds.Value;
				Point3d val7 = value.MinPoint;
				double y = val7.Y;
				value = ((Drawable)val6).Bounds.Value;
				val7 = value.MinPoint;
				double x = val7.X;
				DBObjectCollection val8 = new DBObjectCollection();
				DeclaracoesGeral.bAnularEventos = true;
				val6.TableStyle = database.Tablestyle;
				DeclaracoesGeral.bAnularEventos = false;
				((Entity)val6).Explode(val8);
				((DBObject)val6).Erase();
				foreach (Entity item in val8)
				{
					Entity ent = item;
					MText val9 = (MText)(object)((ent is MText) ? ent : null);
					if (val9 != null && Operators.CompareString(val9.Text, "#B#", TextCompare: true) != 0)
					{
						((Entity)val9).Layer = DeclaracoesGeral.ativo.Pagina;
						val5.AppendEntity((Entity)(object)val9);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val9, true);
						Entity ent2 = (Entity)(object)val9;
						XDataLayout.GravarXDataTabLayout(ref ent2, iPainel);
						val9 = (MText)ent2;
					}
					Line val10 = (Line)(object)((ent is Line) ? ent : null);
					if (val10 != null)
					{
						ent.Layer = DeclaracoesGeral.ativo.Pagina;
						val5.AppendEntity(ent);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)ent, true);
						value = ((Drawable)val10).Bounds.Value;
						val7 = value.MaxPoint;
						if (val7.Y < y)
						{
							value = ((Drawable)val10).Bounds.Value;
							val7 = value.MaxPoint;
							y = val7.Y;
						}
						XDataLayout.GravarXDataTabLayout(ref ent, iPainel);
					}
					((DisposableWrapper)ent).Dispose();
				}
				pt = new Point3d(x, y, 0.0);
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
		return num;
	}

	public static void ApagaTabelaLayout(int iPainel)
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						int painel = 0;
						string tag = "";
						string alternativo = "";
						if (!XDataLayout.lerXDataTABLayout(ref ent, ref painel, ref tag, ref alternativo))
						{
							alternativo = "";
							tag = "";
							if (XDataLayout.LERXDataLinhaLayout(ref ent, ref painel, ref alternativo, ref tag) && painel == iPainel)
							{
								((DBObject)ent).UpgradeOpen();
								((DBObject)ent).Erase();
							}
						}
						else if (iPainel == painel)
						{
							if (Operators.CompareString(DeclaracoesGeral.ativo.Pagina, ent.Layer, TextCompare: true) != 0)
							{
								DeclaracoesGeral.ativo.Pagina = ent.Layer;
								Pagina.AtivaPagina(DeclaracoesGeral.ativo.Pagina);
								DeclaracoesGeral._uscPagina.ativaPaginaAtalho(ref DeclaracoesGeral.ativo.Pagina);
							}
							((DBObject)ent).UpgradeOpen();
							((DBObject)ent).Erase();
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

	public static void ApagaTextoDisp(string sHandleDisp)
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						string handle = "";
						int painel = 0;
						string tag = "";
						if (!XDataLayout.lerXDataTextoLayout(ref ent, ref painel, ref tag, ref handle))
						{
							painel = 0;
							tag = "";
							if (XDataLayout.LERXDataLinhaLayout(ref ent, ref painel, ref tag, ref handle) && Operators.CompareString(handle, sHandleDisp, TextCompare: true) == 0)
							{
								((DBObject)ent).UpgradeOpen();
								((DBObject)ent).Erase();
							}
						}
						else if (Operators.CompareString(handle, sHandleDisp, TextCompare: true) == 0)
						{
							((DBObject)ent).UpgradeOpen();
							((DBObject)ent).Erase();
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

	public static void ApagaRetanguloDisp(int ipainel)
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
						Entity ENT = (Entity)val2.GetObject(current, (OpenMode)1);
						int painel = 0;
						string tag = "";
						string sHandle = "";
						if (XDataLayout.LERXDataLinhaLayout(ref ENT, ref painel, ref tag, ref sHandle) && painel == ipainel)
						{
							((DBObject)ENT).UpgradeOpen();
							((DBObject)ENT).Erase();
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

	public static void LimpaLMPlaquetasDisp(int ipainel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 != null)
						{
							int painel = 0;
							string tag = "";
							string alternativo = "";
							string Handle = "";
							BlockReference blockRef = (BlockReference)val5;
							XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle);
							val5 = (Entity)(object)blockRef;
							if (ipainel == painel)
							{
								((DBObject)val6).UpgradeOpen();
								string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref sHandle, "NUM", "");
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

	public static bool SelecionaBornesParaEdicao(ref StructureDisps[] mNomes)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Expected Obj, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Expected Obj, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected Obj, but got Unknown
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		mNomes = new StructureDisps[1];
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				_ = Application.DocumentManager.MdiActiveDocument;
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				PromptSelectionOptions val2 = new PromptSelectionOptions();
				editor.WriteMessage(Conversions.ToString(Operators.ConcatenateObject("\n", DeclaracoesGeral.mMensagem[1, 622])));
				val2.Keywords.GetDisplayString(true);
				PromptSelectionResult selection = editor.GetSelection(val2);
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val3 = database.TransactionManager.StartTransaction();
				try
				{
					if (!Information.IsNothing(selection.Value))
					{
						SelectionSet value = selection.Value;
						ObjectIdCollection val4 = new ObjectIdCollection(value.GetObjectIds());
						Application.DoEvents();
						Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
						int painel = default;
						foreach (object item in val4)
						{
							ObjectId val5 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity val6 = (Entity)val5.GetObject((OpenMode)0);
							if (Operators.CompareString(val6.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)(object)((val6 is BlockReference) ? val6 : null);
							if (blockRef != null)
							{
								string tag = "";
								string alternativo = "";
								string Handle = "";
								if (XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle))
								{
									num++;
									mNomes = (StructureDisps[])Utils.CopyArray(mNomes, new StructureDisps[num + 1]);
									mNomes[num].nome = tag;
									ref StructureDisps reference = ref mNomes[num];
									Point3d position = blockRef.Position;
									reference.X = Math.Round(position.X, 2);
									ref StructureDisps reference2 = ref mNomes[num];
									position = blockRef.Position;
									reference2.Y = Math.Round(position.Y, 2);
									mNomes[num].Handle = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString();
									result = true;
								}
							}
						}
					}
					StructureDisps structureDisps = default;
					if (Information.UBound(mNomes) > 0)
					{
						int num2 = Information.UBound(mNomes);
						for (int i = 1; i <= num2; i++)
						{
							int num3 = Information.UBound(mNomes) - 1;
							int num4 = i;
							for (int j = num3; j >= num4; j += -1)
							{
								if (mNomes[j].Y < mNomes[j + 1].Y)
								{
									structureDisps = mNomes[j + 1];
									mNomes[j + 1] = mNomes[j];
									mNomes[j] = structureDisps;
								}
								if (mNomes[j].Y == mNomes[j + 1].Y && mNomes[j].X > mNomes[j + 1].X)
								{
									structureDisps = mNomes[j + 1];
									mNomes[j + 1] = mNomes[j];
									mNomes[j] = structureDisps;
								}
							}
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val3.Commit();
					DeclaracoesGeral.bAnularEventos = false;
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
				((IDisposable)val)?.Dispose();
			}
			return result;
		}
	}

	public static bool AdicionaOTexto(ref Point3d pt, ref StructureDisps[] mNomes, int iPainel)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected Obj, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				DBText val4 = null;
				StructureDisps[] array = mNomes;
				for (int i = 0; i < array.Length; i = checked(i + 1))
				{
					StructureDisps structureDisps = array[i];
					if (!Information.IsNothing(structureDisps.nome))
					{
						Point3d pt2 = pt;
						string sTipoHV = "H";
						ObjectId val5 = clsTextos.CriarUmTextoSimples(pt2, ref sTipoHV, structureDisps.nome);
						if (val5.IsValid)
						{
							val4 = (DBText)val2.GetObject(val5, (OpenMode)1);
							Entity ent = (Entity)(object)val4;
							XDataLayout.GravarXDataNomeLayout(ref ent, iPainel, structureDisps.nome, structureDisps.Handle);
							val4 = (DBText)ent;
							pt = new Point3d(pt.X, pt.Y - 1.8, 0.0);
						}
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

	public static void ApagaOsTextosAntigos(ref StructureDisps[] mNomes, int iPainel)
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						int painel = 0;
						string handle = "";
						string tag = "";
						if (!XDataLayout.lerXDataTextoLayout(ref ent, ref painel, ref tag, ref handle))
						{
							continue;
						}
						StructureDisps[] array = mNomes;
						for (int i = 0; i < array.Length; i = checked(i + 1))
						{
							StructureDisps structureDisps = array[i];
							if ((painel == iPainel) & (Operators.CompareString(handle, structureDisps.Handle, TextCompare: true) == 0))
							{
								((DBObject)ent).UpgradeOpen();
								((DBObject)ent).Erase();
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

	public static void AtualizaETQDasReguas(int iPainelSel, string sETQ, string sDisp, bool bLiga, bool bPlaquetas, bool bNumeros, bool bIncluirRetangulo, double bTamanho)
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
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		string sHandle = "";
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
					int painel = 0;
					string regua = "";
					string borne = "";
					int tipoBorne = 0;
					DBText Text = (DBText)(object)((val4 is DBText) ? val4 : null);
					if (Text != null && XDataLayout.lerXDataBorneLayoutMat(ref Text, ref painel, ref regua, ref borne, ref tipoBorne) && ((iPainelSel == painel) & (Operators.CompareString(sDisp, regua, TextCompare: true) == 0)) && tipoBorne == 3)
					{
						if (Operators.CompareString(sETQ, "#B#", TextCompare: true) == 0)
						{
							sETQ = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						}
						clsTextos.AtualizarTexto(Text, sETQ);
						sHandle = ((object)((DBObject)Text).Handle/*cast due to constrained. prefix*/).ToString();
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
			Application.DocumentManager.MdiActiveDocument.Editor.UpdateScreen();
			if (bIncluirRetangulo)
			{
				CriaRetanguloNoTexto(ref sHandle, iPainelSel, sDisp, bTamanho);
			}
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
	}

	public static void CriaRetanguloNoTexto(ref string sHandle, int iPainelSel, string sDisp, double dTamanho)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected Obj, but got Unknown
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val5 = (Entity)Geral.HandleToObject(sHandle);
				DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
				if (val6 != null)
				{
					double num5 = val6.Height * dTamanho;
					Extents3d value = ((Drawable)val6).Bounds.Value;
					Point3d val7 = value.MinPoint;
					num = val7.X - num5;
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MinPoint;
					num2 = val7.Y - num5;
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MaxPoint;
					num3 = val7.X + num5;
					value = ((Drawable)val6).Bounds.Value;
					val7 = value.MaxPoint;
					num4 = val7.Y + num5;
					Point2d val8 = default;
					Point2d val9 = default;
					Point2d val10 = default;
					Point2d val11 = default;
					val8 = new Point2d(num, num2);
					val9 = new Point2d(num, num4);
					val10 = new Point2d(num3, num4);
					val11 = new Point2d(num3, num2);
					Polyline val12 = new Polyline(4);
					val12.Normal = val12.Normal;
					val12.AddVertexAt(0, val8, 0.0, 0.0, 0.0);
					val12.AddVertexAt(1, val9, 0.0, 0.0, 0.0);
					val12.AddVertexAt(2, val10, 0.0, 0.0, 0.0);
					val12.AddVertexAt(3, val11, 0.0, 0.0, 0.0);
					val12.Closed = true;
					((Entity)val12).Layer = ((Entity)val6).Layer;
					((DBObject)val4).UpgradeOpen();
					val4.AppendEntity((Entity)(object)val12);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val12, true);
					XDataLayout.GravarXDataLinhaPlaqueta(val12, iPainelSel, sDisp, sHandle);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void CriaRetanguloNoAtributo(ref string sHandle, double dTamanho)
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected Obj, but got Unknown
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Obj, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				string layer = "0";
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val5 = (Entity)Geral.HandleToObject(sHandle);
				int painel = 0;
				string tag = "";
				string alternativo = "";
				string Handle = "";
				BlockReference blockRef = (BlockReference)val5;
				bool flag = XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle);
				val5 = (Entity)(object)blockRef;
				if (flag)
				{
					if (val5 != null)
					{
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						layer = ((Entity)val6).Layer;
						AttributeCollection attributeCollection = val6.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)0);
							if (Operators.CompareString(val8.Tag.ToUpper(), "NUM", TextCompare: true) == 0)
							{
								double num5 = ((DBText)val8).Height * dTamanho;
								Extents3d value = ((Drawable)val8).Bounds.Value;
								Point3d val9 = value.MinPoint;
								num = val9.X - num5;
								value = ((Drawable)val8).Bounds.Value;
								val9 = value.MinPoint;
								num2 = val9.Y - num5;
								value = ((Drawable)val8).Bounds.Value;
								val9 = value.MaxPoint;
								num3 = val9.X + num5;
								value = ((Drawable)val8).Bounds.Value;
								val9 = value.MaxPoint;
								num4 = val9.Y + num5;
								break;
							}
						}
					}
					Point2d val10 = default;
					Point2d val11 = default;
					Point2d val12 = default;
					Point2d val13 = default;
					val10 = new Point2d(num, num2);
					val11 = new Point2d(num, num4);
					val12 = new Point2d(num3, num4);
					val13 = new Point2d(num3, num2);
					Polyline val14 = new Polyline(4);
					val14.Normal = val14.Normal;
					val14.AddVertexAt(0, val10, 0.0, 0.0, 0.0);
					val14.AddVertexAt(1, val11, 0.0, 0.0, 0.0);
					val14.AddVertexAt(2, val12, 0.0, 0.0, 0.0);
					val14.AddVertexAt(3, val13, 0.0, 0.0, 0.0);
					val14.Closed = true;
					((Entity)val14).Layer = layer;
					((DBObject)val4).UpgradeOpen();
					val4.AppendEntity((Entity)(object)val14);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val14, true);
					XDataLayout.GravarXDataLinhaPlaqueta(val14, painel, tag, sHandle);
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static bool CarregaPlaquetasDoPainel(ref StructurePlaquetasPainel[] _mPlaquetasPainel, int iPainel)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		bool result = false;
		int num = 0;
		_mPlaquetasPainel = new StructurePlaquetasPainel[1];
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
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
							string sDisp = "";
							string sEti = "";
							int iPN = 0;
							MText val5 = (MText)(object)((Ent is MText) ? Ent : null);
							try
							{
								if (val5 == null || !XDataRelatorio.LerXDataPlaquetas(ref Ent, ref sEti, ref sDisp, ref iPN) || iPainel != iPN)
								{
									continue;
								}
								string expression = Conversions.ToString(0);
								if (!Versioned.IsNumeric(val5.Text))
								{
									expression = Strings.Mid(val5.Text, 2, Strings.Len(val5.Text));
								}
								if (!((Operators.CompareString(Strings.Mid(val5.Text, 1, 1), "E", TextCompare: true) == 0) & Versioned.IsNumeric(expression)))
								{
									if (Operators.CompareString(val5.Text, sDisp, TextCompare: true) != 0)
									{
										continue;
									}
									bool flag = true;
									int num2 = Information.UBound(_mPlaquetasPainel);
									for (int i = 1; i <= num2; i++)
									{
										if ((Conversions.ToDouble(_mPlaquetasPainel[i].Painel) == (double)iPN) & (Operators.CompareString(_mPlaquetasPainel[i].Disp, sDisp, TextCompare: true) == 0))
										{
											flag = false;
										}
									}
									if (flag)
									{
										num++;
										_mPlaquetasPainel = (StructurePlaquetasPainel[])Utils.CopyArray(_mPlaquetasPainel, new StructurePlaquetasPainel[num + 1]);
										_mPlaquetasPainel[num].indice_OrdemPL = num;
										_mPlaquetasPainel[num].Painel = Conversions.ToString(iPN);
										_mPlaquetasPainel[num].Disp = sDisp;
										_mPlaquetasPainel[num].Etiq = sEti;
									}
									result = true;
									continue;
								}
								if (Operators.CompareString(val5.Text, sEti, TextCompare: true) != 0)
								{
									continue;
								}
								bool flag2 = true;
								int num3 = Information.UBound(_mPlaquetasPainel);
								for (int j = 1; j <= num3; j++)
								{
									if ((Conversions.ToDouble(_mPlaquetasPainel[j].Painel) == (double)iPN) & (Operators.CompareString(_mPlaquetasPainel[j].Disp, sDisp, TextCompare: true) == 0) & (Operators.CompareString(_mPlaquetasPainel[j].Etiq, sEti, TextCompare: true) == 0))
									{
										flag2 = false;
									}
								}
								if (flag2)
								{
									num++;
									_mPlaquetasPainel = (StructurePlaquetasPainel[])Utils.CopyArray(_mPlaquetasPainel, new StructurePlaquetasPainel[num + 1]);
									_mPlaquetasPainel[num].indice_OrdemPL = num;
									_mPlaquetasPainel[num].Painel = Conversions.ToString(iPN);
									_mPlaquetasPainel[num].Disp = sDisp;
									_mPlaquetasPainel[num].Etiq = sEti;
								}
								result = true;
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
	}

	public static void CarregaLmDoPainel(ref StructureLmPainel[] _mLmPainel, int iPainel)
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
		int num = 0;
		_mLmPainel = new StructureLmPainel[1];
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
							Entity Ent = (Entity)val2.GetObject(current, (OpenMode)1);
							bool flag = false;
							int iIndice = 0;
							int iPN = 0;
							string[] sDisps = null;
							if (!XDataRelatorio.LerDispsXDataMateriais(ref Ent, ref iIndice, ref iPN, ref sDisps) || iPainel != iPN)
							{
								continue;
							}
							string[] array = sDisps;
							foreach (string text in array)
							{
								flag = false;
								int num2 = Information.UBound(_mLmPainel);
								for (int j = 1; j <= num2; j++)
								{
									if ((Conversions.ToDouble(_mLmPainel[j].Painel) == (double)iPN) & (Operators.CompareString(_mLmPainel[j].Disp.Trim(), text.Trim(), TextCompare: true) == 0))
									{
										flag = true;
										break;
									}
								}
								if (!flag)
								{
									num++;
									_mLmPainel = (StructureLmPainel[])Utils.CopyArray(_mLmPainel, new StructureLmPainel[num + 1]);
									_mLmPainel[num].indice_OrdemLM = iIndice;
									_mLmPainel[num].Painel = Conversions.ToString(iPN);
									_mLmPainel[num].Disp = text.Trim();
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
	}

	public static void pesquisaPlaquetasDesenho(ref StructurePlaquetas[] mPlaquetasRel, int painelSel, bool bAlternativo)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected Obj, but got Unknown
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
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
					List<string> list = new List<string>();
					int num2 = 100000;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						int tipoBorne = default;
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
							BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
							if (blockRef == null)
							{
								continue;
							}
							int painel = 0;
							string tag = "";
							string alternativo = "";
							string Handle = "";
							Point3d position;
							if (!XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle))
							{
								int painel2 = 0;
								string regua = "";
								string borne = "";
								Entity ent = (Entity)(object)blockRef;
								bool flag = XDataLayout.lerXDataBorneLayout(ref ent, ref painel2, ref regua, ref borne, ref tipoBorne);
								blockRef = (BlockReference)ent;
								if (flag && !list.Contains(regua) && painelSel == painel2)
								{
									num++;
									mPlaquetasRel = (StructurePlaquetas[])Utils.CopyArray(mPlaquetasRel, new StructurePlaquetas[num + 1]);
									mPlaquetasRel[num].indice_OrdemPL = num;
									mPlaquetasRel[num].Painel = Conversions.ToString(painelSel);
									mPlaquetasRel[num].Disp = regua;
									mPlaquetasRel[num].Etiq = "";
									mPlaquetasRel[num].iTipo = 2;
									mPlaquetasRel[num].dPG = Pagina.calculaPaginaDecimal(((Entity)blockRef).Layer);
									ref StructurePlaquetas reference = ref mPlaquetasRel[num];
									position = blockRef.Position;
									reference.dX = position.X;
									ref StructurePlaquetas reference2 = ref mPlaquetasRel[num];
									position = blockRef.Position;
									reference2.dY = position.Y;
									mPlaquetasRel[num].indice_OrdemPL = num2 + 1000;
									mPlaquetasRel[num].indice_OrdemLM = num2 + 1000;
									mPlaquetasRel[num].indice_OrdemLAY = num2 + 1000;
									num2++;
									list.Add(regua);
								}
							}
							else if (painelSel == painel)
							{
								if (bAlternativo && Operators.CompareString(clsTextos.TiraNothing(alternativo), "", TextCompare: true) != 0)
								{
									tag = alternativo;
								}
								num++;
								mPlaquetasRel = (StructurePlaquetas[])Utils.CopyArray(mPlaquetasRel, new StructurePlaquetas[num + 1]);
								mPlaquetasRel[num].indice_OrdemPL = num;
								mPlaquetasRel[num].Painel = Conversions.ToString(painel);
								mPlaquetasRel[num].Disp = tag;
								mPlaquetasRel[num].Etiq = "";
								mPlaquetasRel[num].iTipo = 1;
								mPlaquetasRel[num].dPG = Pagina.calculaPaginaDecimal(((Entity)blockRef).Layer);
								ref StructurePlaquetas reference3 = ref mPlaquetasRel[num];
								position = blockRef.Position;
								reference3.dX = position.X;
								ref StructurePlaquetas reference4 = ref mPlaquetasRel[num];
								position = blockRef.Position;
								reference4.dY = position.Y;
								mPlaquetasRel[num].indice_OrdemPL = num2;
								mPlaquetasRel[num].indice_OrdemLM = num2;
								mPlaquetasRel[num].indice_OrdemLAY = num2;
								num2++;
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

	public static bool ExistePlaquetaLM(int iPainel)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		bool result = false;
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
						if (XDataRelatorio.LerXDataMateriais(ref Ent, ref iIndice, ref iPainel))
						{
							result = true;
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

	public static bool TemPlaquetas(int iPainel)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected Obj, but got Unknown
		bool result = false;
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
						string sDisp = "";
						int iPN = 0;
						string sEti = "";
						if (XDataRelatorio.LerXDataPlaquetas(ref Ent, ref sEti, ref sDisp, ref iPN) && iPainel == iPN)
						{
							result = true;
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

	public static void atualizaNomesAuternativoDispositivos(int painel, ref DeclaracoesFiacao.structureVF[] mDisp, bool bAlternativo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (blockRef == null)
						{
							continue;
						}
						int painel2 = 0;
						string tag = "";
						string alternativo = "";
						string Handle = "";
						if (!XDataLayout.lerXDataDispLayout(ref blockRef, ref painel2, ref tag, ref alternativo, ref Handle) || Operators.CompareString(Handle, "", TextCompare: true) == 0 || painel != painel2)
						{
							continue;
						}
						DeclaracoesFiacao.structureVF[] array = mDisp;
						for (int i = 0; i < array.Length; i = checked(i + 1))
						{
							DeclaracoesFiacao.structureVF structureVF = array[i];
							if (structureVF.Handle == null || Operators.CompareString(Handle, structureVF.Handle, TextCompare: true) != 0)
							{
								continue;
							}
							((DBObject)blockRef).UpgradeOpen();
							foreach (object item in blockRef.AttributeCollection)
							{
								ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
								string left = val7.Tag.ToUpper();
								if (Operators.CompareString(left, "NOME1", TextCompare: true) == 0)
								{
									((DBText)val7).TextString = structureVF.Tag;
									if (bAlternativo && Operators.CompareString(structureVF.Alternativo, "", TextCompare: true) != 0)
									{
										((DBText)val7).TextString = structureVF.Alternativo;
									}
								}
							}
							XDataLayout.GravarXDataDispLayout(ref blockRef, painel, structureVF.Tag, alternativo, "", Handle);
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

	public static void MarcaDispositivosUsados(DataGridView dgDisp, ref DeclaracoesFiacao.structureVF[] mDisp, int iPainel)
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected Obj, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected Obj, but got Unknown
		DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
		DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
		checked
		{
			try
			{
				dataGridViewCellStyle.BackColor = Color.LightCoral;
				dataGridViewCellStyle2.BackColor = Color.LightGreen;
				int num = dgDisp.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					int num2 = 0;
					do
					{
						dgDisp.Rows[i].Cells[num2].Style = dataGridViewCellStyle2;
						num2++;
					}
					while (num2 <= 1);
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
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)current.GetObject((OpenMode)0);
								BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (blockRef == null)
								{
									continue;
								}
								int painel = 0;
								string tag = "";
								string alternativo = "";
								string Handle = "";
								if (!XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle) || painel != iPainel)
								{
									continue;
								}
								int num3 = dgDisp.Rows.Count - 1;
								for (int j = 0; j <= num3; j++)
								{
									if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(dgDisp.Rows[j].Cells[12].Value, Handle, TextCompare: true), Operators.CompareString(Handle, "", TextCompare: true) != 0)))
									{
										if (Operators.ConditionalCompareObjectEqual(dgDisp.Rows[j].Cells[0].Value, tag, TextCompare: true))
										{
											int num4 = 0;
											do
											{
												dgDisp.Rows[j].Cells[num4].Style = dataGridViewCellStyle;
												num4++;
											}
											while (num4 <= 7);
										}
									}
									else
									{
										int num5 = 0;
										do
										{
											dgDisp.Rows[j].Cells[num5].Style = dataGridViewCellStyle;
											num5++;
										}
										while (num5 <= 1);
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
				ProjectData.ClearProjectError();
			}
			finally
			{
			}
		}
	}

	public static void EditaPlaquetasLayoutMec(ref List<string> listHandle, StructurePlaquetasPainel[] _mPlaquetasPainel, int iPainel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected Obj, but got Unknown
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected Obj, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				bool flag = false;
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val4.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (blockRef != null)
						{
							int painel = 0;
							string tag = "";
							string alternativo = "";
							string Handle = "";
							if (XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle))
							{
								int num = Information.UBound(_mPlaquetasPainel);
								for (int i = 1; i <= num; i = checked(i + 1))
								{
									if ((iPainel == painel) & (Operators.CompareString(tag, _mPlaquetasPainel[i].Disp, TextCompare: true) == 0))
									{
										((DBObject)blockRef).UpgradeOpen();
										foreach (object item in blockRef.AttributeCollection)
										{
											ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
											AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
											string left = val7.Tag.ToUpper();
											if (Operators.CompareString(left, "NUM", TextCompare: true) == 0)
											{
												((DBText)val7).TextString = _mPlaquetasPainel[i].Etiq;
												((Entity)val7).Visible = true;
												flag = true;
												listHandle.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
											}
										}
										if (flag)
										{
											break;
										}
									}
									if (flag)
									{
										break;
									}
								}
							}
						}
						flag = false;
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

	public static void EditaLmLayoutMec(ref List<string> listHandle, StructureLmPainel[] _mLmPainel, int iPainel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected Obj, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
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
						Entity val5 = (Entity)current.GetObject((OpenMode)0);
						BlockReference blockRef = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (blockRef == null)
						{
							continue;
						}
						int painel = 0;
						string tag = "";
						string alternativo = "";
						string Handle = "";
						if (!XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle))
						{
							continue;
						}
						int num = Information.UBound(_mLmPainel);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (!((iPainel == painel) & (Operators.CompareString(tag, _mLmPainel[i].Disp, TextCompare: true) == 0)))
							{
								continue;
							}
							((DBObject)blockRef).UpgradeOpen();
							foreach (object item in blockRef.AttributeCollection)
							{
								ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
								AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
								string left = val7.Tag.ToUpper();
								if (Operators.CompareString(left, "NUM", TextCompare: true) == 0)
								{
									((DBText)val7).TextString = Conversions.ToString(_mLmPainel[i].indice_OrdemLM);
									((Entity)val7).Visible = true;
									listHandle.Add(((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString());
									break;
								}
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
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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

	public static void AtualizaNOMEDoBloco(int iPainelSel, bool bNomeVisivel)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)1);
						BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
						if (val6 != null)
						{
							int painel = 0;
							string tag = "";
							string alternativo = "";
							string Handle = "";
							BlockReference blockRef = (BlockReference)val5;
							XDataLayout.lerXDataDispLayout(ref blockRef, ref painel, ref tag, ref alternativo, ref Handle);
							val5 = (Entity)(object)blockRef;
							if (iPainelSel == painel)
							{
								((DBObject)val6).UpgradeOpen();
								string sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtributoVisivelInvidivel(ref sHandle, "NOME1", bNomeVisivel);
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

	public static void AtualizaOsTextosAntigos()
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
						Entity ent = (Entity)val2.GetObject(current, (OpenMode)1);
						int painel = 0;
						string handle = "";
						string tag = "";
						if (XDataLayout.lerXDataTextoLayout(ref ent, ref painel, ref tag, ref handle) && Operators.CompareString(handle, "", TextCompare: true) != 0)
						{
							DBText val5 = (DBText)(object)((ent is DBText) ? ent : null);
							if (val5 != null)
							{
								((DBObject)val5).UpgradeOpen();
								val5.TextString = Conversions.ToString(BuscaNoomedoBloco(ref handle));
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

	public static object BuscaNoomedoBloco(ref string sHandle)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		string result = "";
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(sHandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					AttributeCollection attributeCollection = val5.AttributeCollection;
					foreach (object item in attributeCollection)
					{
						ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
						AttributeReference val7 = (AttributeReference)val6.GetObject((OpenMode)1);
						if (Operators.CompareString(val7.Tag.ToUpper(), "NOME1", TextCompare: true) == 0)
						{
							result = ((DBText)val7).TextString;
							break;
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
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
}

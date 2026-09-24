using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

public class Correcao
{
	public struct mBlocosCores
	{
		public string sNomeBloco;

		public string sATT;

		public string sCor;

		public int iCor;
	}

	public struct CorracaoModelo
	{
		public int iModelo;

		public int iContato;

		public int iContatoNovo;
	}

	public struct CorracaoModeloBL
	{
		public int iModelo;

		public int iContato;

		public int iContatoNovo;

		public string sTipo;

		public string sT1;

		public string sT2;

		public string sT3;
	}

	public struct mBlocos
	{
		public string sNome1;

		public string sBorne;

		public string sNome2;

		public string sAlternativo;

		public int iPainel;

		public string sPainel;

		public int iOrdem;

		public int iTipo;

		public int iPot;

		public string sTipo;

		public string sHandle;

		public bool bPinta;

		public string sBloco;

		public string sPagina;
	}

	[CommandMethod("CorrigeStyle")]
	public static void corrigeStyles()
	{
		corrigeTextStyles();
	}

	public static bool corrigeTextStyles()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected Obj, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected Obj, but got Unknown
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected Obj, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Expected Obj, but got Unknown
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		bool result = true;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				TextStyleTable val3 = (TextStyleTable)val2.GetObject(database.TextStyleTableId, (OpenMode)1, false);
				TextStyleTableRecord val4 = null;
				TextStyleTableRecord val5 = null;
				string text = "";
				int num = 0;
				SymbolTableEnumerator enumerator = default;
				try
				{
					enumerator = ((SymbolTable)val3).GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						val5 = (TextStyleTableRecord)val2.GetObject(current, (OpenMode)1, false);
						if ((Operators.CompareString(val5.FileName, "", TextCompare: true) == 0) | (val5.XScale == 0.0))
						{
							text = ((SymbolTableRecord)val5).Name + "\r\n";
							num = checked(num + 1);
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				SymbolTableEnumerator enumerator2 = default;
				try
				{
					enumerator2 = ((SymbolTable)val3).GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ObjectId current2 = enumerator2.Current;
						val5 = (TextStyleTableRecord)val2.GetObject(current2, (OpenMode)1, false);
						if (Operators.CompareString(val5.FileName, "arial.ttf", TextCompare: true) == 0)
						{
							break;
						}
					}
				}
				finally
				{
					((IDisposable)enumerator2)?.Dispose();
				}
				if (num != 0)
				{
					if (num == 1)
					{
						text = "Problema com a Fontes: \r\n" + text + "Deseja corrigir?";
					}
					if (num > 1)
					{
						text = "Problemas com as Fontes: \r\n" + text + "Deseja corrigir?";
					}
					MsgBoxResult msgBoxResult = Interaction.MsgBox(text, MsgBoxStyle.YesNo, "Elétron");
					if (msgBoxResult != MsgBoxResult.No)
					{
						SymbolTableEnumerator enumerator3 = default;
						try
						{
							enumerator3 = ((SymbolTable)val3).GetEnumerator();
							SymbolTableEnumerator enumerator4 = default;
							while (enumerator3.MoveNext())
							{
								ObjectId current3 = enumerator3.Current;
								val4 = (TextStyleTableRecord)val2.GetObject(current3, (OpenMode)0, false);
								try
								{
									enumerator4 = ((SymbolTable)val3).GetEnumerator();
									while (enumerator4.MoveNext())
									{
										_ = enumerator4.Current;
										val4 = (TextStyleTableRecord)val2.GetObject(current3, (OpenMode)1, false);
										if (Operators.CompareString(val4.FileName, "", TextCompare: true) == 0)
										{
											((DBObject)val4).UpgradeOpen();
											val4.Font = val5.Font;
											if (!(val5.XScale > 0.0))
											{
												val4.XScale = 1.0;
											}
											else
											{
												val4.XScale = val5.XScale;
											}
											val4.TextSize = val5.TextSize;
										}
										if (val5.XScale == 0.0)
										{
											((DBObject)val4).UpgradeOpen();
											val4.XScale = 1.0;
										}
									}
								}
								finally
								{
									((IDisposable)enumerator4)?.Dispose();
								}
							}
						}
						finally
						{
							((IDisposable)enumerator3)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					else
					{
						result = false;
					}
				}
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

	[CommandMethod("CorrigeDisp")]
	public static void CorrecaoDisp()
	{
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected Obj, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					RegAppTable val4 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
					if (((SymbolTable)val4).Has("DISPOSITIVO"))
					{
						RegAppTableRecord val5 = (RegAppTableRecord)val2.GetObject(((SymbolTable)val4)["DISPOSITIVO"], (OpenMode)1);
						((SymbolTableRecord)val5).Name = "Dispositivo";
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					val2.Abort();
					throw;
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

	[CommandMethod("CorrigeBornes")]
	public static void CorrecaoBornesVisiveis()
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected Obj, but got Unknown
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
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected Obj, but got Unknown
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
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = default;
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							if (structureBorne.Visivel == -1)
							{
								structureBorne.Visivel = 0;
								blockRef = (BlockReference)ent;
								XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
								ent = (Entity)(object)blockRef;
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void correcaoTextosCircuitos()
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Obj, but got Unknown
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
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
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
					int potencial = default;
					int enderecamento = default;
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						DBText text = (DBText)(object)((val5 is DBText) ? val5 : null);
						if (text == null)
						{
							continue;
						}
						string handle = "";
						if (XDataConexao.lerXDataAuxCircuito(ref text, ref potencial, ref handle, ref enderecamento, ref tipo) && tipo == 1)
						{
							((DBObject)text).UpgradeOpen();
							if ((int)text.VerticalMode == 1)
							{
								Point3d alignmentPoint = text.AlignmentPoint;
								text.VerticalMode = (TextVerticalMode)0;
								text.Position = alignmentPoint;
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	public static void correcaoLines()
	{
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected Obj, but got Unknown
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
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Line val6 = (Line)(object)((val5 is Line) ? val5 : null);
						if (val6 == null)
						{
							continue;
						}
						DeclaracoesEntidades.StructureConexao structureConexao = default;
						Entity ent = (Entity)(object)val6;
						bool flag = XDataGeral.TemXData(ref ent, "CONEXAO");
						val6 = (Line)ent;
						if (!flag)
						{
							ent = (Entity)(object)val6;
							flag = XDataGeral.TemXData(ref ent, "INTERLIGACAO");
							val6 = (Line)ent;
							if (flag)
							{
								LimpaXData((Entity)(object)val6, "INTERLIGACAO");
							}
						}
						else
						{
							LimpaXData((Entity)(object)val6, "CONEXAO");
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("ApagaLayouts")]
	public static void ApagaLayouts()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
			if (val2.Contains("CENG_LAYOUT"))
			{
				DBDictionary val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_LAYOUT"), (OpenMode)1);
				((DBObject)val3).Erase();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
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
	}

	[CommandMethod("ApagaPlaquetas")]
	public static void ApagaPlaquetas()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			DBDictionary val2 = (DBDictionary)val.GetObject(database.NamedObjectsDictionaryId, (OpenMode)0, false);
			if (val2.Contains("CENG_PLAQUETA"))
			{
				DBDictionary val3 = (DBDictionary)val.GetObject(val2.GetAt("CENG_PLAQUETA"), (OpenMode)1);
				((DBObject)val3).Erase();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
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
	}

	[CommandMethod("CorrigeContatosAux")]
	public static void CorrigeContatos()
	{
		CorrigeContatosAux();
	}

	public static void CorrigeContatosAux(int indexModelo = 0)
	{
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected Obj, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected Obj, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					object[,] array = new object[4, 1];
					int num = 0;
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
								Entity ent = (Entity)(object)val6;
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								val6 = (BlockReference)ent;
								if (Operators.CompareString(left, "A", TextCompare: true) == 0)
								{
									DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref val6);
									structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
									num = Information.UBound(array, 2) + 1;
									array = (object[,])Utils.CopyArray(array, new object[4, num + 1]);
									array[0, num] = structureAuxiliar.HandleBob;
									array[1, num] = structureAuxiliar.IndexModelo;
									array[2, num] = structureAuxiliar.IndexContato;
									array[3, num] = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
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
						enumerator2 = val4.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ObjectId current2 = enumerator2.Current;
							Entity val7 = (Entity)val2.GetObject(current2, (OpenMode)1);
							BlockReference val8 = (BlockReference)(object)((val7 is BlockReference) ? val7 : null);
							if (val8 == null)
							{
								continue;
							}
							Declaracoes2.StructureModelo Modelo = default;
							Entity ent = (Entity)(object)val8;
							bool flag = XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo);
							val8 = (BlockReference)ent;
							if (!flag)
							{
								continue;
							}
							string handleContatoAux = "";
							int num2 = Information.UBound(array, 2);
							for (int i = 1; i <= num2; i++)
							{
								if (Conversions.ToBoolean(Operators.AndObject(Operators.AndObject(Operators.CompareObjectEqual(Modelo.HandleBob, array[0, i], TextCompare: true), Operators.CompareObjectEqual(array[1, i], Modelo.indexModelo, TextCompare: true)), Operators.CompareObjectEqual(array[2, i], Modelo.indexContato, TextCompare: true))))
								{
									handleContatoAux = Conversions.ToString(array[3, i]);
									break;
								}
							}
							Modelo.HandleContatoAux = handleContatoAux;
							XDataDispositivosMaster.GravarXDataDispModelo(ref val8, ref Modelo);
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					clsDispositivoAuxiliares.SincronizaContatos(indexModelo);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("LimpaTextosLPCopiados")]
	public static void LimpaTextosLPCopiados()
	{
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Expected Obj, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Expected Obj, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Expected Obj, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				int num = 0;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					double num2 = -1000.0;
					try
					{
						BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
						BlockTableRecordEnumerator enumerator = default;
						Extents3d value;
						Point3d maxPoint;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
								if (pl == null)
								{
									continue;
								}
								DeclaracoesEntidades.StructureConexao conex = default;
								if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Tipo == 1)
								{
									double num3 = num2;
									value = ((Drawable)pl).Bounds.Value;
									maxPoint = value.MaxPoint;
									if (num3 < Math.Round(maxPoint.Y, 2))
									{
										value = ((Drawable)pl).Bounds.Value;
										maxPoint = value.MaxPoint;
										num2 = Math.Round(maxPoint.Y, 2);
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
							enumerator2 = val4.GetEnumerator();
							while (enumerator2.MoveNext())
							{
								ObjectId current2 = enumerator2.Current;
								Entity val6 = (Entity)val2.GetObject(current2, (OpenMode)0);
								MText val7 = (MText)(object)((val6 is MText) ? val6 : null);
								if (val7 == null)
								{
									DBText val8 = (DBText)(object)((val6 is DBText) ? val6 : null);
									if (val8 != null)
									{
										Entity ent = (Entity)(object)val8;
										bool flag = XDataGeral.TemXData(ref ent, "TextoLP");
										val8 = (DBText)ent;
										if (flag)
										{
											LimpaXData(val6, "TextoLP");
											num++;
										}
									}
									continue;
								}
								value = ((Drawable)val7).Bounds.Value;
								maxPoint = value.MaxPoint;
								if (maxPoint.Y < num2)
								{
									Entity ent = (Entity)(object)val7;
									bool flag = XDataGeral.TemXData(ref ent, "TextoLP");
									val7 = (MText)ent;
									if (flag)
									{
										LimpaXData(val6, "TextoLP");
										num++;
									}
								}
							}
						}
						finally
						{
							((IDisposable)enumerator2)?.Dispose();
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						ProjectData.ClearProjectError();
					}
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
				if (num != 0)
				{
					Interaction.MsgBox(Conversions.ToString(num) + " MTextos Corrigidos", MsgBoxStyle.Information, "Elétron");
				}
				else
				{
					Interaction.MsgBox("O Arquivo não possui MTextos Copiados", MsgBoxStyle.Information, "Elétron");
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
	}

	public static void LimpaXData(Entity Ent, string sNomexData)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected Obj, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected Obj, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected Obj, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected Obj, but got Unknown
		if (Ent == null)
		{
			return;
		}
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)0);
				if (((SymbolTable)val3).Has(sNomexData))
				{
					TypedValue[] array = new TypedValue[1]
					{
						new TypedValue(1001, (object)sNomexData)
					};
					Entity val4 = (Entity)Geral.HandleToObject(((object)((DBObject)Ent).Handle/*cast due to constrained. prefix*/).ToString());
					try
					{
						((DBObject)val4).UpgradeOpen();
						((DBObject)val4).XData = new ResultBuffer(array);
					}
					finally
					{
						((IDisposable)val4)?.Dispose();
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("apagaXDataTerceiros")]
	public static void ApagaXDataTerceiros()
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Expected Obj, but got Unknown
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
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Expected Obj, but got Unknown
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						try
						{
							Entity ent = val5;
							if (XDataGeral.TemXData(ref ent, "AEC_XDATA_BOUND_SPACE"))
							{
								TypedValue[] array = new TypedValue[1]
								{
									new TypedValue(1001, (object)"AEC_XDATA_BOUND_SPACE")
								};
								((DBObject)val5).UpgradeOpen();
								((DBObject)val5).XData = new ResultBuffer(array);
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
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("CorrigeJanelas")]
	public static void corrigeJanelas()
	{
		Geral.moveFormOrigem();
	}

	public static void mostraBloco(string sHandle)
	{
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		clsBlocos.Unhighlight();
		Application.UpdateScreen();
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
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
				try
				{
					if (val4 != null)
					{
						Pagina.AtivaPagina(val4.Layer);
						Caderno.ZEntity(((DBObject)val4).ObjectId, 20);
						val4.Highlight();
					}
				}
				finally
				{
					((IDisposable)val4)?.Dispose();
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.UpdateScreen();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("corrigeDicMascaras")]
	public static void corrigeDicMascaras()
	{
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Expected Obj, but got Unknown
		Declaracoes2.MModeloDeMascara[] mModelo = null;
		Declaracoes2.MModeloDePortas[] mPortas = null;
		Declaracoes2.MModeloDePortas[] array = null;
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: false);
		checked
		{
			try
			{
				int num = Information.UBound(mModelo);
				for (int i = 1; i <= num; i++)
				{
					List<int> list = new List<int>();
					array = new Declaracoes2.MModeloDePortas[1];
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref mModelo[i].iIndiceModelo, mModelo[i].sNomeModelo, ref mPortas);
					int num2 = Information.UBound(mPortas);
					for (int j = 1; j <= num2; j++)
					{
						if (!list.Contains(mPortas[j].IndiceDaPorta))
						{
							int num3 = Information.UBound(array) + 1;
							array = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(array, new Declaracoes2.MModeloDePortas[num3 + 1]);
							array[num3] = mPortas[j];
							list.Add(mPortas[j].IndiceDaPorta);
							if (array[0].MaxIndice < mPortas[j].IndiceDaPorta)
							{
								array[0].MaxIndice = mPortas[j].IndiceDaPorta;
							}
						}
					}
					Declaracoes2.MModeloDePortas mModeloDePortas = default;
					if (Information.UBound(array) > 0)
					{
						int num4 = Information.UBound(array);
						for (int k = 1; k <= num4; k++)
						{
							int num5 = Information.UBound(array) - 1;
							int num6 = k;
							for (int l = num5; l >= num6; l += -1)
							{
								if (array[l].IndiceDaPorta > array[l + 1].IndiceDaPorta)
								{
									mModeloDePortas = array[l + 1];
									array[l + 1] = array[l];
									array[l] = mModeloDePortas;
								}
							}
						}
					}
					DicionarioMascaras.GravaAsPortasDoModeloDoDicionario(mModelo[i].iIndiceModelo, ref array);
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				throw;
			}
			finally
			{
			}
		}
	}

	[CommandMethod("corrigePortas")]
	public static void corrigePortas()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected Obj, but got Unknown
		Declaracoes2.MModeloDeMascara[] mModelo = null;
		Declaracoes2.MModeloDePortas[] array = null;
		Declaracoes2.MModeloDePortas[] mPortas = null;
		int num = 0;
		DicionarioMascaras.LeOsModelosDeMascaras(ref mModelo, bComplementarModelo: false);
		array = new Declaracoes2.MModeloDePortas[1];
		checked
		{
			try
			{
				int num2 = Information.UBound(mModelo);
				for (int i = 1; i <= num2; i++)
				{
					DicionarioMascaras.LeAsPortasDoModeloDoDicionario(ref mModelo[i].iIndiceModelo, mModelo[i].sNomeModelo, ref mPortas);
					int num3 = Information.UBound(mPortas);
					for (int j = 1; j <= num3; j++)
					{
						num++;
						array = (Declaracoes2.MModeloDePortas[])Utils.CopyArray(array, new Declaracoes2.MModeloDePortas[num + 1]);
						array[num] = mPortas[j];
					}
				}
				clsPortas.EditaTodasPortas(array);
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				throw;
			}
			finally
			{
			}
		}
	}

	[CommandMethod("CorrigeCabosSingelos")]
	public static void CorrecaoCabosSingelos()
	{
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Expected Obj, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected Obj, but got Unknown
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		List<string> lVeias = new List<string>();
		List<string> list = new List<string>();
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		cDadosAccessInterligacao3.CorrigeOsCabosSingelos(ref lVeias);
		cDadosAccessInterligacao3.FechaConexao();
		if (lVeias.Count > 0)
		{
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
							Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
							try
							{
								Polyline val6 = (Polyline)(object)((val5 is Polyline) ? val5 : null);
								try
								{
									if (val6 != null)
									{
										DeclaracoesEntidades.StructureInterligacao ilig = default;
										Polyline pl = val6;
										if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && lVeias.Contains(ilig.Tag_Cabo))
										{
											ilig.NomeVeia = "";
											((DBObject)val6).UpgradeOpen();
											pl = val6;
											XDataInterligacao.AtualizaXDataInterligacao(ref pl, ref ilig);
											list.Add(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString());
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
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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
		clsEletrosul.RecriaTextosCaboEletrosul();
	}

	[CommandMethod("CorrigeModelosDeContatos")]
	public static void CorrigeModelosDeTodosContatos()
	{
		CorrigeModelosDeContatos();
	}

	public static void CorrigeModelosDeContatos(int indexModelo = 0)
	{
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected Obj, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Obj, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected Obj, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected Obj, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Expected Obj, but got Unknown
		Declaracoes2.MModelosDeContatos[] array = null;
		array = new Declaracoes2.MModelosDeContatos[1];
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref array);
		int num = 0;
		CorracaoModelo[] array2 = new CorracaoModelo[1];
		bool flag = false;
		int num2 = Information.UBound(array);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				int iMaxIndice = 0;
				Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
				DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref array[i].iIndiceModelo, ref mCONTATOS);
				int num3 = Information.UBound(mCONTATOS);
				for (int j = 1; j <= num3; j++)
				{
					iMaxIndice = j;
					if (mCONTATOS[j].iIndice != j)
					{
						num++;
						array2 = (CorracaoModelo[])Utils.CopyArray(array2, new CorracaoModelo[num + 1]);
						array2[num].iModelo = array[i].iIndiceModelo;
						array2[num].iContato = mCONTATOS[j].iIndice;
						array2[num].iContatoNovo = j;
						mCONTATOS[j].iIndice = j;
						flag = true;
					}
				}
				if (flag)
				{
					DicionarioContatos.GravaOsContatosAuxiliarDoModeloDoDicionario(array[i].iIndiceModelo, ref iMaxIndice, mCONTATOS);
					flag = false;
				}
			}
			if (array2.Count() <= 1)
			{
				return;
			}
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
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 == null)
									{
										continue;
									}
									Entity ent = (Entity)(object)val6;
									string tipoImportado = "";
									if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "A", TextCompare: true) != 0)
									{
										continue;
									}
									DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
									BlockReference blockRef = val6;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
									int num4 = array2.Count() - 1;
									for (int k = 1; k <= num4; k++)
									{
										if (((array2[k].iModelo == structureAuxiliar.IndexModelo) & (array2[k].iContato == structureAuxiliar.IndexContato)) && array2[k].iContato != array2[k].iContatoNovo)
										{
											structureAuxiliar.IndexContato = array2[k].iContatoNovo;
											blockRef = val6;
											XDataDispositivosMaster.GravarXDataDispAuxiliar(ref blockRef, ref structureAuxiliar);
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
					BlockTableRecordEnumerator enumerator2 = default;
					try
					{
						enumerator2 = val4.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							ObjectId current2 = enumerator2.Current;
							Entity val7 = (Entity)val2.GetObject(current2, (OpenMode)1);
							try
							{
								BlockReference val8 = (BlockReference)(object)((val7 is BlockReference) ? val7 : null);
								try
								{
									if (val8 == null)
									{
										continue;
									}
									Declaracoes2.StructureModelo Modelo = default;
									Entity ent = (Entity)(object)val8;
									if (!XDataDispositivosMaster.LerXDataModelo(ref ent, ref Modelo))
									{
										continue;
									}
									int num5 = array2.Count() - 1;
									for (int l = 1; l <= num5; l++)
									{
										if (((array2[l].iModelo == Modelo.indexModelo) & (array2[l].iContato == Modelo.indexContato)) && array2[l].iContato != array2[l].iContatoNovo)
										{
											Modelo.indexContato = array2[l].iContatoNovo;
											BlockReference blockRef = val8;
											XDataDispositivosMaster.GravarXDataDispModelo(ref blockRef, ref Modelo);
											break;
										}
									}
								}
								finally
								{
									((IDisposable)val8)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val7)?.Dispose();
							}
						}
					}
					finally
					{
						((IDisposable)enumerator2)?.Dispose();
					}
					CorrigeContatosAux(indexModelo);
					clsDispositivoAuxiliares.SincronizaContatos(indexModelo, bMarcaErros: false);
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("CorrigeCabos")]
	public static void CorrecaoCabosNothing()
	{
		cDadosAccessInterligacao2 cDadosAccessInterligacao3 = new cDadosAccessInterligacao2();
		cDadosAccessInterligacao3.CorrigeNothing("Funcao");
		cDadosAccessInterligacao3.fechaConexao();
	}

	[CommandMethod("corrigeOrdemBornes")]
	public static void corrigeOrdemBornes()
	{
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		//IL_040f: Expected Obj, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected Obj, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected Obj, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected Obj, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected Obj, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0370: Expected Obj, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c0: Expected Obj, but got Unknown
		DeclaracoesEntidades.StructureBorne[] array = new DeclaracoesEntidades.StructureBorne[1];
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
					DeclaracoesEntidades.StructureBorne structureBorne = default;
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
								Entity ent = val5;
								string tipoImportado = "";
								if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
								{
									BlockReference blockRef = (BlockReference)val5;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
									int num = Information.UBound(array) + 1;
									array = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(array, new DeclaracoesEntidades.StructureBorne[num + 1]);
									array[num] = structureBorne;
									array[num].Handle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
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
					if (Information.UBound(array) >= 2)
					{
						int num2 = Information.UBound(array);
						for (int i = 1; i <= num2; i++)
						{
							int num3 = Information.UBound(array) - 1;
							int num4 = i;
							for (int j = num3; j >= num4; j += -1)
							{
								if (array[j].IndiceRegua > array[j + 1].IndiceRegua)
								{
									structureBorne = array[j + 1];
									array[j + 1] = array[j];
									array[j] = structureBorne;
								}
								if (array[j].IndiceRegua == array[j + 1].IndiceRegua && array[j].Ordem > array[j + 1].Ordem)
								{
									structureBorne = array[j + 1];
									array[j + 1] = array[j];
									array[j] = structureBorne;
								}
							}
						}
					}
					int num5 = -1;
					List<int> lOrdem = new List<int>();
					int k = 1;
					int num6 = Information.UBound(array);
					for (int l = 1; l <= num6; l++)
					{
						if (num5 != array[l].IndiceRegua)
						{
							num5 = array[l].IndiceRegua;
							lOrdem.Clear();
							DicionarioBorne.LeOrdemDicBornesReserva(num5, ref lOrdem);
							k = 1;
						}
						if (array[l].IndiceRegua == num5)
						{
							for (; lOrdem.Contains(k); k++)
							{
							}
							array[l].Ordem = k;
							k++;
						}
					}
					int num7 = Information.UBound(array);
					for (int m = 1; m <= num7; m++)
					{
						Entity val6 = (Entity)Geral.HandleToObject(array[m].Handle);
						try
						{
							if (val6 == null)
							{
								continue;
							}
							Entity ent = val6;
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
							{
								DeclaracoesEntidades.StructureBorne structureBorne2 = default;
								BlockReference blockRef = (BlockReference)val6;
								object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								structureBorne2 = ((obj2 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj2));
								if (structureBorne2.Ordem != array[m].Ordem)
								{
									structureBorne2.Ordem = array[m].Ordem;
									((DBObject)val6).UpgradeOpen();
									blockRef = (BlockReference)val6;
									XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne2);
								}
							}
						}
						finally
						{
							((IDisposable)val6)?.Dispose();
						}
					}
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("apagarTodosOsTextosDasVeias")]
	public static void ApagarTodosOsTextosDasVeias()
	{
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Expected Obj, but got Unknown
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
					short tipo = default;
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						try
						{
							DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
							try
							{
								Entity ent;
								string sHandle;
								if (val6 == null)
								{
									ent = val5;
									sHandle = "";
									if (XDataInterligacao.lerXDataAuxInterligacaoEletrosul(ref ent, ref sHandle))
									{
										((DBObject)val5).UpgradeOpen();
										((DBObject)val5).Erase();
									}
									continue;
								}
								string handle = "";
								string THandle = "";
								ent = (Entity)(object)val6;
								sHandle = "";
								if (XDataInterligacao.lerXDataAuxInterligacao(ref ent, ref handle, ref tipo, ref THandle, ref sHandle) && tipo == 1)
								{
									((DBObject)val6).UpgradeOpen();
									((DBObject)val6).Erase();
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
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("CorrigeBlocosContatosAux")]
	public static void CorrigeBlocosContatosAux()
	{
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_0337: Expected Obj, but got Unknown
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected Obj, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected Obj, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected Obj, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		Declaracoes2.MModelosDeContatos[] array = null;
		array = new Declaracoes2.MModelosDeContatos[1];
		DicionarioContatos.LeOsModelosDeDeDicionarioContatos(ref array);
		int num = 0;
		CorracaoModeloBL[] array2 = new CorracaoModeloBL[1];
		int num2 = Information.UBound(array);
		checked
		{
			for (int i = 1; i <= num2; i++)
			{
				Declaracoes2.StructureContatosAuxiliares[] mCONTATOS = null;
				DicionarioContatos.LeOsContatosAuxiliarDoModeloDoDicionario(ref array[i].iIndiceModelo, ref mCONTATOS);
				int num3 = Information.UBound(mCONTATOS);
				for (int j = 1; j <= num3; j++)
				{
					num++;
					array2 = (CorracaoModeloBL[])Utils.CopyArray(array2, new CorracaoModeloBL[num + 1]);
					array2[num].iModelo = array[i].iIndiceModelo;
					array2[num].iContato = mCONTATOS[j].iIndice;
					array2[num].sTipo = mCONTATOS[j].sTipo;
					array2[num].sT1 = mCONTATOS[j].sT1;
					array2[num].sT2 = mCONTATOS[j].sT2;
					array2[num].sT3 = mCONTATOS[j].sT3;
					array2[num].iContatoNovo = j;
					mCONTATOS[j].iIndice = j;
				}
			}
			if (array2.Count() <= 1)
			{
				return;
			}
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
							try
							{
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								try
								{
									if (val6 == null)
									{
										continue;
									}
									Entity ent = (Entity)(object)val6;
									string tipoImportado = "";
									if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "A", TextCompare: true) != 0)
									{
										continue;
									}
									DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
									BlockReference blockRef = val6;
									object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
									structureAuxiliar = ((obj == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj));
									int num4 = array2.Count() - 1;
									for (int k = 1; k <= num4; k++)
									{
										if ((array2[k].iModelo == structureAuxiliar.IndexModelo) & (array2[k].iContato == structureAuxiliar.IndexContato))
										{
											clsDispositivoAuxiliares.AtualizaOsTerminaisAuxiliares(((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString(), array2[k].sTipo, array2[k].sT1, array2[k].sT2, array2[k].sT3);
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
					CorrigeContatosAux();
					clsDispositivoAuxiliares.SincronizaContatos();
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
				}
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("ApagarTextosEmBranco")]
	public static void ApagarTextosEmBranco()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		int num = 0;
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						try
						{
							DBText val6 = (DBText)(object)((val5 is DBText) ? val5 : null);
							try
							{
								if (val6 != null && Operators.CompareString(val6.TextString.Trim(), "", TextCompare: true) == 0 && ((DBObject)val6).XData == (ResultBuffer)null)
								{
									((DBObject)val6).UpgradeOpen();
									((DBObject)val5).Erase();
									((DBObject)val6).DowngradeOpen();
									num = checked(num + 1);
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
		Interaction.MsgBox(Conversions.ToString(num) + "Textos apagados.");
	}

	[CommandMethod("PesquisaBlocos")]
	public static void PesquisaBlocos()
	{
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) == 0)
		{
			new frmNavegador();
		}
	}

	public static void pesquisaElementosEletronNoDWG(string sNome1, string sNome2, string sAlternativo, bool P, bool A, bool B, bool M, bool E, bool bConexao, bool bCabo, bool bJumper, ref DataGridView dg, ref bool bNome2, ref bool bAlternativo)
	{
		//IL_1efc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f02: Expected Obj, but got Unknown
		//IL_1f2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f30: Expected Obj, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Expected Obj, but got Unknown
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected Obj, but got Unknown
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Expected Obj, but got Unknown
		//IL_085f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0866: Expected Obj, but got Unknown
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4b: Expected Obj, but got Unknown
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0348: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Unknown result type (might be due to invalid IL or missing references)
		//IL_058b: Expected Obj, but got Unknown
		//IL_0a6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a72: Expected Obj, but got Unknown
		//IL_1051: Unknown result type (might be due to invalid IL or missing references)
		//IL_1056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Unknown result type (might be due to invalid IL or missing references)
		//IL_0836: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c50: Expected Obj, but got Unknown
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1a: Unknown result type (might be due to invalid IL or missing references)
		int num = 0;
		mBlocos[] array = new mBlocos[1];
		num = 1;
		bNome2 = false;
		bAlternativo = false;
		DeclaracoesGeral.Reguas RH = default;
		bool flag = false;
		DeclaracoesGeral.Reguas RH2 = default;
		bool flag2 = false;
		flag = XDataGeral.LeXDataReguaH(ref RH);
		flag2 = XDataGeral.LeXDataReguaV(ref RH2);
		checked
		{
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
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						DeclaracoesGeral._uscPagina.Quantidade = clsBlocos.AcadObjectCount();
						DeclaracoesGeral._uscPagina.pbIniciar();
						int num2 = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							DeclaracoesEntidades.StructureDispositivo structureDispositivo = default;
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								try
								{
									BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
									try
									{
										if (val6 == null)
										{
											Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
											if (pl != null)
											{
												DeclaracoesEntidades.StructureConexao conex = default;
												if (!XDataConexao.lerXDataConexao(ref pl, ref conex))
												{
													DeclaracoesEntidades.StructureInterligacao ilig = default;
													if (XDataInterligacao.lerXDataInterligacao(ref pl, ref ilig) && bCabo)
													{
														array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
														array[num].sNome1 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 740]);
														if (Operators.CompareString(ilig.Tag_Cabo, "", TextCompare: true) != 0)
														{
															array[num].sNome1 = ilig.Tag_Cabo;
														}
														array[num].sNome2 = "";
														array[num].sBloco = "Polyline";
														ref mBlocos reference = ref array[num];
														string pagina = val5.Layer.ToString();
														Entity ent = val5;
														reference.sPagina = Pagina.montaCruzamentoPagina(pagina, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
														array[num].sAlternativo = "";
														array[num].iPainel = ilig.Painel1;
														string text = "";
														string text2 = "";
														if (ilig.Painel1 > 0)
														{
															text = Dicionario.BuscaNomeDoPainel(ilig.Painel1);
														}
														if (ilig.Painel2 > 0)
														{
															text2 = Dicionario.BuscaNomeDoPainel(ilig.Painel2);
														}
														if (Operators.CompareString(text, "", TextCompare: true) == 0)
														{
															if (Operators.CompareString(text2, "", TextCompare: true) != 0)
															{
																array[num].sPainel = text2;
															}
														}
														else
														{
															array[num].sPainel = text;
															if (Operators.CompareString(text2, "", TextCompare: true) != 0)
															{
																ref string sPainel = ref array[num].sPainel;
																sPainel = sPainel + " / " + text2;
															}
														}
														array[num].bPinta = false;
														array[num].iOrdem = 2000000;
														array[num].sTipo = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1239]);
														array[num].sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
														num++;
													}
												}
												else
												{
													string text3 = "";
													short tipo = conex.Tipo;
													if (unchecked((uint)(tipo - 1)) <= 2u)
													{
														text3 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 175]);
													}
													else if (tipo == 4)
													{
														text3 = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 703]);
													}
													if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(text3, DeclaracoesGeral.mMensagem[1, 175], TextCompare: true), !bConexao)) && !Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(text3, DeclaracoesGeral.mMensagem[1, 703], TextCompare: true), !bJumper)))
													{
														array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
														array[num].iTipo = conex.Tipo;
														array[num].iPot = conex.Potencial;
														array[num].sNome2 = "";
														array[num].sBloco = "Polyline";
														ref mBlocos reference2 = ref array[num];
														string pagina2 = val5.Layer.ToString();
														Entity ent = val5;
														reference2.sPagina = Pagina.montaCruzamentoPagina(pagina2, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
														array[num].sAlternativo = "";
														array[num].iPainel = conex.Painel;
														array[num].sPainel = Dicionario.BuscaNomeDoPainel(conex.Painel);
														array[num].bPinta = false;
														array[num].iOrdem = 1000000 + conex.Potencial;
														array[num].sNome1 = text3;
														if (Operators.CompareString(conex.Nome, "", TextCompare: true) == 0)
														{
															if (conex.Tipo == 1)
															{
																array[num].sNome1 = "CIRCUITO";
															}
															if (conex.Tipo == 2)
															{
																array[num].sNome1 = "TT";
															}
															if (conex.Tipo == 3)
															{
																array[num].sNome1 = "DERIVAÇÃO";
															}
														}
														else
														{
															array[num].sNome1 = conex.Nome;
															array[num].iTipo = 1;
														}
														array[num].sTipo = text3;
														array[num].sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
														num++;
													}
												}
											}
										}
										else
										{
											Entity ent = val5;
											string tipoImportado = "";
											string text4 = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
											string left = text4;
											if (Operators.CompareString(left, "P", TextCompare: true) != 0)
											{
												if (Operators.CompareString(left, "A", TextCompare: true) != 0)
												{
													if (Operators.CompareString(left, "B", TextCompare: true) != 0)
													{
														if (Operators.CompareString(left, "M", TextCompare: true) != 0)
														{
															if (Operators.CompareString(left, "E", TextCompare: true) != 0)
															{
																if (Operators.CompareString(left, "B", TextCompare: true) == 0)
																{
																}
															}
															else if (E)
															{
																BlockReference blockRef = (BlockReference)val5;
																object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
																Entity val7 = (Entity)Geral.HandleToObject(((obj == null) ? default(DeclaracoesEntidades.StructurePortas) : ((DeclaracoesEntidades.StructurePortas)obj)).HandleDaMascara);
																DeclaracoesEntidades.StructureMascara structureMascara = default;
																if (val7 != null)
																{
																	bool flag3 = false;
																	if (val7 == null)
																	{
																		flag3 = true;
																	}
																	else
																	{
																		blockRef = (BlockReference)val7;
																		object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
																		val7 = (Entity)(object)blockRef;
																		object obj3 = obj2;
																		structureMascara = ((obj3 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj3));
																	}
																	if (LikeOperator.LikeString(structureMascara.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
																	{
																		array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
																		array[num].sNome1 = structureMascara.Nome1;
																		array[num].sNome2 = structureMascara.Nome2;
																		array[num].sBloco = val6.Name;
																		ref mBlocos reference3 = ref array[num];
																		string pagina3 = val5.Layer.ToString();
																		ent = val5;
																		reference3.sPagina = Pagina.montaCruzamentoPagina(pagina3, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
																		array[num].sAlternativo = structureMascara.Alternativo;
																		if (!flag3)
																		{
																			array[num].iPainel = structureMascara.Painel;
																			array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureMascara.Painel);
																			array[num].bPinta = false;
																		}
																		else
																		{
																			array[num].iPainel = 0;
																			array[num].sPainel = "";
																			array[num].bPinta = true;
																		}
																		array[num].iOrdem = 5;
																		array[num].sTipo = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 750]);
																		array[num].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
																		num++;
																	}
																}
															}
														}
														else if (M)
														{
															BlockReference blockRef = (BlockReference)val5;
															object obj4 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
															DeclaracoesEntidades.StructureMascara structureMascara2 = ((obj4 == null) ? default(DeclaracoesEntidades.StructureMascara) : ((DeclaracoesEntidades.StructureMascara)obj4));
															if (LikeOperator.LikeString(structureMascara2.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara2.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureMascara2.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
															{
																array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
																array[num].sNome1 = structureMascara2.Nome1;
																array[num].sNome2 = structureMascara2.Nome2;
																array[num].sBloco = val6.Name;
																ref mBlocos reference4 = ref array[num];
																string pagina4 = val5.Layer.ToString();
																ent = val5;
																reference4.sPagina = Pagina.montaCruzamentoPagina(pagina4, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
																array[num].sAlternativo = structureMascara2.Alternativo;
																array[num].iPainel = structureMascara2.Painel;
																array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureMascara2.Painel);
																array[num].iOrdem = 4;
																if (structureMascara2.Complementar)
																{
																	array[num].sTipo = "Complemantar";
																}
																else
																{
																	array[num].sTipo = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 524]);
																}
																array[num].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
																num++;
															}
														}
													}
													else if (B)
													{
														DeclaracoesEntidades.StructureBorne structureBorne = default;
														BlockReference blockRef = val6;
														object obj5 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
														structureBorne = ((obj5 == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj5));
														short num3 = 0;
														num3 = (short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo);
														string text5 = Dicionario.BuscaNomeDoPainel(num3);
														if (LikeOperator.LikeString(structureBorne.NomeRegua.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureBorne.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
														{
															array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
															string text6 = "";
															string text7 = "";
															int num4 = 6 - Strings.Len(structureBorne.Numero);
															for (int i = 1; i <= num4; i++)
															{
																text7 += "0";
															}
															text6 = text7 + structureBorne.Numero;
															array[num].sNome1 = text5 + "/" + structureBorne.NomeRegua + "-" + text6;
															array[num].sBorne = text5 + "/" + structureBorne.NomeRegua + "-" + structureBorne.Numero;
															array[num].sNome2 = "";
															array[num].sBloco = val6.Name;
															ref mBlocos reference5 = ref array[num];
															string pagina5 = val5.Layer.ToString();
															ent = val5;
															reference5.sPagina = Pagina.montaCruzamentoPagina(pagina5, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
															array[num].sAlternativo = structureBorne.Alternativo;
															array[num].iPainel = num3;
															array[num].sPainel = text5;
															array[num].bPinta = false;
															array[num].iOrdem = 3;
															array[num].sTipo = "Borne";
															array[num].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
															num++;
														}
													}
												}
												else if (A)
												{
													DeclaracoesEntidades.StructureAuxiliar structureAuxiliar = default;
													BlockReference blockRef = val6;
													object obj6 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
													structureAuxiliar = ((obj6 == null) ? default(DeclaracoesEntidades.StructureAuxiliar) : ((DeclaracoesEntidades.StructureAuxiliar)obj6));
													Entity val8 = (Entity)Geral.HandleToObject(structureAuxiliar.HandleBob);
													if (val8 != null)
													{
														bool flag4 = false;
														if (val8 == null)
														{
															flag4 = true;
														}
														else
														{
															blockRef = (BlockReference)val8;
															object obj2 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
															val8 = (Entity)(object)blockRef;
															object obj7 = obj2;
															structureDispositivo = ((obj7 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj7));
														}
														if (LikeOperator.LikeString(structureAuxiliar.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureAuxiliar.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureAuxiliar.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
														{
															array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
															array[num].sNome1 = structureAuxiliar.Nome1;
															array[num].sNome2 = structureAuxiliar.Nome2;
															array[num].sBloco = val6.Name;
															ref mBlocos reference6 = ref array[num];
															string pagina6 = val5.Layer.ToString();
															ent = val5;
															reference6.sPagina = Pagina.montaCruzamentoPagina(pagina6, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
															array[num].sAlternativo = structureAuxiliar.Alternativo;
															if (!flag4)
															{
																array[num].iPainel = structureDispositivo.Painel;
																array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureDispositivo.Painel);
																array[num].bPinta = false;
															}
															else
															{
																array[num].iPainel = 0;
																array[num].sPainel = "";
																array[num].bPinta = true;
															}
															array[num].iOrdem = 2;
															array[num].sTipo = "Auxiliar";
															array[num].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
															num++;
														}
													}
												}
											}
											else if (P)
											{
												DeclaracoesEntidades.StructureDispositivo structureDispositivo2 = default;
												BlockReference blockRef = val6;
												object obj8 = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
												structureDispositivo2 = ((obj8 == null) ? default(DeclaracoesEntidades.StructureDispositivo) : ((DeclaracoesEntidades.StructureDispositivo)obj8));
												if (LikeOperator.LikeString(structureDispositivo2.Nome1.ToUpper(), "*" + sNome1.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureDispositivo2.Nome2.ToUpper(), "*" + sNome2.ToUpper() + "*", CompareMethod.Text) & LikeOperator.LikeString(structureDispositivo2.Alternativo.ToUpper(), "*" + sAlternativo.ToUpper() + "*", CompareMethod.Text))
												{
													array = (mBlocos[])Utils.CopyArray(array, new mBlocos[num + 1]);
													array[num].sNome1 = structureDispositivo2.Nome1;
													array[num].sNome2 = structureDispositivo2.Nome2;
													array[num].sBloco = val6.Name;
													ref mBlocos reference7 = ref array[num];
													string pagina7 = val5.Layer.ToString();
													ent = val5;
													reference7.sPagina = Pagina.montaCruzamentoPagina(pagina7, Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
													array[num].sAlternativo = structureDispositivo2.Alternativo;
													array[num].iPainel = structureDispositivo2.Painel;
													array[num].sPainel = Dicionario.BuscaNomeDoPainel(structureDispositivo2.Painel);
													array[num].iOrdem = 1;
													if (structureDispositivo2.Complementar)
													{
														array[num].sTipo = "Complemantar";
													}
													else
													{
														array[num].sTipo = "Principal";
													}
													array[num].sHandle = ((object)((DBObject)val6).Handle/*cast due to constrained. prefix*/).ToString();
													num++;
												}
											}
										}
										num2++;
										if (num2 == 100)
										{
											DeclaracoesGeral._uscPagina.pbPasso(num2);
											num2 = 0;
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
						int num5 = Information.UBound(array);
						for (int j = 1; j <= num5; j++)
						{
							if (array[j].iTipo != 3)
							{
								continue;
							}
							int num6 = Information.UBound(array);
							for (int k = 1; k <= num6; k++)
							{
								if (array[k].iTipo == 1 && array[j].iPot == array[k].iPot)
								{
									array[j].sNome1 = array[k].sNome1;
									break;
								}
							}
						}
						if (Information.UBound(array) >= 2 && Information.UBound(array) > 0)
						{
							int num7 = Information.UBound(array);
							for (int l = 1; l <= num7; l++)
							{
								int num8 = Information.UBound(array) - 1;
								int num9 = l;
								for (int m = num8; m >= num9; m += -1)
								{
									if (array[m].iPainel > array[m + 1].iPainel)
									{
										mBlocos mBlocos2 = array[m + 1];
										array[m + 1] = array[m];
										array[m] = mBlocos2;
									}
									if (array[m].iPainel == array[m + 1].iPainel && Operators.CompareString(array[m].sNome1, array[m + 1].sNome1, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[m + 1];
										array[m + 1] = array[m];
										array[m] = mBlocos2;
									}
									if (array[m].iPainel == array[m + 1].iPainel && Operators.CompareString(array[m].sNome1, array[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[m].sNome2, array[m + 1].sNome2, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[m + 1];
										array[m + 1] = array[m];
										array[m] = mBlocos2;
									}
									if (array[m].iPainel == array[m + 1].iPainel && Operators.CompareString(array[m].sNome1, array[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[m].sNome2, array[m + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(array[m].sAlternativo, array[m + 1].sAlternativo, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[m + 1];
										array[m + 1] = array[m];
										array[m] = mBlocos2;
									}
									if (array[m].iPainel == array[m + 1].iPainel && Operators.CompareString(array[m].sNome1, array[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[m].sNome2, array[m + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(array[m].sAlternativo, array[m + 1].sAlternativo, TextCompare: true) == 0 && array[m].iOrdem > array[m + 1].iOrdem)
									{
										mBlocos mBlocos2 = array[m + 1];
										array[m + 1] = array[m];
										array[m] = mBlocos2;
									}
									if (array[m].iPainel == array[m + 1].iPainel && Operators.CompareString(array[m].sNome1, array[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[m].sNome2, array[m + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(array[m].sAlternativo, array[m + 1].sAlternativo, TextCompare: true) == 0 && array[m].iOrdem == array[m + 1].iOrdem && Operators.CompareString(array[m].sTipo, array[m + 1].sTipo, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[m + 1];
										array[m + 1] = array[m];
										array[m] = mBlocos2;
									}
									if (array[m].iPainel == array[m + 1].iPainel && Operators.CompareString(array[m].sNome1, array[m + 1].sNome1, TextCompare: true) == 0 && Operators.CompareString(array[m].sNome2, array[m + 1].sNome2, TextCompare: true) == 0 && Operators.CompareString(array[m].sAlternativo, array[m + 1].sAlternativo, TextCompare: true) == 0 && array[m].iOrdem == array[m + 1].iOrdem && Operators.CompareString(array[m].sTipo, array[m + 1].sTipo, TextCompare: true) == 0 && Operators.CompareString(array[m].sPagina, array[m + 1].sPagina, TextCompare: true) > 0)
									{
										mBlocos mBlocos2 = array[m + 1];
										array[m + 1] = array[m];
										array[m] = mBlocos2;
									}
								}
							}
						}
						int num10 = Information.UBound(array);
						for (int n = 1; n <= num10; n++)
						{
							array[n].sPagina = array[n].sPagina.Replace("/0", "");
							if (Operators.CompareString(array[n].sTipo, "Borne", TextCompare: true) == 0 && Operators.CompareString(clsTextos.TiraNothing(array[n].sBorne), "", TextCompare: true) != 0)
							{
								array[n].sNome1 = array[n].sBorne;
							}
							dg.Rows.Add(array[n].sNome1, array[n].sNome2, array[n].sAlternativo, array[n].sPainel, array[n].sTipo, array[n].sHandle, array[n].sBloco, array[n].sPagina);
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						if (dg.RowCount == 0)
						{
							return;
						}
						Conversions.ToString(1);
						bool flag5 = false;
						string text8 = "";
						sNome1 = Conversions.ToString(dg.Rows[0].Cells[0].Value);
						sNome2 = Conversions.ToString(dg.Rows[0].Cells[1].Value);
						sAlternativo = Conversions.ToString(dg.Rows[0].Cells[2].Value);
						text8 = Conversions.ToString(dg.Rows[0].Cells[3].Value);
						int num11 = dg.RowCount - 1;
						for (int num12 = 0; num12 <= num11; num12++)
						{
							if (!((Operators.CompareString(dg.Rows[num12].Cells[0].Value.ToString(), sNome1, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num12].Cells[1].Value.ToString(), sNome2, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num12].Cells[2].Value.ToString(), sAlternativo, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num12].Cells[3].Value.ToString(), text8, TextCompare: true) == 0)))
							{
								flag5 = !flag5;
								sNome1 = Conversions.ToString(dg.Rows[num12].Cells[0].Value);
								sNome2 = Conversions.ToString(dg.Rows[num12].Cells[1].Value);
								sAlternativo = Conversions.ToString(dg.Rows[num12].Cells[2].Value);
								text8 = Conversions.ToString(dg.Rows[num12].Cells[3].Value);
							}
							int num13 = 0;
							do
							{
								if (!flag5)
								{
									dg.Rows[num12].Cells[num13].Style.BackColor = Color.White;
									dg.Rows[num12].Cells[num13].Style.ForeColor = Color.Black;
								}
								else
								{
									dg.Rows[num12].Cells[num13].Style.BackColor = Color.LightYellow;
									dg.Rows[num12].Cells[num13].Style.ForeColor = Color.Black;
								}
								num13++;
							}
							while (num13 <= 7);
						}
						int num14 = dg.RowCount - 1;
						for (int num15 = 0; num15 <= num14; num15++)
						{
							if (Operators.CompareString(dg.Rows[num15].Cells[1].Value.ToString(), "", TextCompare: true) != 0)
							{
								bNome2 = true;
							}
							if (Operators.CompareString(dg.Rows[num15].Cells[2].Value.ToString(), "", TextCompare: true) != 0)
							{
								bAlternativo = true;
							}
							int num16 = Information.UBound(array);
							for (int num17 = 1; num17 <= num16; num17++)
							{
								if (((Operators.CompareString(dg.Rows[num15].Cells[0].Value.ToString(), array[num17].sNome1, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num15].Cells[1].Value.ToString(), array[num17].sNome2, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num15].Cells[2].Value.ToString(), array[num17].sAlternativo, TextCompare: true) == 0) & (Operators.CompareString(dg.Rows[num15].Cells[3].Value.ToString(), array[num17].sPainel, TextCompare: true) == 0)) && array[num17].bPinta)
								{
									int num18 = 0;
									do
									{
										dg.Rows[num15].Cells[num18].Style.BackColor = Color.LightCoral;
										dg.Rows[num15].Cells[num18].Style.ForeColor = Color.Black;
										num18++;
									}
									while (num18 <= 7);
								}
							}
						}
						DeclaracoesGeral._uscPagina.pbFim();
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
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
			catch (Exception ex2)
			{
				ProjectData.SetProjectError((Exception)ex2);
				throw;
			}
		}
	}

	[CommandMethod("CorrigeHandleSuperior")]
	public static void CorrigeHandleSuperior()
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
		{
			return;
		}
		int num = 0;
		string pagina = DeclaracoesGeral.ativo.Pagina;
		limpaHandleSuperior();
		AtivaTodasAsPagina();
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl == null)
						{
							continue;
						}
						DeclaracoesEntidades.StructureConexao conex = default;
						if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Tipo == 3)
						{
							Point3d startPoint = ((Curve)pl).StartPoint;
							string sTipo = "";
							string sNome = "";
							int num2 = 0;
							int iPotencial = 0;
							string sHandle = ((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString();
							short iPainel = 0;
							bool flag = verificaConexao(startPoint, ref sTipo, ref iPainel, ref iPotencial, ref sHandle, val5.Layer, ref sNome);
							num2 = iPainel;
							if (flag && conex.Painel == num2 && ((Operators.CompareString(conex.Handle, sHandle, TextCompare: true) != 0) | (Operators.CompareString(conex.Nome, sNome, TextCompare: true) != 0) | (conex.Potencial != iPotencial)))
							{
								conex.Handle = sHandle;
								conex.Nome = sNome;
								conex.Potencial = iPotencial;
								((DBObject)pl).UpgradeOpen();
								XDataConexao.GravarXDataConexao(ref pl, conex);
								((DBObject)pl).DowngradeOpen();
								num = checked(num + 1);
							}
						}
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				Pagina.AtivaPagina(pagina);
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Interaction.MsgBox("Atualizadas " + Conversions.ToString(num) + " Derivações");
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

	[CommandMethod("Limpahandle")]
	public static void limpaHandleSuperior()
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected Obj, but got Unknown
		if (Operators.CompareString(DeclaracoesGeral.companyHardlock.ToUpper(), "CADGRAPH", TextCompare: true) != 0)
		{
			return;
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
						Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
						Polyline pl = (Polyline)(object)((val5 is Polyline) ? val5 : null);
						if (pl != null)
						{
							DeclaracoesEntidades.StructureConexao conex = default;
							if (XDataConexao.lerXDataConexao(ref pl, ref conex) && conex.Tipo == 3)
							{
								conex.Handle = "";
								((DBObject)pl).UpgradeOpen();
								XDataConexao.GravarXDataConexao(ref pl, conex);
								((DBObject)pl).DowngradeOpen();
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

	public static bool verificaConexao(Point3d pt, ref string sTipo, ref short iPainel, ref int iPotencial, ref string sHandle, string sPagina, ref string sNome)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected Obj, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected Obj, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected Obj, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		short num = 0;
		string right = sHandle;
		Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
		Point3d val = new Point3d(pt.X - 0.2, pt.Y - 0.2, 0.0);
		Point3d val2 = new Point3d(pt.X + 0.2, pt.Y + 0.2, 0.0);
		PromptSelectionResult val3 = editor.SelectCrossingWindow(val, val2);
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val4 = database.TransactionManager.StartTransaction();
		try
		{
			if (!Information.IsNothing(val3.Value))
			{
				SelectionSet value = val3.Value;
				ObjectIdCollection val5 = new ObjectIdCollection(value.GetObjectIds());
				foreach (object item in val5)
				{
					ObjectId val6 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
					Entity val7 = (Entity)val6.GetObject((OpenMode)0);
					if (Operators.CompareString(val7.Layer, sPagina, TextCompare: true) != 0 || Operators.CompareString(((object)((DBObject)val7).Handle/*cast due to constrained. prefix*/).ToString(), right, TextCompare: true) == 0)
					{
						continue;
					}
					Polyline pl = (Polyline)(object)((val7 is Polyline) ? val7 : null);
					DeclaracoesEntidades.StructureConexao conex = default;
					if (pl == null || !XDataConexao.lerXDataConexao(ref pl, ref conex))
					{
						continue;
					}
					if (Operators.CompareString(conex.Jumper, "", TextCompare: true) != 0)
					{
						if (Operators.CompareString(conex.Jumper, "JUMPER", TextCompare: true) == 0)
						{
							sTipo = "J";
						}
					}
					else
					{
						sTipo = "C";
					}
					num = checked((short)(num + 1));
					sNome = conex.Nome;
					sHandle = ((object)((DBObject)pl).Handle/*cast due to constrained. prefix*/).ToString();
					iPainel = conex.Painel;
					iPotencial = conex.Potencial;
					result = true;
					break;
				}
			}
			DeclaracoesGeral.bAnularEventos = true;
			val4.Commit();
			DeclaracoesGeral.bAnularEventos = false;
			return result;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			val4.Abort();
			throw;
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
	}

	public static void AtivaTodasAsPagina()
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
				ObjectId val3 = mdiActiveDocument.Database.LayerTableId;
				LayerTable val4 = (LayerTable)val3.GetObject((OpenMode)0);
				SymbolTableEnumerator enumerator = val4.GetEnumerator();
				while (enumerator.MoveNext())
				{
					val3 = enumerator.Current;
					LayerTableRecord val5 = (LayerTableRecord)val3.GetObject((OpenMode)0);
					((DBObject)val5).UpgradeOpen();
					val5.IsOff = false;
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				Application.UpdateScreen();
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
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

	[CommandMethod("CorrigeCoresDosBlocos")]
	public static void CorrigeCoresDosBlocos()
	{
		mBlocosCores[] array = new mBlocosCores[1];
		List<string> lBl = new List<string>();
		carregaBlocosInseridos(ref lBl);
		MMg1xjoRaA(ref array, ref lBl);
		lu61bhmRNc(ref array, lBl);
	}

	public static void carregaBlocosInseridos(ref List<string> lBl)
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
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					if (val5 != null && !Information.IsNothing(((DBObject)val5).XData) && !lBl.Contains(val5.Name))
					{
						lBl.Add(val5.Name);
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

	private static void MMg1xjoRaA(ref mBlocosCores[] P_0, ref List<string> P_1)
	{
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected Obj, but got Unknown
		//IL_0193: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected Obj, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected Obj, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected Obj, but got Unknown
		int num = 0;
		P_0 = new mBlocosCores[1];
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
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
						_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
						BlockTableRecordEnumerator enumerator2 = default;
						foreach (string item in P_1)
						{
							BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[item], (OpenMode)0);
							_ = ((DBObject)val4).Id;
							try
							{
								enumerator2 = val4.GetEnumerator();
								while (enumerator2.MoveNext())
								{
									ObjectId current2 = enumerator2.Current;
									Entity val5 = (Entity)val2.GetObject(current2, (OpenMode)0);
									if (val5 is AttributeDefinition)
									{
										AttributeDefinition val6 = (AttributeDefinition)val5;
										num++;
										P_0 = (mBlocosCores[])Utils.CopyArray(P_0, new mBlocosCores[num + 1]);
										P_0[num].sNomeBloco = ((SymbolTableRecord)val4).Name;
										P_0[num].sATT = val6.Tag;
										P_0[num].iCor = ((Entity)val6).ColorIndex;
									}
								}
							}
							finally
							{
								((IDisposable)enumerator2)?.Dispose();
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						Exception ex2 = ex;
						val2.Abort();
						Interaction.MsgBox(((Exception)(object)ex2).Message, MsgBoxStyle.Information);
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
	}

	private static void lu61bhmRNc(ref mBlocosCores[] P_0, List<string> P_1)
	{
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected Obj, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected Obj, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected Obj, but got Unknown
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		checked
		{
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
						BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
						int num = 0;
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val4.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity val5 = (Entity)val2.GetObject(current, (OpenMode)0);
								BlockReference val6 = (BlockReference)(object)((val5 is BlockReference) ? val5 : null);
								if (val6 == null || !P_1.Contains(val6.Name.ToUpper()))
								{
									continue;
								}
								((DBObject)val6).UpgradeOpen();
								AttributeCollection attributeCollection = val6.AttributeCollection;
								foreach (object item in attributeCollection)
								{
									ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
									AttributeReference val8 = (AttributeReference)val7.GetObject((OpenMode)0);
									int num2 = Information.UBound(P_0);
									for (int i = 1; i <= num2; i++)
									{
										if (Operators.CompareString(P_0[i].sNomeBloco.ToUpper(), val6.Name.ToUpper(), TextCompare: true) == 0 && Operators.CompareString(val8.Tag, P_0[i].sATT, TextCompare: true) == 0)
										{
											if (((Entity)val8).ColorIndex != P_0[i].iCor)
											{
												((DBObject)val8).UpgradeOpen();
												((Entity)val8).ColorIndex = P_0[i].iCor;
												num++;
											}
											break;
										}
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
						Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
						editor.WriteMessage("\n" + Conversions.ToString(num) + " Blocos Corrigidos");
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
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				ProjectData.ClearProjectError();
			}
		}
	}

	public static void LimpaVeiasDeDWGsApagados()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected Obj, but got Unknown
		CDadosAccessInterligacao cDadosAccessInterligacao3 = new CDadosAccessInterligacao();
		try
		{
			cDadosAccessInterligacao3.LimpaVeiasSemCaderno();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			throw;
		}
		finally
		{
			cDadosAccessInterligacao3.FechaConexao();
		}
	}

	[CommandMethod("RENPAGA")]
	public static void RenumerarPagina()
	{
		string text = "1";
		int num = Information.UBound(DeclaracoesGeral.mPaginas, 2);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				text = DeclaracoesGeral.mPaginas[0, i].ToString();
				if (!Versioned.IsNumeric(text))
				{
					Interaction.MsgBox("As páginas não podem conter caracter alfabético para usar esta função!", MsgBoxStyle.Information);
					return;
				}
			}
			string text2 = Interaction.InputBox("Informe o caracter que deseja inserir: ", "Renomear Páginas");
			bool flag = false;
			if (!Versioned.IsNumeric(text2))
			{
				text2 = text2.ToUpper();
			}
			if (Strings.Len(text2) == 1 && ((Strings.Asc(text2) >= 65) & (Strings.Asc(text2) <= 90)))
			{
				flag = true;
			}
			if (flag)
			{
				object[,] array = new object[3, 1];
				int num2 = Information.UBound(DeclaracoesGeral.mPaginas, 2);
				for (int j = 2; j <= num2; j++)
				{
					int num3 = Information.UBound(array, 2) + 1;
					array = (object[,])Utils.CopyArray(array, new object[3, num3 + 1]);
					array[0, num3] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[0, j]);
					array[1, num3] = RuntimeHelpers.GetObjectValue(DeclaracoesGeral.mPaginas[1, j]);
					array[2, num3] = Operators.ConcatenateObject(DeclaracoesGeral.mPaginas[0, j], text2);
				}
				Pagina.renumerarPaginasLote(array);
				clsConexao.sincronizaCircuitos();
				clsInterligacao.SincronizaCruzamentoInterlig();
				clsDePara.SincronizaDePara(bUpdateProp: false);
				clsDispositivoAuxiliares.SincronizaContatos();
				clsPortas.SincronizaPortas();
				DeclaracoesGeral._uscPagina.CarregaPG();
			}
			else
			{
				Interaction.MsgBox("Caracter " + text2 + " Inválido", MsgBoxStyle.Information);
			}
		}
	}

	[CommandMethod("REMLAYDUP")]
	public static void RemoveDuplicadoLayoutRapido()
	{
		cDadosAccess.carregaPainelDicionario();
		checked
		{
			foreach (int key in DeclaracoesGeral.dicPainel.Keys)
			{
				DeclaracoesEntidades.StructureLayout[] mTags = new DeclaracoesEntidades.StructureLayout[1];
				DeclaracoesEntidades.StructureLayout[] mTags2 = new DeclaracoesEntidades.StructureLayout[1];
				int num = 0;
				if (DicionarioLayout.LeDicLayout("P" + key, ref mTags))
				{
					List<string> list = new List<string>();
					int num2 = Information.UBound(mTags) - 1;
					for (int i = 0; i <= num2; i++)
					{
						if (!list.Contains(mTags[i].Tag))
						{
							list.Add(mTags[i].Tag);
							mTags2 = (DeclaracoesEntidades.StructureLayout[])Utils.CopyArray(mTags2, new DeclaracoesEntidades.StructureLayout[num + 1]);
							mTags2[num].Tag = mTags[i].Tag;
							mTags2[num].Alternativo = mTags[i].Alternativo;
							mTags2[num].X = mTags[i].X;
							mTags2[num].Y = mTags[i].Y;
							num++;
						}
					}
					DicionarioLayout.ApagaDicLayoutPainel("P", Conversions.ToString(key));
					DicionarioLayout.gravaDicLayout("P" + key, ref mTags2);
				}
				DeclaracoesEntidades.StructureLayout[] mTags3 = new DeclaracoesEntidades.StructureLayout[1];
				DeclaracoesEntidades.StructureLayout[] mTags4 = new DeclaracoesEntidades.StructureLayout[1];
				int num3 = 0;
				if (!DicionarioLayout.LeDicLayout("C" + key, ref mTags3))
				{
					continue;
				}
				List<string> list2 = new List<string>();
				int num4 = Information.UBound(mTags3) - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (!list2.Contains(mTags3[j].Tag))
					{
						list2.Add(mTags3[j].Tag);
						mTags4 = (DeclaracoesEntidades.StructureLayout[])Utils.CopyArray(mTags4, new DeclaracoesEntidades.StructureLayout[num3 + 1]);
						mTags4[num3].Tag = mTags3[j].Tag;
						mTags4[num3].Alternativo = mTags3[j].Alternativo;
						mTags4[num3].X = mTags3[j].X;
						mTags4[num3].Y = mTags3[j].Y;
						num3++;
					}
				}
				DicionarioLayout.ApagaDicLayoutPainel("C", Conversions.ToString(key));
				DicionarioLayout.gravaDicLayout("C" + key, ref mTags4);
			}
		}
	}
}

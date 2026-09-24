using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

public class clsBornes
{
	public struct StructureBlocoBorne
	{
		public string numero;

		public string numeroComplem;

		public double ordem;

		public int IndiceRegua;

		public string Handle;

		public string Pagina;

		public string NomeRegua;

		public string Painel;

		public string conector;

		public int LM;

		public int tipo;

		public int Visivel;

		public string sNomeDoBloco;

		public string sCaminhoBloco;

		public string Orientacao;

		public string Layout;
	}

	public struct BornesTipo
	{
		public string Nome;

		public Point3d iIni;

		public Point3d iFim;
	}

	public struct mBornes
	{
		public int _0IndiceRegua;

		public int _1Ordem;

		public string _2Numero;

		public string _3Alternativo;

		public string _4Tipo;

		public int _5ListaDeMateriais;

		public string _6Pagina;

		public string _7Handle;

		public string _8NumeroOriginal;

		public double _9sPG;

		public double _10sLin;

		public double _11sCol;

		public int _12iPot;

		public string _13Cabo;

		public string _14Veia;

		public string _15Orientacao;

		public string _16Layout;

		public string _17NomeUnico;
	}

	public struct ordemBornes
	{
		public int indexRegua;

		public string Nome;

		public string Alternativo;

		public string sHandle;

		public double dX;

		public double dY;

		public double Ordem;

		public int iOrdemSelecao;

		public int Tipo;

		public int Lm;

		public string Orientacao;

		public string Layout;
	}

	public struct mOrdem
	{
		public double pagina;

		public int potencial;

		public int ordem;

		public string shandle;
	}

	public static double BuscaTamanhodoBorneH(string shandle, int parte)
	{
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		double num = 15.0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(shandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					Point3d val6 = new Point3d(0.0, 0.0, 0.0);
					Point3d val7;
					if (val5 != null)
					{
						val7 = val5.Position;
						double x = val7.X;
						val7 = val5.Position;
						val6 = new Point3d(x, val7.Y, 0.0);
					}
					Extents3d value;
					if (parte != 1)
					{
						value = ((Drawable)val4).Bounds.Value;
						val7 = value.MaxPoint;
						num = val7.X - val6.X;
						num++;
					}
					else
					{
						double x2 = val6.X;
						value = ((Drawable)val4).Bounds.Value;
						val7 = value.MinPoint;
						num = x2 - val7.X;
						num--;
					}
					if (!clsBlocos.AtributoVisivel(((object)((DBObject)val5).Handle/*cast due to constrained. prefix*/).ToString(), "NOME1"))
					{
						num = 10.0;
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
		return num;
	}

	public static double BuscaTamanhodoBorneV(string shandle, int parte)
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		double result = 15.0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(shandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					Point3d val6 = new Point3d(0.0, 0.0, 0.0);
					Point3d val7;
					if (val5 != null)
					{
						val7 = val5.Position;
						double x = val7.X;
						val7 = val5.Position;
						val6 = new Point3d(x, val7.Y, 0.0);
					}
					Extents3d value;
					if (parte != 1)
					{
						value = ((Drawable)val4).Bounds.Value;
						val7 = value.MaxPoint;
						result = val7.Y - val6.Y;
					}
					else
					{
						double y = val6.Y;
						value = ((Drawable)val4).Bounds.Value;
						val7 = value.MinPoint;
						result = y - val7.Y;
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
		return result;
	}

	public static double BuscaTamanhodoBorneMeioH(string shandle, int parte)
	{
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		double result = 15.0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Entity val4 = (Entity)Geral.HandleToObject(shandle);
				if (val4 != null)
				{
					BlockReference val5 = (BlockReference)(object)((val4 is BlockReference) ? val4 : null);
					Point3d val6 = new Point3d(0.0, 0.0, 0.0);
					Point3d val7;
					if (val5 != null)
					{
						val7 = val5.Position;
						double x = val7.X;
						val7 = val5.Position;
						val6 = new Point3d(x, val7.Y, 0.0);
					}
					Extents3d value;
					if (parte != 1)
					{
						value = ((Drawable)val4).Bounds.Value;
						val7 = value.MaxPoint;
						result = (val7.X - val6.X) / 2.0;
					}
					else
					{
						double x2 = val6.X;
						value = ((Drawable)val4).Bounds.Value;
						val7 = value.MinPoint;
						result = (x2 - val7.X) / 2.0;
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
		return result;
	}

	public static void OcultaAtributoNome()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		try
		{
			string Tipo = "B";
			ObjectId ObjectId = ObjectId.Null;
			ObjectId = clsAtributos.selecionaUmBloco(ref Tipo);
			if (ObjectId.IsValid && !OcultaAtributos(ref ObjectId, "NOME1"))
			{
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			ProjectData.ClearProjectError();
		}
		finally
		{
			DeclaracoesGeral.bAnularEventos = false;
		}
	}

	public static bool OcultaAtributos(ref ObjectId ObjectId, string sAtributo)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected Obj, but got Unknown
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		if (!ObjectId.IsNull)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockReference val3 = (BlockReference)val2.GetObject(ObjectId, (OpenMode)0);
					Entity ent = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
					string tipoImportado = "";
					if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
					{
						_ = (BlockTableRecord)val2.GetObject(val3.BlockTableRecord, (OpenMode)0);
						AttributeCollection attributeCollection = val3.AttributeCollection;
						foreach (object item in attributeCollection)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(item);
							AttributeReference val4 = (AttributeReference)NewLateBinding.LateGet(objectValue, null, "GetObject", new object[1] { (object)(OpenMode)1 }, null, null, null);
							if (Operators.CompareString(val4.Tag.ToUpper(), sAtributo.ToUpper(), TextCompare: true) == 0)
							{
								if (!((Entity)val4).Visible)
								{
									((Entity)val4).Visible = true;
								}
								else
								{
									((Entity)val4).Visible = false;
								}
								break;
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						ObjectId = ((DBObject)val3).ObjectId;
						result = true;
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
		return result;
	}

	public static void OcultaAtributoPainel()
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		DeclaracoesGeral.bAnularEventos = true;
		try
		{
			string Tipo = "B";
			ObjectId ObjectId = ObjectId.Null;
			ObjectId = clsAtributos.selecionaUmBloco(ref Tipo);
			if (ObjectId.IsValid && !OcultaAtributosPainel(ref ObjectId, "NOME1"))
			{
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			DeclaracoesGeral.bAnularEventos = false;
			ProjectData.ClearProjectError();
		}
		DeclaracoesGeral.bAnularEventos = false;
	}

	public static bool OcultaAtributosPainel(ref ObjectId ObjectId, string sAtributo)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected Obj, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Expected Obj, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected Obj, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		if (!ObjectId.IsNull)
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					Entity ent = (Entity)val2.GetObject(ObjectId, (OpenMode)0);
					string tipoImportado = "";
					if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
					{
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
					else
					{
						DeclaracoesEntidades.StructureBorne structureBorne = default;
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						short num = 0;
						num = checked((short)DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo));
						structureBorne.NomePainel = Dicionario.BuscaNomeDoPainel(num);
						string text = "";
						if (structureBorne.Visivel != 0)
						{
							structureBorne.Visivel = 0;
							text = structureBorne.NomePainel + DeclaracoesGeral.Conf.SeparadorPainelRegua + structureBorne.NomeRegua;
						}
						else
						{
							structureBorne.Visivel = 1;
							text = structureBorne.NomeRegua;
						}
						blockRef = (BlockReference)ent;
						XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
						ent = (Entity)(object)blockRef;
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
						tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
						clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "NOME1", text);
						result = true;
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
		return result;
	}

	public static void InserirBorne(ref StructureBlocoBorne myBornes, int indice, bool bPrimeiro, bool bPainel, bool bRegua, ref Point3d point)
	{
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_052f: Expected Obj, but got Unknown
		//IL_0531: Expected Obj, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected Obj, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0496: Expected Obj, but got Unknown
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b2: Expected Obj, but got Unknown
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Invalid comparison between Unknown and I4
		//IL_0500: Unknown result type (might be due to invalid IL or missing references)
		//IL_050a: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected Obj, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Expected Obj, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected Obj, but got Unknown
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected Obj, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Expected Obj, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockReference val3 = null;
				ObjectId val4 = ObjectId.Null;
				BlockTable val5 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val6 = (BlockTableRecord)val2.GetObject(((SymbolTable)val5)[BlockTableRecord.ModelSpace], (OpenMode)1);
				BlockTableRecord val7 = null;
				if (!((SymbolTable)val5).Has(myBornes.sNomeDoBloco))
				{
					Database val8 = new Database(false, true);
					val8.ReadDwgFile(myBornes.sCaminhoBloco, FileShare.Read, true, "");
					DeclaracoesGeral.bAnularEventos = true;
					val4 = database.Insert(myBornes.sNomeDoBloco, val8, false);
					((DisposableWrapper)val8).Dispose();
				}
				else
				{
					BlockTableRecord val9 = (BlockTableRecord)val2.GetObject(((SymbolTable)val5)[myBornes.sNomeDoBloco], (OpenMode)0);
					val4 = ((DBObject)val9).Id;
				}
				if (indice != 1)
				{
					val3 = new BlockReference(point, val4);
					((Entity)val3).Layer = DeclaracoesGeral.ativo.Pagina;
				}
				else
				{
					val3 = new BlockReference(Point3d.Origin, val4);
					((Entity)val3).Layer = DeclaracoesGeral.ativo.Pagina;
					Jig jig = new Jig((Entity)(object)val3);
					hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
					PromptResult val10 = editor.Drag((Jig)(object)jig);
					if (((int)val10.Status == -5002) | ((int)val10.Status == -5001))
					{
						val3 = null;
						goto IL_0515;
					}
				}
				val6.AppendEntity((Entity)(object)val3);
				myBornes.Handle = ((object)((DBObject)val3).Handle/*cast due to constrained. prefix*/).ToString();
				myBornes.Pagina = ((Entity)val3).Layer;
				((Entity)val3).Draw();
				DeclaracoesGeral.bAnularEventos = true;
				val2.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
				Point3d position = val3.Position;
				point = position;
				val7 = (BlockTableRecord)val2.GetObject(val4, (OpenMode)0);
				DeclaracoesEntidades.StructureBorne Borne = new DeclaracoesEntidades.StructureBorne
				{
					Visivel = 1,
					PosInt_Jumper = ""
				};
				BlockTableRecordEnumerator enumerator = default;
				try
				{
					enumerator = val7.GetEnumerator();
					while (enumerator.MoveNext())
					{
						ObjectId current = enumerator.Current;
						Entity val11 = (Entity)val2.GetObject(current, (OpenMode)0);
						if (!(val11 is AttributeDefinition))
						{
							continue;
						}
						AttributeDefinition val12 = (AttributeDefinition)val11;
						AttributeReference val13 = new AttributeReference();
						val13.SetAttributeFromBlock(val12, val3.BlockTransform);
						string textString = "";
						string tag = val12.Tag;
						if (Operators.CompareString(tag, "NOME1", TextCompare: true) != 0)
						{
							if (Operators.CompareString(tag, "PAINEL", TextCompare: true) != 0)
							{
								if (Operators.CompareString(tag, "REGUA", TextCompare: true) != 0)
								{
									if (Operators.CompareString(tag, "T1", TextCompare: true) == 0)
									{
										textString = myBornes.numero;
									}
								}
								else
								{
									textString = myBornes.NomeRegua;
									((Entity)val13).Visible = false;
									if (bPrimeiro & bRegua)
									{
										((Entity)val13).Visible = true;
										Borne.Visivel = 0;
									}
								}
							}
							else
							{
								textString = myBornes.Painel;
								((Entity)val13).Visible = false;
								if (bPrimeiro & bPainel)
								{
									((Entity)val13).Visible = true;
									Borne.Visivel = 0;
								}
							}
						}
						else
						{
							if (bPainel & bRegua)
							{
								textString = myBornes.Painel + DeclaracoesGeral.Conf.SeparadorPainelRegua + myBornes.NomeRegua;
								if (bPrimeiro)
								{
									Borne.Visivel = 0;
								}
							}
							if (bPainel & !bRegua)
							{
								textString = myBornes.Painel;
								Borne.Visivel = 1;
							}
							if (!bPainel & bRegua)
							{
								textString = myBornes.NomeRegua;
								Borne.Visivel = 1;
							}
							((Entity)val13).Visible = bPrimeiro;
							if (!bPainel & !bRegua)
							{
								textString = myBornes.Painel + DeclaracoesGeral.Conf.SeparadorPainelRegua + myBornes.NomeRegua;
								((Entity)val13).Visible = false;
								Borne.Visivel = 0;
							}
						}
						((DBText)val13).TextString = textString;
						((DBText)val13).AdjustAlignment(database);
						val3.AttributeCollection.AppendAttribute(val13);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val13, true);
						((Entity)val13).Draw();
					}
				}
				finally
				{
					((IDisposable)enumerator)?.Dispose();
				}
				((Entity)val3).Draw();
				Borne.Numero = myBornes.numero;
				Borne.Alternativo = "";
				Borne.conector = myBornes.conector;
				Borne.Handle = "";
				Borne.IndiceRegua = myBornes.IndiceRegua;
				Borne.lm = myBornes.LM;
				Borne.NomePainel = myBornes.Painel;
				Borne.NomeRegua = myBornes.NomeRegua;
				Borne.NumeroComplem = myBornes.numeroComplem;
				Borne.Ordem = myBornes.ordem;
				Borne.Orientacao = myBornes.Orientacao;
				Borne.BlocoLayout = myBornes.Layout;
				Borne.pagina = "";
				Borne.reserva = false;
				Borne.tipo = myBornes.tipo;
				Borne.Handle = myBornes.Handle;
				XDataDispositivosMaster.GravarXDataDispBorne(ref val3, ref Borne);
				goto IL_0515;
				IL_0515:
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void insereBorneAutomaticamente(ref DeclaracoesEntidades.StructureBorne Borne, string sCaminhoBloco, string sNomeDoBloco, bool InsereBorne, bool Up)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Unknown result type (might be due to invalid IL or missing references)
		//IL_0669: Expected Obj, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Invalid comparison between Unknown and I4
		//IL_067d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0682: Unknown result type (might be due to invalid IL or missing references)
		//IL_0697: Unknown result type (might be due to invalid IL or missing references)
		//IL_069c: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Expected Obj, but got Unknown
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected Obj, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected Obj, but got Unknown
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Expected Obj, but got Unknown
		//IL_04a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_0509: Expected Obj, but got Unknown
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Expected Obj, but got Unknown
		//IL_034c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Expected Obj, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_045d: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_0529: Unknown result type (might be due to invalid IL or missing references)
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected Obj, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_054d: Expected Obj, but got Unknown
		//IL_054d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected Obj, but got Unknown
		//IL_0559: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Unknown result type (might be due to invalid IL or missing references)
		ObjectId val = ObjectId.Null;
		BlockReference blockRef = null;
		Point3d val2 = new Point3d(0.0, 0.0, 0.0);
		Point3d val3 = new Point3d(0.0, 0.0, 0.0);
		Point3d[] array = new Point3d[1];
		double[] array2 = new double[1];
		PointMonitorToolTips.StopMonitor();
		DocumentLock val4 = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val5 = database.TransactionManager.StartTransaction();
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PromptPointResult point = editor.GetPoint("\r\nEscolha um ponto no desenho");
				Point3d val6;
				if ((int)((PromptResult)point).Status != -5002)
				{
					val6 = point.Value;
					double num = val6.X - 0.1;
					val6 = point.Value;
					val2 = new Point3d(num, val6.Y, 0.0);
					val3 = val2;
				}
				checked
				{
					try
					{
						BlockTable val7 = (BlockTable)val5.GetObject(database.BlockTableId, (OpenMode)0);
						BlockTableRecord val8 = (BlockTableRecord)val5.GetObject(((SymbolTable)val7)[BlockTableRecord.ModelSpace], (OpenMode)1);
						BlockTableRecordEnumerator enumerator = default;
						try
						{
							enumerator = val8.GetEnumerator();
							while (enumerator.MoveNext())
							{
								ObjectId current = enumerator.Current;
								Entity ent = (Entity)val5.GetObject(current, (OpenMode)0);
								if (Operators.CompareString(ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
								{
									continue;
								}
								string tipoImportado = "";
								string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
								if (!((((Operators.CompareString(left, "P", TextCompare: true) == 0) | (Operators.CompareString(left, "E", TextCompare: true) == 0) | (Operators.CompareString(left, "A", TextCompare: true) == 0)) & !InsereBorne) | ((Operators.CompareString(left, "B", TextCompare: true) == 0) & InsereBorne) | ((Operators.CompareString(left, "I", TextCompare: true) == 0) & (Operators.CompareString(tipoImportado, "B", TextCompare: true) == 0))))
								{
									continue;
								}
								BlockReference val9 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (val9 == null)
								{
									continue;
								}
								val6 = val9.Position;
								if (!(val6.X > val3.X))
								{
									continue;
								}
								bool flag = Up;
								val6 = val9.Position;
								bool num2 = flag & (val6.Y > val3.Y);
								bool flag2 = !Up;
								val6 = val9.Position;
								if (!(num2 | (flag2 & (val6.Y < val3.Y))))
								{
									continue;
								}
								val6 = val9.Position;
								val2 = new Point3d(val6.X, val2.Y, 0.0);
								int num3 = Information.UBound(array2);
								int num4 = 0;
								while (true)
								{
									if (num4 <= num3)
									{
										if (Math.Abs(array2[num4] - val2.X) < 0.5)
										{
											break;
										}
										num4++;
										continue;
									}
									if (!((SymbolTable)val7).Has(sNomeDoBloco))
									{
										Database val10 = new Database(false, true);
										val10.ReadDwgFile(sCaminhoBloco, FileShare.Read, true, "");
										DeclaracoesGeral.bAnularEventos = true;
										val = database.Insert(sNomeDoBloco, val10, false);
										((DisposableWrapper)val10).Dispose();
									}
									else
									{
										BlockTableRecord val11 = (BlockTableRecord)val5.GetObject(((SymbolTable)val7)[sNomeDoBloco], (OpenMode)0);
										val = ((DBObject)val11).Id;
									}
									bool flag3 = true;
									int num5 = Information.UBound(array);
									for (int i = 0; i <= num5; i++)
									{
										if (Math.Round(array[i].X, 0) == Math.Round(val2.X, 0))
										{
											flag3 = false;
											break;
										}
									}
									if (flag3)
									{
										array = (Point3d[])Utils.CopyArray(array, new Point3d[Information.UBound(array) + 1 + 1]);
										array[Information.UBound(array)] = val2;
									}
									break;
								}
							}
						}
						finally
						{
							((IDisposable)enumerator)?.Dispose();
						}
						if (Information.UBound(array) > 1 && Information.UBound(array) >= 2 && Information.UBound(array) > 0)
						{
							int num6 = Information.UBound(array);
							for (int j = 1; j <= num6; j++)
							{
								int num7 = Information.UBound(array) - 1;
								int num8 = j;
								for (int k = num7; k >= num8; k += -1)
								{
									if (array[k].X > array[k + 1].X)
									{
										Point3d val12 = array[k + 1];
										array[k + 1] = array[k];
										array[k] = val12;
									}
								}
							}
						}
						if (Information.UBound(array) > 1)
						{
							int num9 = Information.UBound(array);
							BlockTableRecordEnumerator enumerator2 = default;
							for (int l = 1; l <= num9; l++)
							{
								blockRef = new BlockReference(array[l], val);
								((Entity)blockRef).Layer = DeclaracoesGeral.ativo.Pagina;
								val8.AppendEntity((Entity)(object)blockRef);
								array2 = (double[])Utils.CopyArray(array2, new double[Information.UBound(array2) + 1 + 1]);
								array2[Information.UBound(array2)] = array[l].X;
								((Entity)blockRef).Draw();
								DeclaracoesGeral.bAnularEventos = true;
								val5.AddNewlyCreatedDBObject((DBObject)(object)blockRef, true);
								BlockTableRecord val13 = (BlockTableRecord)val5.GetObject(val, (OpenMode)0);
								try
								{
									enumerator2 = val13.GetEnumerator();
									while (enumerator2.MoveNext())
									{
										ObjectId current2 = enumerator2.Current;
										Entity val14 = (Entity)val5.GetObject(current2, (OpenMode)0);
										if (!(val14 is AttributeDefinition))
										{
											continue;
										}
										AttributeDefinition val15 = (AttributeDefinition)val14;
										AttributeReference val16 = new AttributeReference();
										val16.SetAttributeFromBlock(val15, blockRef.BlockTransform);
										string textString = "";
										string tag = val15.Tag;
										if (Operators.CompareString(tag, "NOME1", TextCompare: true) != 0)
										{
											if (Operators.CompareString(tag, "T1", TextCompare: true) == 0)
											{
												textString = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
											}
										}
										else
										{
											textString = Borne.NomePainel + DeclaracoesGeral.Conf.SeparadorPainelRegua + Borne.NomeRegua;
											if (l != 1)
											{
												((Entity)val16).Visible = false;
											}
											else
											{
												((Entity)val16).Visible = true;
											}
										}
										((DBText)val16).TextString = textString;
										((DBText)val16).AdjustAlignment(database);
										blockRef.AttributeCollection.AppendAttribute(val16);
										DeclaracoesGeral.bAnularEventos = true;
										val5.AddNewlyCreatedDBObject((DBObject)(object)val16, true);
										((Entity)val16).Draw();
									}
								}
								finally
								{
									((IDisposable)enumerator2)?.Dispose();
								}
								((Entity)blockRef).Draw();
								XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref Borne);
							}
							DeclaracoesGeral.bAnularEventos = true;
							val5.Commit();
							DeclaracoesGeral.bAnularEventos = false;
							_ = blockRef.Position;
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError((Exception)ex);
						val5.Abort();
						ProjectData.ClearProjectError();
					}
					finally
					{
					}
				}
			}
			finally
			{
				((IDisposable)val5)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val4)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void indefineUmBorne(string sHandle)
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected Obj, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = Geral.HandleToID(sHandle);
				if (val3.IsValid)
				{
					Entity val4 = (Entity)val2.GetObject(val3, (OpenMode)1);
					DeclaracoesEntidades.StructureBorne structureBorne = default;
					BlockReference blockRef = (BlockReference)val4;
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					val4 = (Entity)(object)blockRef;
					structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
					structureBorne.NumeroComplem = "";
					structureBorne.Ordem = 0.0;
					structureBorne.Numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
					blockRef = (BlockReference)val4;
					XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
					val4 = (Entity)(object)blockRef;
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

	public static void EditarOsBornesDasReguasSelecionada(Declaracoes2.StructureModeloDeReguas[] mModeloDeReguasNovos, int index)
	{
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected Obj, but got Unknown
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
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected Obj, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
						{
							continue;
						}
						DeclaracoesEntidades.StructureBorne structureBorne = default;
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						int num = 0;
						string text = "";
						string text2 = "";
						string text3 = "";
						string sValor = "";
						if (mModeloDeReguasNovos[index].indexRegua == structureBorne.IndiceRegua)
						{
							num = mModeloDeReguasNovos[index].indexPainel;
							text2 = Dicionario.BuscaNomeDoPainel(num);
							text3 = mModeloDeReguasNovos[index].nomeRegua;
							if (clsBlocos.ExisteAtributo(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), "NOME1"))
							{
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								string text4 = clsBlocos.LeUmAtributoDeUmBloco(ref tipoImportado, "NOME1");
								text = (text4.Contains(DeclaracoesGeral.Conf.SeparadorCaboVeia) ? (text2 + DeclaracoesGeral.Conf.SeparadorCaboVeia + text3) : text3);
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								EditaUmBorne(ref tipoImportado, "NOME1", text);
							}
							if (clsBlocos.ExisteAtributo(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), "PAINEL"))
							{
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								EditaUmBorne(ref tipoImportado, "PAINEL", text2);
							}
							if (clsBlocos.ExisteAtributo(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), "REGUA"))
							{
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								EditaUmBorne(ref tipoImportado, "REGUA", text3);
							}
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							EditaUmBorne(ref tipoImportado, "ALTERNATIVO", sValor);
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

	public static void EditaUmBorne(ref string sHandle, string sAttributo, string sValor)
	{
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected Obj, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
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
						if (Operators.CompareString(val7.Tag.ToUpper(), sAttributo.ToUpper(), TextCompare: true) == 0)
						{
							((DBObject)val7).UpgradeOpen();
							((DBText)val7).TextString = sValor;
							break;
						}
					}
				}
				DeclaracoesGeral.bAnularEventos = true;
				val2.Commit();
				DeclaracoesGeral.bAnularEventos = false;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
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

	public static void EditarOsTodosOsBornesDasReguasSelecionada(DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected Obj, but got Unknown
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
		//IL_00bb: Expected Obj, but got Unknown
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected Obj, but got Unknown
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
						{
							continue;
						}
						DeclaracoesEntidades.StructureBorne structureBorne = default;
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						bool flag = false;
						bool flag2 = false;
						string text = "";
						string sValor = "";
						int num = Information.UBound(mBornes);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (Operators.CompareString(mBornes[i].Handle, ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) != 0)
							{
								continue;
							}
							structureBorne.Ordem = mBornes[i].Ordem;
							structureBorne.Numero = mBornes[i].Numero;
							structureBorne.Alternativo = mBornes[i].Alternativo;
							structureBorne.tipo = mBornes[i].tipo;
							structureBorne.lm = mBornes[i].lm;
							structureBorne.Orientacao = mBornes[i].Orientacao;
							structureBorne.BlocoLayout = mBornes[i].BlocoLayout;
							if (mBornes[i].NomePainel != null && structureBorne.IndiceRegua != mBornes[i].IndiceRegua)
							{
								structureBorne.IndiceRegua = mBornes[i].IndiceRegua;
								text = mBornes[i].NomePainel + DeclaracoesGeral.Conf.SeparadorPainelRegua + mBornes[i].NomeRegua;
								sValor = mBornes[i].NomeRegua;
								if (structureBorne.Visivel == 1)
								{
									text = mBornes[i].NomeRegua;
								}
								flag2 = true;
							}
							flag = true;
							break;
						}
						if (!flag)
						{
							continue;
						}
						blockRef = (BlockReference)ent;
						XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
						ent = (Entity)(object)blockRef;
						string sValor2 = structureBorne.Numero;
						if (Operators.CompareString(structureBorne.Numero, "0", TextCompare: true) == 0)
						{
							sValor2 = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
						}
						tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
						clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "T1", sValor2);
						if (flag2)
						{
							if (Operators.CompareString(text, "", TextCompare: true) != 0)
							{
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "NOME1", text);
							}
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "REGUA", sValor);
						}
						if (Operators.CompareString(structureBorne.Alternativo, "", TextCompare: true) != 0)
						{
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "ALTERNATIVO", structureBorne.Alternativo);
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

	public static void EditarOsTodosOsBornesMigradosDasReguaSelecionada(DeclaracoesEntidades.StructureBorne[] mBornes, string sReguaAntiga)
	{
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_0397: Expected Obj, but got Unknown
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
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected Obj, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0346: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
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
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
						{
							continue;
						}
						DeclaracoesEntidades.StructureBorne structureBorne = default;
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						bool flag = false;
						bool flag2 = false;
						string text = "";
						int num = Information.UBound(mBornes);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (Operators.CompareString(mBornes[i].Handle, ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), TextCompare: true) == 0)
							{
								structureBorne.Ordem = mBornes[i].Ordem;
								structureBorne.Numero = mBornes[i].Numero;
								structureBorne.Alternativo = mBornes[i].Alternativo;
								structureBorne.tipo = mBornes[i].tipo;
								structureBorne.lm = mBornes[i].lm;
								structureBorne.Orientacao = mBornes[i].Orientacao;
								structureBorne.BlocoLayout = mBornes[i].BlocoLayout;
								if (mBornes[i].NomePainel != null && structureBorne.IndiceRegua != mBornes[i].IndiceRegua)
								{
									structureBorne.IndiceRegua = mBornes[i].IndiceRegua;
									text = mBornes[i].NomeRegua;
									flag2 = true;
								}
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							continue;
						}
						blockRef = (BlockReference)ent;
						XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
						ent = (Entity)(object)blockRef;
						tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
						clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "T1", DeclaracoesGeral.Conf.CaracterTerminalIndefinido);
						if (flag2)
						{
							if (!clsBlocos.ExisteAtributo(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString(), "REGUA"))
							{
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								string text2 = clsBlocos.LeUmAtributoDeUmBloco(ref tipoImportado, "NOME1");
								text2 = text2.Replace(sReguaAntiga, text);
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "NOME1", text2);
							}
							else
							{
								tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								clsBlocos.AtualizaValorDeUmAtributo(ref tipoImportado, "REGUA", text);
							}
						}
						if (Operators.CompareString(structureBorne.Alternativo, "", TextCompare: true) != 0)
						{
							tipoImportado = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
							clsBlocos.EditaUmAtributoDeUmBloco(ref tipoImportado, "ALTERNATIVO", structureBorne.Alternativo);
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

	public static void ApagaOsBornesDasReguasExcluidas(Declaracoes2.StructureModeloDeReguas[] mModeloDeReguasNovos)
	{
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected Obj, but got Unknown
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
		//IL_00bb: Expected Obj, but got Unknown
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
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
						{
							continue;
						}
						DeclaracoesEntidades.StructureBorne structureBorne = default;
						BlockReference blockRef = (BlockReference)ent;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						ent = (Entity)(object)blockRef;
						structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						bool flag = true;
						int num = Information.UBound(mModeloDeReguasNovos);
						for (int i = 1; i <= num; i = checked(i + 1))
						{
							if (mModeloDeReguasNovos[i].indexRegua == structureBorne.IndiceRegua)
							{
								flag = false;
								break;
							}
						}
						if (flag)
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

	public static void capturaTodosOsBornesDoDesenho(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes)
	{
		//IL_0407: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Expected Obj, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected Obj, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				DeclaracoesGeral.Reguas RH = default;
				DeclaracoesGeral.Reguas RH2 = default;
				XDataGeral.LeXDataReguaH(ref RH);
				XDataGeral.LeXDataReguaV(ref RH2);
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					DeclaracoesEntidades.StructureBorne structureBorne = default;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							if ((indexRegua == structureBorne.IndiceRegua) | (indexRegua == -1))
							{
								int num = Information.UBound(mBornes) + 1;
								mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num + 1]);
								mBornes[num] = structureBorne;
								if (Operators.CompareString(mBornes[num].NumeroComplem, "", TextCompare: true) != 0)
								{
									ref string numero = ref mBornes[num].Numero;
									numero = numero + DeclaracoesGeral.Conf.SeparadorPainelRegua + mBornes[num].NumeroComplem;
								}
								if (Operators.CompareString(mBornes[num].Numero, "0", TextCompare: true) == 0)
								{
									mBornes[num].Numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
								mBornes[num].IndiceRegua = structureBorne.IndiceRegua;
								mBornes[num].Alternativo = clsTextos.TiraNothing(mBornes[num].Alternativo);
								mBornes[num].reserva = false;
								mBornes[num].Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								mBornes[num].pagina = ent.Layer.ToString();
								mBornes[num].lm = structureBorne.lm;
								mBornes[num].Orientacao = structureBorne.Orientacao;
								mBornes[num].BlocoLayout = structureBorne.BlocoLayout;
								mBornes[num].sPagina = Conversions.ToString(Pagina.calculaPaginaDecimal(ent.Layer.ToString()));
								mBornes[num].PosInt_Jumper = structureBorne.PosInt_Jumper;
								BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (val5 != null)
								{
									ref DeclaracoesEntidades.StructureBorne reference = ref mBornes[num];
									Point3d position = val5.Position;
									reference.iLinha = (int)Math.Round(Math.Round(position.X, 1));
									ref DeclaracoesEntidades.StructureBorne reference2 = ref mBornes[num];
									position = val5.Position;
									reference2.iColuna = (int)Math.Round(Math.Round(position.Y, 1));
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					int num2 = Information.UBound(mBornes);
					for (int i = 0; i <= num2; i++)
					{
						int num3 = Information.UBound(mBornes) - 1;
						for (int j = num3; j >= 0; j += -1)
						{
							if (mBornes[j].Ordem > mBornes[j + 1].Ordem)
							{
								DeclaracoesEntidades.StructureBorne structureBorne2 = default;
								structureBorne2 = mBornes[j + 1];
								mBornes[j + 1] = mBornes[j];
								mBornes[j] = structureBorne2;
							}
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

	public static void capturaOutrosBornesDoDesenhoNaoSel(int indexRegua, ref DeclaracoesEntidades.StructureBorne[] mBornes, List<string> sHandleBornes, ref int iMaiorOrdem)
	{
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected Obj, but got Unknown
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected Obj, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected Obj, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Expected Obj, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		checked
		{
			try
			{
				DeclaracoesGeral.Reguas RH = default;
				bool flag = false;
				DeclaracoesGeral.Reguas RH2 = default;
				bool flag2 = false;
				flag = XDataGeral.LeXDataReguaH(ref RH);
				flag2 = XDataGeral.LeXDataReguaV(ref RH2);
				iMaiorOrdem = 0;
				Database database = Application.DocumentManager.MdiActiveDocument.Database;
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					DeclaracoesEntidades.StructureBorne structureBorne = default;
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0 || sHandleBornes.Contains(((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								continue;
							}
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							if (indexRegua == structureBorne.IndiceRegua)
							{
								int num = Information.UBound(mBornes) + 1;
								mBornes = (DeclaracoesEntidades.StructureBorne[])Utils.CopyArray(mBornes, new DeclaracoesEntidades.StructureBorne[num + 1]);
								mBornes[num] = structureBorne;
								if (Operators.CompareString(mBornes[num].NumeroComplem, "", TextCompare: true) != 0)
								{
									ref string numero = ref mBornes[num].Numero;
									numero = numero + DeclaracoesGeral.Conf.SeparadorPainelRegua + mBornes[num].NumeroComplem;
								}
								if (Operators.CompareString(mBornes[num].Numero, "0", TextCompare: true) == 0)
								{
									mBornes[num].Numero = DeclaracoesGeral.Conf.CaracterTerminalIndefinido;
								}
								if ((double)iMaiorOrdem < structureBorne.Ordem)
								{
									iMaiorOrdem = (int)Math.Round(structureBorne.Ordem + 1.0);
								}
								mBornes[num].Alternativo = clsTextos.TiraNothing(mBornes[num].Alternativo);
								mBornes[num].reserva = false;
								mBornes[num].Handle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								mBornes[num].pagina = Pagina.montaCruzamentoPagina(ent.Layer.ToString(), Pagina.calculaLinhaColuna(ref ent, ref RH, ref RH2, flag, flag2));
								mBornes[num].lm = structureBorne.lm;
								mBornes[num].Orientacao = structureBorne.Orientacao;
								mBornes[num].BlocoLayout = structureBorne.BlocoLayout;
								mBornes[num].sPagina = Conversions.ToString(Pagina.calculaPaginaDecimal(ent.Layer.ToString()));
								BlockReference val5 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
								if (val5 != null)
								{
									ref DeclaracoesEntidades.StructureBorne reference = ref mBornes[num];
									Point3d position = val5.Position;
									reference.iLinha = (int)Math.Round(Math.Round(position.X, 0));
									ref DeclaracoesEntidades.StructureBorne reference2 = ref mBornes[num];
									position = val5.Position;
									reference2.iColuna = (int)Math.Round(Math.Round(position.Y, 0));
								}
							}
						}
					}
					finally
					{
						((IDisposable)enumerator)?.Dispose();
					}
					if (Information.UBound(mBornes) >= 2 && Information.UBound(mBornes) > 0)
					{
						int num2 = Information.UBound(mBornes);
						for (int i = 1; i <= num2; i++)
						{
							int num3 = Information.UBound(mBornes) - 1;
							int num4 = i;
							for (int j = num3; j >= num4; j += -1)
							{
								if (mBornes[j].Ordem > mBornes[j + 1].Ordem)
								{
									structureBorne = mBornes[j + 1];
									mBornes[j + 1] = mBornes[j];
									mBornes[j] = structureBorne;
								}
							}
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

	public static void AdicionaPotencialAosBornes(ref DeclaracoesEntidades.StructureBorne[] mBornes, frmGerenciadorReguasBornes.structureDadosFiacao[] mDadosFiacao)
	{
		if (Information.UBound(mBornes) < 2 || Information.UBound(mBornes) <= 0)
		{
			return;
		}
		int num = Information.UBound(mBornes);
		checked
		{
			for (int i = 1; i <= num; i++)
			{
				mBornes[i].Potencial = 9000000L;
				int num2 = Information.UBound(mDadosFiacao);
				for (int j = 1; j <= num2; j++)
				{
					if (Operators.CompareString(mBornes[i].Handle, mDadosFiacao[j].Handle, TextCompare: true) == 0)
					{
						mBornes[i].Potencial = mDadosFiacao[j].Potencial;
						break;
					}
				}
			}
		}
	}

	public static double BorneNumericoValido(string sBornes)
	{
		double result = 0.0;
		string text = "";
		string text2 = "";
		if (!Versioned.IsNumeric(sBornes))
		{
			text = Strings.Mid(sBornes, 1, checked(Strings.Len(sBornes) - 1));
			text2 = Strings.Mid(sBornes, Strings.Len(sBornes), Strings.Len(sBornes));
			if (!((Operators.CompareString(text.Trim(), "", TextCompare: true) == 0) & !Versioned.IsNumeric(text2)))
			{
				if (Versioned.IsNumeric(text) & !Versioned.IsNumeric(text2))
				{
					result = Conversions.ToDouble(text) + (double)Strings.Asc(text2) / 100.0;
				}
			}
			else
			{
				result = (double)Strings.Asc(text2) / 100.0;
			}
		}
		else
		{
			result = Conversions.ToDouble(sBornes);
		}
		return result;
	}

	public static void OrdenaReguaDeBornesPorPotencial(ref DataGridView dg, ref mBornes[] mBornes, string sOrdem)
	{
		mBornes = new mBornes[1];
		mBornes mBornes2 = default;
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				mBornes = (mBornes[])Utils.CopyArray(mBornes, new mBornes[i + 1]);
				mBornes[i]._0IndiceRegua = Conversions.ToInteger(dg.Rows[i].Cells[0].Value);
				mBornes[i]._1Ordem = Conversions.ToInteger(dg.Rows[i].Cells[1].Value);
				mBornes[i]._2Numero = Conversions.ToString(dg.Rows[i].Cells[2].Value);
				mBornes[i]._3Alternativo = Conversions.ToString(dg.Rows[i].Cells[3].Value);
				mBornes[i]._4Tipo = Conversions.ToString(dg.Rows[i].Cells[4].Value);
				mBornes[i]._5ListaDeMateriais = Conversions.ToInteger(dg.Rows[i].Cells[5].Value);
				mBornes[i]._6Pagina = Conversions.ToString(dg.Rows[i].Cells[6].Value);
				mBornes[i]._7Handle = Conversions.ToString(dg.Rows[i].Cells[7].Value);
				mBornes[i]._8NumeroOriginal = Conversions.ToString(dg.Rows[i].Cells[8].Value);
				mBornes[i]._9sPG = Conversions.ToDouble(dg.Rows[i].Cells[9].Value);
				mBornes[i]._10sLin = Conversions.ToDouble(dg.Rows[i].Cells[10].Value);
				mBornes[i]._11sCol = Conversions.ToDouble(dg.Rows[i].Cells[11].Value);
				mBornes[i]._12iPot = Conversions.ToInteger(dg.Rows[i].Cells[12].Value);
				mBornes[i]._13Cabo = Conversions.ToString(dg.Rows[i].Cells[13].Value);
				mBornes[i]._14Veia = Conversions.ToString(dg.Rows[i].Cells[14].Value);
				mBornes[i]._15Orientacao = Conversions.ToString(dg.Rows[i].Cells[15].Value);
				mBornes[i]._16Layout = Conversions.ToString(dg.Rows[i].Cells[16].Value);
				mBornes[i]._17NomeUnico = Conversions.ToString(dg.Rows[i].Cells[17].Value);
			}
			if (Information.UBound(mBornes) - 1 < 1)
			{
				return;
			}
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mBornes) * 5;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num2 = Information.UBound(mBornes) - 1;
			for (int j = 0; j <= num2; j++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				int num3 = Information.UBound(mBornes) - 1;
				for (int k = num3; k >= 0; k += -1)
				{
					if (mBornes[k]._12iPot > mBornes[k + 1]._12iPot)
					{
						mBornes2 = mBornes[k];
						mBornes[k] = mBornes[k + 1];
						mBornes[k + 1] = mBornes2;
					}
					if (mBornes[k]._12iPot == mBornes[k + 1]._12iPot && mBornes[k]._9sPG > mBornes[k + 1]._9sPG)
					{
						mBornes2 = mBornes[k];
						mBornes[k] = mBornes[k + 1];
						mBornes[k + 1] = mBornes2;
					}
					if (Operators.CompareString(sOrdem, "LC", TextCompare: true) != 0)
					{
						if (mBornes[k]._12iPot == mBornes[k + 1]._12iPot && mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._11sCol < mBornes[k + 1]._11sCol)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
						if (mBornes[k]._12iPot == mBornes[k + 1]._12iPot && mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._11sCol == mBornes[k + 1]._11sCol && mBornes[k]._10sLin > mBornes[k + 1]._10sLin)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
					}
					else
					{
						if (mBornes[k]._12iPot == mBornes[k + 1]._12iPot && mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._10sLin > mBornes[k + 1]._10sLin)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
						if (mBornes[k]._12iPot == mBornes[k + 1]._12iPot && mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._10sLin == mBornes[k + 1]._10sLin && mBornes[k]._11sCol < mBornes[k + 1]._11sCol)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
					}
				}
			}
			int num4 = 100000;
			int num5 = Information.UBound(mBornes);
			for (int l = 0; l <= num5; l++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				mBornes[l]._1Ordem = l + 1;
				if (Operators.ConditionalCompareObjectEqual(mBornes[l]._6Pagina, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num4++;
					mBornes[l]._1Ordem = num4;
				}
			}
			int num6 = Information.UBound(mBornes) - 1;
			for (int m = 0; m <= num6; m++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				int num7 = Information.UBound(mBornes) - 1;
				for (int n = num7; n >= 0; n += -1)
				{
					if (mBornes[n]._1Ordem > mBornes[n + 1]._1Ordem)
					{
						mBornes2 = mBornes[n];
						mBornes[n] = mBornes[n + 1];
						mBornes[n + 1] = mBornes2;
					}
				}
			}
			int num8 = Information.UBound(mBornes);
			for (int num9 = 0; num9 <= num8; num9++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				mBornes[num9]._1Ordem = num9 + 1;
				mBornes[num9]._2Numero = Conversions.ToString(num9 + 1);
			}
			frmGerenciadorReguasBornes.formataDgBornes(ref dg);
			int num10 = Information.UBound(mBornes);
			for (int num11 = 0; num11 <= num10; num11++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				dg.Rows.Add(mBornes[num11]._0IndiceRegua, mBornes[num11]._1Ordem, mBornes[num11]._2Numero, mBornes[num11]._3Alternativo, mBornes[num11]._4Tipo, mBornes[num11]._5ListaDeMateriais, mBornes[num11]._6Pagina, mBornes[num11]._7Handle, mBornes[num11]._8NumeroOriginal, mBornes[num11]._9sPG, mBornes[num11]._10sLin, mBornes[num11]._11sCol, mBornes[num11]._12iPot, mBornes[num11]._13Cabo, mBornes[num11]._14Veia, mBornes[num11]._15Orientacao, mBornes[num11]._16Layout, mBornes[num11]._17NomeUnico);
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void OrdenaReguaDeBornesPorPGPotencial(ref DataGridView dg, ref mBornes[] mBornes, string sOrdem)
	{
		int num = 0;
		mOrdem[] array = new mOrdem[1];
		num = -1;
		mOrdem[] array2 = new mOrdem[1];
		mBornes = new mBornes[1];
		mBornes mBornes2 = default;
		checked
		{
			int num2 = dg.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				mBornes = (mBornes[])Utils.CopyArray(mBornes, new mBornes[i + 1]);
				mBornes[i]._0IndiceRegua = Conversions.ToInteger(dg.Rows[i].Cells[0].Value);
				mBornes[i]._1Ordem = Conversions.ToInteger(dg.Rows[i].Cells[1].Value);
				mBornes[i]._2Numero = Conversions.ToString(dg.Rows[i].Cells[2].Value);
				mBornes[i]._3Alternativo = Conversions.ToString(dg.Rows[i].Cells[3].Value);
				mBornes[i]._4Tipo = Conversions.ToString(dg.Rows[i].Cells[4].Value);
				mBornes[i]._5ListaDeMateriais = Conversions.ToInteger(dg.Rows[i].Cells[5].Value);
				mBornes[i]._6Pagina = Conversions.ToString(dg.Rows[i].Cells[6].Value);
				mBornes[i]._7Handle = Conversions.ToString(dg.Rows[i].Cells[7].Value);
				mBornes[i]._8NumeroOriginal = Conversions.ToString(dg.Rows[i].Cells[8].Value);
				mBornes[i]._9sPG = 0.0;
				if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[9].Value)))
				{
					mBornes[i]._9sPG = Conversions.ToDouble(dg.Rows[i].Cells[9].Value);
				}
				mBornes[i]._10sLin = Conversions.ToDouble(dg.Rows[i].Cells[10].Value);
				mBornes[i]._11sCol = Conversions.ToDouble(dg.Rows[i].Cells[11].Value);
				mBornes[i]._12iPot = Conversions.ToInteger(dg.Rows[i].Cells[12].Value);
				mBornes[i]._13Cabo = Conversions.ToString(dg.Rows[i].Cells[13].Value);
				mBornes[i]._14Veia = Conversions.ToString(dg.Rows[i].Cells[14].Value);
				mBornes[i]._15Orientacao = Conversions.ToString(dg.Rows[i].Cells[15].Value);
				mBornes[i]._16Layout = Conversions.ToString(dg.Rows[i].Cells[16].Value);
				mBornes[i]._17NomeUnico = Conversions.ToString(dg.Rows[i].Cells[17].Value);
				array2 = (mOrdem[])Utils.CopyArray(array2, new mOrdem[i + 1]);
				array2[i].shandle = Conversions.ToString(dg.Rows[i].Cells[7].Value);
				array2[i].pagina = Conversions.ToDouble(dg.Rows[i].Cells[9].Value);
			}
			int num3 = Information.UBound(mBornes) - 1;
			for (int j = 0; j <= num3; j++)
			{
				int num4 = Information.UBound(mBornes) - 1;
				for (int k = num4; k >= 0; k += -1)
				{
					if (mBornes[k]._9sPG > mBornes[k + 1]._9sPG)
					{
						mBornes2 = mBornes[k];
						mBornes[k] = mBornes[k + 1];
						mBornes[k + 1] = mBornes2;
					}
					if (Operators.CompareString(sOrdem, "LC", TextCompare: true) != 0)
					{
						if (mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._11sCol < mBornes[k + 1]._11sCol)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
						if (mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._11sCol == mBornes[k + 1]._11sCol && mBornes[k]._10sLin > mBornes[k + 1]._10sLin)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
					}
					else
					{
						if (mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._10sLin > mBornes[k + 1]._10sLin)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
						if (mBornes[k]._9sPG == mBornes[k + 1]._9sPG && mBornes[k]._10sLin == mBornes[k + 1]._10sLin && mBornes[k]._11sCol < mBornes[k + 1]._11sCol)
						{
							mBornes2 = mBornes[k];
							mBornes[k] = mBornes[k + 1];
							mBornes[k + 1] = mBornes2;
						}
					}
				}
			}
			List<int> list = new List<int>();
			int num5 = Information.UBound(mBornes);
			for (int l = 0; l <= num5; l++)
			{
				if (!list.Contains(mBornes[l]._12iPot))
				{
					num++;
					array = (mOrdem[])Utils.CopyArray(array, new mOrdem[num + 1]);
					array[num].potencial = mBornes[l]._12iPot;
					array[num].pagina = mBornes[l]._9sPG;
					list.Add(mBornes[l]._12iPot);
					continue;
				}
				int num6 = Information.UBound(array);
				for (int m = 1; m <= num6; m++)
				{
					if (array[m].potencial == mBornes[l]._12iPot && array[m].pagina > mBornes[l]._9sPG)
					{
						array[m].pagina = mBornes[l]._9sPG;
					}
				}
			}
			mOrdem mOrdem2 = default;
			int num7 = Information.UBound(array) - 1;
			for (int n = 0; n <= num7; n++)
			{
				int num8 = Information.UBound(array) - 1;
				for (int num9 = num8; num9 >= 0; num9 += -1)
				{
					if (array[num9].pagina > array[num9 + 1].pagina)
					{
						mOrdem2 = array[num9];
						array[num9] = array[num9 + 1];
						array[num9 + 1] = mOrdem2;
					}
				}
			}
			int num10 = Information.UBound(array);
			for (int num11 = 0; num11 <= num10; num11++)
			{
				array[num11].ordem = num11;
			}
			int num12 = Information.UBound(array);
			for (int num13 = 0; num13 <= num12; num13++)
			{
				int num14 = Information.UBound(mBornes);
				for (int num15 = 0; num15 <= num14; num15++)
				{
					if (mBornes[num15]._12iPot == array[num13].potencial)
					{
						double num16 = mBornes[num15]._9sPG / 1000000.0;
						mBornes[num15]._9sPG = (double)array[num13].ordem + num16;
					}
				}
			}
			if (Information.UBound(mBornes) - 1 < 0)
			{
				return;
			}
			DeclaracoesGeral._uscPagina.Quantidade = Information.UBound(mBornes) * 5;
			DeclaracoesGeral._uscPagina.pbIniciar();
			int num17 = Information.UBound(mBornes) - 1;
			for (int num18 = 0; num18 <= num17; num18++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				int num19 = Information.UBound(mBornes) - 1;
				for (int num20 = num19; num20 >= 0; num20 += -1)
				{
					if (mBornes[num20]._9sPG > mBornes[num20 + 1]._9sPG)
					{
						mBornes2 = mBornes[num20];
						mBornes[num20] = mBornes[num20 + 1];
						mBornes[num20 + 1] = mBornes2;
					}
				}
			}
			int num21 = 100000;
			int num22 = Information.UBound(mBornes);
			for (int num23 = 0; num23 <= num22; num23++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				mBornes[num23]._1Ordem = num23 + 1;
				if (Operators.ConditionalCompareObjectEqual(mBornes[num23]._6Pagina, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num21++;
					mBornes[num23]._1Ordem = num21;
				}
			}
			int num24 = Information.UBound(mBornes) - 1;
			for (int num25 = 0; num25 <= num24; num25++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				int num26 = Information.UBound(mBornes) - 1;
				for (int num27 = num26; num27 >= 0; num27 += -1)
				{
					if (mBornes[num27]._1Ordem > mBornes[num27 + 1]._1Ordem)
					{
						mBornes2 = mBornes[num27];
						mBornes[num27] = mBornes[num27 + 1];
						mBornes[num27 + 1] = mBornes2;
					}
				}
			}
			int num28 = Information.UBound(mBornes);
			for (int num29 = 0; num29 <= num28; num29++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				mBornes[num29]._1Ordem = num29 + 1;
				mBornes[num29]._2Numero = Conversions.ToString(num29 + 1);
			}
			frmGerenciadorReguasBornes.formataDgBornes(ref dg);
			int num30 = Information.UBound(mBornes);
			for (int num31 = 0; num31 <= num30; num31++)
			{
				DeclaracoesGeral._uscPagina.pbPasso();
				dg.Rows.Add(mBornes[num31]._0IndiceRegua, mBornes[num31]._1Ordem, mBornes[num31]._2Numero, mBornes[num31]._3Alternativo, mBornes[num31]._4Tipo, mBornes[num31]._5ListaDeMateriais, mBornes[num31]._6Pagina, mBornes[num31]._7Handle, mBornes[num31]._8NumeroOriginal, mBornes[num31]._9sPG, mBornes[num31]._10sLin, mBornes[num31]._11sCol, mBornes[num31]._12iPot, mBornes[num31]._13Cabo, mBornes[num31]._14Veia, mBornes[num31]._15Orientacao, mBornes[num31]._16Layout, mBornes[num31]._17NomeUnico);
			}
			int num32 = dg.Rows.Count - 1;
			for (int num33 = 0; num33 <= num32; num33++)
			{
				int num34 = Information.UBound(mBornes);
				for (int num35 = 0; num35 <= num34; num35++)
				{
					if (Operators.ConditionalCompareObjectEqual(array2[num35].shandle, dg.Rows[num33].Cells[7].Value, TextCompare: true))
					{
						dg.Rows[num33].Cells[9].Value = array2[num35].pagina;
						break;
					}
				}
			}
			DeclaracoesGeral._uscPagina.pbFim();
		}
	}

	public static void OrdenaReguaDeBornesPorPotencial(ref DataGridView dg, string sCriterio)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add("Handle", typeof(string));
		dataTable.Columns.Add("Pagina", typeof(string));
		dataTable.Columns.Add("x", typeof(double));
		dataTable.Columns.Add("y", typeof(double));
		dataTable.Columns.Add("Borne", typeof(string));
		dataTable.Columns.Add("Potencial", typeof(int));
		checked
		{
			int num = dg.Rows.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				if (!Operators.ConditionalCompareObjectNotEqual(dg.Rows[i].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					dg.Rows[i].Cells[1].Value = 10000;
					dg.Rows[i].Cells[2].Value = 10000;
					continue;
				}
				DataRow dataRow = dataTable.NewRow();
				dataRow["Handle"] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[7].Value);
				dataRow["Pagina"] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[9].Value);
				dataRow["x"] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[10].Value);
				dataRow["y"] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[11].Value);
				dataRow["borne"] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[2].Value);
				dataRow["Potencial"] = RuntimeHelpers.GetObjectValue(dg.Rows[i].Cells[12].Value);
				dataTable.Rows.Add(dataRow);
			}
			List<int> list = new List<int>();
			string filterExpression = "Potencial < 10000";
			DataRow[] array = dataTable.Select(filterExpression, sCriterio);
			int upperBound = array.GetUpperBound(0);
			for (int j = 0; j <= upperBound; j++)
			{
				if (!list.Contains(Conversions.ToInteger(array[j][5])))
				{
					list.Add(Conversions.ToInteger(array[j][5]));
				}
			}
			int num2 = 1;
			int num3 = dg.Rows.Count - 1;
			for (int k = 0; k <= num3; k++)
			{
				dg.Rows[k].Cells[1].Value = 1;
				dg.Rows[k].Cells[2].Value = 1;
			}
			num2 = 10000;
			int num4 = dg.Rows.Count - 1;
			for (int l = 0; l <= num4; l++)
			{
				dg.Rows[l].Cells[1].Value = num2;
				num2++;
			}
			num2 = 1;
			int num5 = list.Count - 1;
			for (int m = 0; m <= num5; m++)
			{
				int num6 = dg.Rows.Count - 1;
				for (int n = 0; n <= num6; n++)
				{
					if (Operators.ConditionalCompareObjectEqual(list[m], dg.Rows[n].Cells[12].Value, TextCompare: true))
					{
						dg.Rows[n].Cells[1].Value = num2;
						dg.Rows[n].Cells[2].Value = num2;
						num2++;
					}
				}
			}
			int num7 = 0;
			int num8 = dg.Rows.Count - 1;
			for (int num9 = 0; num9 <= num8; num9++)
			{
				if (Operators.ConditionalCompareObjectEqual(dg.Rows[num9].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true))
				{
					num7++;
				}
			}
			if (dg.Rows.Count - 1 < 1)
			{
				return;
			}
			int num10 = dg.Rows.Count - 2 - num7;
			for (int num11 = 0; num11 <= num10; num11++)
			{
				int num12 = dg.Rows.Count - 2 - num7;
				for (int num13 = num12; num13 >= 0; num13 += -1)
				{
					if (Operators.ConditionalCompareObjectNotEqual(dg.Rows[num13].Cells[6].Value, DeclaracoesGeral.mMensagem[1, 1050], TextCompare: true) && Operators.ConditionalCompareObjectGreater(dg.Rows[num13].Cells[1].Value, dg.Rows[num13 + 1].Cells[1].Value, TextCompare: true))
					{
						int num14 = dg.ColumnCount - 1;
						for (int num15 = 0; num15 <= num14; num15++)
						{
							object objectValue = RuntimeHelpers.GetObjectValue(dg.Rows[num13].Cells[num15].Value);
							dg.Rows[num13].Cells[num15].Value = RuntimeHelpers.GetObjectValue(dg.Rows[num13 + 1].Cells[num15].Value);
							dg.Rows[num13 + 1].Cells[num15].Value = RuntimeHelpers.GetObjectValue(objectValue);
						}
					}
				}
			}
		}
	}

	public static bool SelecionaBornesParaEdicao(ref ordemBornes[] BornesSelecionadas, ref int indexModelo, ref double iMaiorOrdem)
	{
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Invalid comparison between Unknown and I4
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected Obj, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected Obj, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Expected Obj, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		indexModelo = 0;
		int num = 0;
		BornesSelecionadas = new ordemBornes[1];
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
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				TypedValue[] array = new TypedValue[2];
				array.SetValue((object)new TypedValue(0, (object)"INSERT"), 0);
				array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 1);
				SelectionFilter val4 = new SelectionFilter(array);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1370]);
				PromptSelectionResult selection = editor.GetSelection(val5, val4);
				if ((int)selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
					string text = selection.ToString().ToUpper();
					if (!text.Contains("CROSSING"))
					{
					}
					new ObjectIdCollection();
					new List<double>();
					checked
					{
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent = (Entity)val7.GetObject((OpenMode)0);
							if (Operators.CompareString(ent.Layer, DeclaracoesGeral.ativo.Pagina, TextCompare: true) != 0)
							{
								continue;
							}
							BlockReference val8 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val8 == null)
							{
								continue;
							}
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) != 0)
							{
								continue;
							}
							DeclaracoesEntidades.StructureBorne structureBorne = default;
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							if (indexModelo == 0)
							{
								indexModelo = structureBorne.IndiceRegua;
							}
							if (indexModelo == structureBorne.IndiceRegua)
							{
								num++;
								BornesSelecionadas = (ordemBornes[])Utils.CopyArray(BornesSelecionadas, new ordemBornes[num + 1]);
								BornesSelecionadas[num].sHandle = ((object)((DBObject)ent).Handle/*cast due to constrained. prefix*/).ToString();
								ref ordemBornes reference = ref BornesSelecionadas[num];
								Point3d position = val8.Position;
								reference.dX = Math.Round(position.X, 0);
								ref ordemBornes reference2 = ref BornesSelecionadas[num];
								position = val8.Position;
								reference2.dY = Math.Round(position.Y, 0);
								BornesSelecionadas[num].indexRegua = structureBorne.IndiceRegua;
								BornesSelecionadas[num].iOrdemSelecao = num;
								BornesSelecionadas[num].Ordem = structureBorne.Ordem;
								BornesSelecionadas[num].Nome = structureBorne.Numero;
								BornesSelecionadas[num].Alternativo = structureBorne.Alternativo;
								BornesSelecionadas[num].Tipo = structureBorne.tipo;
								BornesSelecionadas[num].Lm = structureBorne.lm;
								BornesSelecionadas[num].Orientacao = structureBorne.Orientacao;
								BornesSelecionadas[num].Layout = structureBorne.BlocoLayout;
								if (iMaiorOrdem < structureBorne.Ordem)
								{
									iMaiorOrdem = structureBorne.Ordem;
								}
								result = true;
							}
						}
						DeclaracoesGeral.bAnularEventos = true;
						val2.Commit();
						DeclaracoesGeral.bAnularEventos = false;
					}
				}
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
		return result;
	}

	public static void ocultarBornesSelecionados()
	{
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected Obj, but got Unknown
		//IL_01c4: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected Obj, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Expected Obj, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Expected Obj, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Invalid comparison between Unknown and I4
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected Obj, but got Unknown
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected Obj, but got Unknown
		PointMonitorToolTips.StopMonitor();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				_ = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				TypedValue[] array = new TypedValue[1];
				array.SetValue((object)new TypedValue(1001, (object)"DISPOSITIVO"), 0);
				SelectionFilter val4 = new SelectionFilter(array);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 1505]);
				PromptSelectionResult selection = editor.GetSelection(val5, val4);
				if ((int)selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
					if (val6.Count != 0)
					{
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity ent = (Entity)val7.GetObject((OpenMode)0);
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
							{
								((DBObject)ent).UpgradeOpen();
								ent.Visible = false;
							}
						}
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
				((IDisposable)val2)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		PointMonitorToolTips.StartMonitor();
	}

	public static void ligarBornesPagina(string layer)
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected Obj, but got Unknown
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
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0 && Operators.CompareString(ent.Layer.ToString(), layer, TextCompare: true) == 0 && !ent.Visible)
							{
								((DBObject)ent).UpgradeOpen();
								ent.Visible = true;
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

	public static string calculaBorneNumericoDecimal(string pagina)
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected Obj, but got Unknown
		string result = pagina;
		try
		{
			string text = "";
			string text2 = "";
			if (!Versioned.IsNumeric(pagina))
			{
				text2 = Strings.Mid(pagina, 1, checked(Strings.Len(pagina) - 1));
				if (Versioned.IsNumeric(text2))
				{
					text = Strings.Mid(pagina, Strings.Len(pagina), 1);
					if ((Strings.Asc(text) >= 65) & (Strings.Asc(text) <= 90))
					{
						result = Conversions.ToString(Conversions.ToDouble(text2) + (double)Strings.Asc(text) / 100.0);
					}
				}
			}
			else
			{
				result = pagina;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError((Exception)ex);
			throw;
		}
		return result;
	}

	public static void MudaOrdemDeUmBorne(string sHandle, int iOrdem)
	{
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected Obj, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				ObjectId val3 = Geral.HandleToID(sHandle);
				if (val3.IsValid)
				{
					Entity val4 = (Entity)val2.GetObject(val3, (OpenMode)1);
					DeclaracoesEntidades.StructureBorne structureBorne = default;
					BlockReference blockRef = (BlockReference)val4;
					object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
					val4 = (Entity)(object)blockRef;
					structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
					structureBorne.Ordem = iOrdem;
					blockRef = (BlockReference)val4;
					XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
					val4 = (Entity)(object)blockRef;
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

	public static void buscaTipoLm(ref int iRegua, ref int iLm, ref int itipo)
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected Obj, but got Unknown
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
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
					BlockTableRecordEnumerator enumerator = default;
					try
					{
						enumerator = val4.GetEnumerator();
						while (enumerator.MoveNext())
						{
							ObjectId current = enumerator.Current;
							Entity ent = (Entity)val2.GetObject(current, (OpenMode)0);
							string tipoImportado = "";
							if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
							{
								DeclaracoesEntidades.StructureBorne structureBorne = default;
								BlockReference blockRef = (BlockReference)ent;
								object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
								ent = (Entity)(object)blockRef;
								structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
								if (structureBorne.IndiceRegua == iRegua && structureBorne.Ordem == 1.0)
								{
									iLm = structureBorne.lm;
									itipo = structureBorne.tipo;
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
				catch (Exception ex)
				{
					ProjectData.SetProjectError((Exception)ex);
					val2.Abort();
					throw;
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

	public static bool SelecioanBorne(ref int iPainel, ref int iRegua, ref string sNomeBloco)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected Obj, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		_ = Application.DocumentManager.MdiActiveDocument.Editor;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			try
			{
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				Point3d ptInsert = default;
				ObjectId val2 = clsAtributos.selPonto(ref ptInsert, "B");
				if (!val2.IsNull)
				{
					Entity ent = (Entity)val.GetObject(val2, (OpenMode)0);
					if (!Information.IsDBNull(ent))
					{
						string tipoImportado = "";
						if (Operators.CompareString(XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado), "B", TextCompare: true) == 0)
						{
							DeclaracoesEntidades.StructureBorne structureBorne = default;
							BlockReference blockRef = (BlockReference)ent;
							object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
							ent = (Entity)(object)blockRef;
							structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
							iPainel = structureBorne.indexPainel;
							iRegua = structureBorne.IndiceRegua;
							BlockReference val3 = (BlockReference)(object)((ent is BlockReference) ? ent : null);
							if (val3 != null)
							{
								sNomeBloco = val3.Name;
							}
							result = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError((Exception)ex);
				result = false;
				ProjectData.ClearProjectError();
			}
			DeclaracoesGeral.bAnularEventos = true;
			val.Commit();
			DeclaracoesGeral.bAnularEventos = false;
			return result;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static void PositivoInterno(List<string> lHandles, string valor)
	{
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected Obj, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			_ = Application.DocumentManager.MdiActiveDocument.Editor;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				foreach (string lHandle in lHandles)
				{
					ObjectId val3 = Geral.HandleToID(lHandle);
					if (val3.IsValid)
					{
						Entity val4 = (Entity)val2.GetObject(val3, (OpenMode)1);
						DeclaracoesEntidades.StructureBorne structureBorne = default;
						BlockReference blockRef = (BlockReference)val4;
						object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
						val4 = (Entity)(object)blockRef;
						structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
						structureBorne.PosInt_Jumper = valor;
						blockRef = (BlockReference)val4;
						XDataDispositivosMaster.GravarXDataDispBorne(ref blockRef, ref structureBorne);
						val4 = (Entity)(object)blockRef;
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

	public static bool SelecionaBornesECircuitosParaEdicao(ref ordemBornes[] BornesSelecionadas, ref List<string> lHandPot, ref int indexModelo, ref double iMaiorOrdem)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0565: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected Obj, but got Unknown
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected Obj, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Invalid comparison between Unknown and I4
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0208: Expected Obj, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Obj, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Expected Obj, but got Unknown
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected Obj, but got Unknown
		//IL_02fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Expected Obj, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		indexModelo = 0;
		int num = 0;
		BornesSelecionadas = new ordemBornes[1];
		bool result = false;
		lHandPot.Clear();
		List<string> list = new List<string>();
		int num2 = 0;
		List<int> list2 = new List<int>();
		new ObjectIdCollection();
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)0);
				Editor editor = Application.DocumentManager.MdiActiveDocument.Editor;
				hDTV5h3NAKArXvSEL1u.lwF3Qy6iqF(Application.DocumentManager.MdiActiveDocument.Window.Handle);
				PromptSelectionOptions val5 = new PromptSelectionOptions();
				val5.MessageForAdding = Conversions.ToString(DeclaracoesGeral.mMensagem[1, 886]);
				PromptSelectionResult selection = editor.GetSelection(val5);
				if ((int)selection.Status == 5100)
				{
					SelectionSet value = selection.Value;
					ObjectIdCollection val6 = new ObjectIdCollection(value.GetObjectIds());
					checked
					{
						foreach (object item in val6)
						{
							ObjectId val7 = ((item == null) ? default(ObjectId) : ((ObjectId)item));
							Entity val8 = (Entity)val7.GetObject((OpenMode)0);
							try
							{
								BlockReference val9 = (BlockReference)(object)((val8 is BlockReference) ? val8 : null);
								if (val9 != null)
								{
									Entity ent = (Entity)(object)val9;
									string tipoImportado = "";
									string left = XDataDispositivo.verificaTipoDispositivo(ref ent, ref tipoImportado);
									val9 = (BlockReference)ent;
									if (Operators.CompareString(left, "B", TextCompare: true) == 0)
									{
										DeclaracoesEntidades.StructureBorne structureBorne = default;
										BlockReference blockRef = (BlockReference)val8;
										object obj = XDataDispositivosMaster.LeXDataQualquerDispositivo(ref blockRef);
										structureBorne = ((obj == null) ? default(DeclaracoesEntidades.StructureBorne) : ((DeclaracoesEntidades.StructureBorne)obj));
										structureBorne.indexPainel = DicionarioBorne.BuscaPainelDoBorneNoDicionario(ref structureBorne.IndiceRegua, ref structureBorne.NomeRegua, ref structureBorne.Alternativo);
										if (num2 == 0)
										{
											num2 = structureBorne.indexPainel;
										}
										if (num2 == structureBorne.indexPainel)
										{
											if (indexModelo == 0)
											{
												indexModelo = structureBorne.IndiceRegua;
											}
											if (indexModelo == structureBorne.IndiceRegua)
											{
												num++;
												BornesSelecionadas = (ordemBornes[])Utils.CopyArray(BornesSelecionadas, new ordemBornes[num + 1]);
												list.Add(((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString());
												BornesSelecionadas[num].sHandle = ((object)((DBObject)val8).Handle/*cast due to constrained. prefix*/).ToString();
												ref ordemBornes reference = ref BornesSelecionadas[num];
												Point3d position = val9.Position;
												reference.dX = Math.Round(position.X, 0);
												ref ordemBornes reference2 = ref BornesSelecionadas[num];
												position = val9.Position;
												reference2.dY = Math.Round(position.Y, 0);
												BornesSelecionadas[num].indexRegua = structureBorne.IndiceRegua;
												BornesSelecionadas[num].iOrdemSelecao = num;
												BornesSelecionadas[num].Ordem = structureBorne.Ordem;
												BornesSelecionadas[num].Nome = structureBorne.Numero;
												BornesSelecionadas[num].Alternativo = structureBorne.Alternativo;
												BornesSelecionadas[num].Tipo = structureBorne.tipo;
												BornesSelecionadas[num].Lm = structureBorne.lm;
												BornesSelecionadas[num].Orientacao = structureBorne.Orientacao;
												BornesSelecionadas[num].Layout = structureBorne.BlocoLayout;
												if (iMaiorOrdem < structureBorne.Ordem)
												{
													iMaiorOrdem = structureBorne.Ordem;
												}
												result = true;
											}
										}
									}
								}
								Polyline val10 = (Polyline)(object)((val8 is Polyline) ? val8 : null);
								try
								{
									DeclaracoesEntidades.StructureConexao conex = default;
									if (val10 == null)
									{
										continue;
									}
									Polyline pl = val10;
									if (XDataConexao.lerXDataConexao(ref pl, ref conex))
									{
										if (num2 == 0)
										{
											num2 = conex.Painel;
										}
										if (num2 == conex.Painel && !list2.Contains(conex.Potencial))
										{
											list2.Add(conex.Potencial);
										}
									}
								}
								finally
								{
									((IDisposable)val10)?.Dispose();
								}
							}
							finally
							{
								((IDisposable)val8)?.Dispose();
							}
						}
					}
				}
				clsBlocos.Unhighlight();
				BlockTableRecordEnumerator enumerator2 = default;
				try
				{
					enumerator2 = val4.GetEnumerator();
					while (enumerator2.MoveNext())
					{
						ObjectId current2 = enumerator2.Current;
						Entity val11 = (Entity)current2.GetObject((OpenMode)0);
						Polyline pl2 = (Polyline)(object)((val11 is Polyline) ? val11 : null);
						DeclaracoesEntidades.StructureConexao conex2 = default;
						if (pl2 == null)
						{
							BlockReference val12 = (BlockReference)(object)((val11 is BlockReference) ? val11 : null);
							new Point3d(0.0, 0.0, 0.0);
							if (val12 != null && list.Contains(((object)((DBObject)val12).Handle/*cast due to constrained. prefix*/).ToString()))
							{
								val11.Highlight();
							}
						}
						else if (XDataConexao.lerXDataConexao(ref pl2, ref conex2) && list2.Contains(conex2.Potencial))
						{
							lHandPot.Add(((object)((DBObject)pl2).Handle/*cast due to constrained. prefix*/).ToString());
							val11.Highlight();
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
}

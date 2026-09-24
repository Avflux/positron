using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class XDataDispositivosMaster
{
	public static void GravarXDataDispPrincipal(ref BlockReference blockRef, ref DeclaracoesEntidades.StructureDispositivo disp)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Expected Obj, but got Unknown
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_0316: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected Obj, but got Unknown
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Dispositivo"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Dispositivo";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[29]
				{
					new TypedValue(1001, (object)"Dispositivo"),
					new TypedValue(1000, (object)"P"),
					new TypedValue(1000, (object)disp.Nome1),
					new TypedValue(1000, (object)disp.Nome2),
					new TypedValue(1000, (object)disp.Alternativo),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1040, (object)0),
					new TypedValue(1070, (object)disp.Painel),
					new TypedValue(1070, (object)0),
					new TypedValue(1070, (object)0),
					new TypedValue(1000, (object)disp.ChavePrimaria),
					new TypedValue(1071, (object)disp.indexModelo),
					new TypedValue(1070, (object)(0 - (disp.Complementar ? 1 : 0))),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)disp.Layout),
					new TypedValue(1000, (object)disp.Topografico),
					default,
					default,
					default,
					default,
					default,
					default,
					default,
					default,
					default,
					default
				};
				Point3d val5 = new Point3d(disp.posX, disp.posY, 0.0);
				array[19] = new TypedValue(1011, (object)val5);
				array[20] = new TypedValue(1040, (object)disp.dAlturaModelo);
				array[21] = new TypedValue(1071, (object)disp.iLM1);
				array[22] = new TypedValue(1070, (object)0);
				array[23] = new TypedValue(1071, (object)disp.iLM2);
				array[24] = new TypedValue(1000, (object)Environment.UserName);
				array[25] = new TypedValue(1000, (object)DateTime.Now.ToString());
				array[26] = new TypedValue(1040, (object)0);
				double num = 0.0;
				if (disp.NomeVisivel)
				{
					num = 1.0;
				}
				if (disp.AlternativoVisivel)
				{
					num += 0.1;
				}
				array[27] = new TypedValue(1040, (object)num);
				array[28] = new TypedValue(1040, (object)disp.distContAux);
				((DBObject)blockRef).UpgradeOpen();
				((DBObject)blockRef).XData = new ResultBuffer(array);
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

	public static void GravarXDataDispAuxiliar(ref BlockReference blockRef, ref DeclaracoesEntidades.StructureAuxiliar Aux)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0234: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Dispositivo"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Dispositivo";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[18]
				{
					new TypedValue(1001, (object)"Dispositivo"),
					new TypedValue(1000, (object)"A"),
					new TypedValue(1000, (object)Aux.Nome1.ToString()),
					new TypedValue(1000, (object)Aux.Nome2.ToString()),
					new TypedValue(1000, (object)Aux.HandleBob.ToString()),
					new TypedValue(1071, (object)Aux.IndexModelo),
					new TypedValue(1071, (object)Aux.IndexContato),
					new TypedValue(1070, (object)(int)Aux.TipoDoContato),
					new TypedValue(1070, (object)(int)Aux.TipoDoComportamento),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)Aux.Alternativo.ToString()),
					new TypedValue(1040, (object)0.0),
					new TypedValue(1040, (object)0.0),
					new TypedValue(1071, (object)0),
					new TypedValue(1071, (object)0),
					new TypedValue(1000, (object)Environment.UserName),
					new TypedValue(1000, (object)DateTime.Now.ToString())
				};
				((DBObject)blockRef).UpgradeOpen();
				((DBObject)blockRef).XData = new ResultBuffer(array);
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

	public static void GravarXDataDispBorne(ref BlockReference blockRef, ref DeclaracoesEntidades.StructureBorne Borne)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected Obj, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				if (Borne.lm == 0)
				{
					ref int indiceRegua = ref Borne.IndiceRegua;
					ref int tipo = ref Borne.tipo;
					string stipo = Conversions.ToString(tipo);
					int lm = DicionarioBorne.BuscaLMdaRegua(ref indiceRegua, ref stipo);
					tipo = Conversions.ToInteger(stipo);
					Borne.lm = lm;
				}
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Dispositivo"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Dispositivo";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[18]
				{
					new TypedValue(1001, (object)"Dispositivo"),
					new TypedValue(1000, (object)"B"),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)Borne.PosInt_Jumper),
					new TypedValue(1000, (object)Borne.BlocoLayout),
					new TypedValue(1000, (object)(Borne.Numero + Borne.NumeroComplem)),
					new TypedValue(1000, (object)""),
					new TypedValue(1040, (object)Borne.Ordem),
					new TypedValue(1071, (object)Borne.IndiceRegua),
					new TypedValue(1000, (object)Borne.conector),
					new TypedValue(1000, (object)Borne.lm.ToString()),
					new TypedValue(1000, (object)Borne.Orientacao),
					new TypedValue(1040, (object)0.0),
					new TypedValue(1040, (object)0.0),
					new TypedValue(1071, (object)Borne.tipo),
					new TypedValue(1071, (object)Borne.Visivel),
					new TypedValue(1000, (object)Environment.UserName),
					new TypedValue(1000, (object)DateTime.Now.ToString())
				};
				((DBObject)blockRef).UpgradeOpen();
				((DBObject)blockRef).XData = new ResultBuffer(array);
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

	public static void GravarXDataPorta(ref Entity ent, ref DeclaracoesEntidades.StructurePortas Porta)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Dispositivo"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Dispositivo";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[18]
				{
					new TypedValue(1001, (object)"Dispositivo"),
					new TypedValue(1000, (object)"E"),
					new TypedValue(1000, (object)Porta.Nome1.ToString()),
					new TypedValue(1000, (object)Porta.Nome2.ToString()),
					new TypedValue(1000, (object)Porta.HandleDaMascara),
					new TypedValue(1071, (object)Porta.indiceDoModelo),
					new TypedValue(1071, (object)Porta.indiceDaPorta),
					new TypedValue(1070, (object)0),
					new TypedValue(1070, (object)0),
					new TypedValue(1000, (object)Porta.handleDaDefinicao),
					new TypedValue(1000, (object)Porta.chavePrimaria),
					new TypedValue(1000, (object)Porta.Alternativo),
					new TypedValue(1040, (object)0),
					new TypedValue(1040, (object)0),
					new TypedValue(1071, (object)0),
					new TypedValue(1071, (object)0),
					new TypedValue(1000, (object)Environment.UserName),
					new TypedValue(1000, (object)DateTime.Now.ToString())
				};
				((DBObject)ent).UpgradeOpen();
				((DBObject)ent).XData = new ResultBuffer(array);
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

	public static void GravarXDataMascara(ref Entity ent, ref DeclaracoesEntidades.StructureMascara Masc)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_034e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b8: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Dispositivo"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Dispositivo";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[29]
				{
					new TypedValue(1001, (object)"Dispositivo"),
					new TypedValue(1000, (object)"M"),
					new TypedValue(1000, (object)Masc.Nome1.ToString()),
					new TypedValue(1000, (object)Masc.Nome2.ToString()),
					new TypedValue(1000, (object)Masc.Alternativo.ToString()),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1040, (object)0),
					new TypedValue(1070, (object)Masc.Painel),
					new TypedValue(1070, (object)0),
					new TypedValue(1070, (object)0),
					new TypedValue(1000, (object)""),
					new TypedValue(1071, (object)Masc.indexModelo),
					new TypedValue(1070, (object)(0 - (Masc.Complementar ? 1 : 0))),
					new TypedValue(1000, (object)Masc.HandleMascPrincipal.ToString()),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)Masc.Topografico),
					new TypedValue(1000, (object)Masc.Layout),
					new TypedValue(1000, (object)""),
					default,
					default,
					default,
					default,
					default,
					default,
					default,
					default,
					default,
					default
				};
				Point3d val5 = new Point3d(0.0, 0.0, 0.0);
				array[19] = new TypedValue(1011, (object)val5);
				array[20] = new TypedValue(1040, (object)0);
				array[21] = new TypedValue(1071, (object)Masc.iLM1);
				array[22] = new TypedValue(1070, (object)0);
				array[23] = new TypedValue(1071, (object)Masc.iLM2);
				array[24] = new TypedValue(1000, (object)Environment.UserName);
				array[25] = new TypedValue(1000, (object)DateTime.Now.ToString());
				array[26] = new TypedValue(1040, (object)0);
				array[27] = new TypedValue(1040, (object)0);
				array[28] = new TypedValue(1040, (object)0);
				((DBObject)ent).UpgradeOpen();
				((DBObject)ent).XData = new ResultBuffer(array);
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

	public static void GravarXDataAuxBornes(ref Polyline pl)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("AUXBORNES"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "AUXBORNES";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[2]
				{
					new TypedValue(1001, (object)"AUXBORNES"),
					new TypedValue(1000, (object)"")
				};
				((DBObject)pl).UpgradeOpen();
				((DBObject)pl).XData = new ResultBuffer(array);
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

	public static bool LerXDataAuxBornes(ref Entity Ent)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("AUXBORNES");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("AUXBORNES");
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			result = true;
			TypedValue[] array = val.AsArray();
			result = Operators.CompareString(array[0].Value.ToString().ToUpper(), "AUXBORNES", TextCompare: true) == 0;
		}
		return result;
	}

	public static object LeXDataQualquerDispositivo(ref BlockReference blockRef)
	{
		//IL_05bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		object result = null;
		bool flag = false;
		ResultBuffer val = null;
		if (blockRef != null)
		{
			val = ((DBObject)blockRef).GetXDataForApplication("Dispositivo");
			if (val == null)
			{
				val = ((DBObject)blockRef).GetXDataForApplication("DISPOSITIVO");
				if (val != null)
				{
					flag = true;
				}
			}
			else
			{
				flag = true;
			}
			if (flag)
			{
				TypedValue[] array = val.AsArray();
				object value = array[1].Value;
				if (!Operators.ConditionalCompareObjectEqual(value, "B", TextCompare: true))
				{
					if (!Operators.ConditionalCompareObjectEqual(value, "P", TextCompare: true))
					{
						if (!Operators.ConditionalCompareObjectEqual(value, "A", TextCompare: true))
						{
							if (!Operators.ConditionalCompareObjectEqual(value, "M", TextCompare: true))
							{
								if (Operators.ConditionalCompareObjectEqual(value, "E", TextCompare: true))
								{
									result = new DeclaracoesEntidades.StructurePortas
									{
										Tipo = Conversions.ToString(array[1].Value),
										Nome1 = Conversions.ToString(array[2].Value),
										Nome2 = Conversions.ToString(array[3].Value),
										Alternativo = Conversions.ToString(array[11].Value),
										HandleDaMascara = Conversions.ToString(array[4].Value),
										indiceDoModelo = Conversions.ToInteger(array[5].Value),
										indiceDaPorta = Conversions.ToInteger(array[6].Value),
										handleDaDefinicao = Conversions.ToString(array[9].Value),
										chavePrimaria = Conversions.ToString(array[10].Value),
										HandleBloco = ((object)((DBObject)blockRef).Handle/*cast due to constrained. prefix*/).ToString(),
										Usuario = Conversions.ToString(array[16].Value),
										Data = Conversions.ToString(array[17].Value)
									};
								}
							}
							else
							{
								result = new DeclaracoesEntidades.StructureMascara
								{
									Nome1 = Conversions.ToString(array[2].Value),
									Nome2 = Conversions.ToString(array[3].Value),
									Alternativo = Conversions.ToString(array[4].Value),
									Painel = Conversions.ToShort(array[8].Value),
									indexModelo = Conversions.ToInteger(array[12].Value),
									Complementar = Conversions.ToBoolean(array[13].Value),
									HandleMascPrincipal = Conversions.ToString(array[14].Value),
									Topografico = Conversions.ToString(array[16].Value),
									Layout = Conversions.ToString(array[17].Value),
									iLM1 = Conversions.ToInteger(array[21].Value),
									iLM2 = Conversions.ToInteger(array[23].Value),
									Usuario = Conversions.ToString(array[24].Value),
									Data = Conversions.ToString(array[25].Value)
								};
							}
						}
						else
						{
							result = new DeclaracoesEntidades.StructureAuxiliar
							{
								Nome1 = Conversions.ToString(array[2].Value),
								Nome2 = Conversions.ToString(array[3].Value),
								HandleBob = Conversions.ToString(array[4].Value),
								IndexModelo = Conversions.ToInteger(array[5].Value),
								IndexContato = Conversions.ToInteger(array[6].Value),
								TipoDoContato = Conversions.ToShort(array[7].Value),
								TipoDoComportamento = Conversions.ToShort(array[8].Value),
								Alternativo = Conversions.ToString(array[11].Value),
								Usuario = Conversions.ToString(array[16].Value),
								Data = Conversions.ToString(array[17].Value)
							};
						}
					}
					else
					{
						DeclaracoesEntidades.StructureDispositivo structureDispositivo = new DeclaracoesEntidades.StructureDispositivo
						{
							Nome1 = Conversions.ToString(array[2].Value),
							Nome2 = Conversions.ToString(array[3].Value),
							Alternativo = Conversions.ToString(array[4].Value),
							Painel = Conversions.ToShort(array[8].Value),
							ChavePrimaria = Conversions.ToString(array[11].Value),
							indexModelo = Conversions.ToInteger(array[12].Value),
							Complementar = Conversions.ToBoolean(array[13].Value),
							Layout = Conversions.ToString(array[17].Value),
							Topografico = Conversions.ToString(array[18].Value)
						};
						object value2 = array[19].Value;
						Point3d val2 = ((value2 == null) ? default(Point3d) : ((Point3d)value2));
						structureDispositivo.posX = val2[0];
						structureDispositivo.posY = val2[1];
						structureDispositivo.dAlturaModelo = Conversions.ToDouble(array[20].Value);
						structureDispositivo.iLM1 = Conversions.ToInteger(array[21].Value);
						structureDispositivo.iLM2 = Conversions.ToInteger(array[23].Value);
						structureDispositivo.Usuario = Conversions.ToString(array[24].Value);
						structureDispositivo.Data = Conversions.ToString(array[25].Value);
						double num = Conversions.ToDouble(array[27].Value);
						structureDispositivo.NomeVisivel = false;
						if (checked((int)Math.Round(num)) == 1)
						{
							structureDispositivo.NomeVisivel = true;
						}
						structureDispositivo.AlternativoVisivel = false;
						if ((num > 0.0) & (num - 1.0 == 0.1))
						{
							structureDispositivo.AlternativoVisivel = true;
						}
						structureDispositivo.distContAux = Conversions.ToDouble(array[28].Value);
						result = structureDispositivo;
					}
				}
				else
				{
					DeclaracoesEntidades.StructureBorne structureBorne = new DeclaracoesEntidades.StructureBorne
					{
						PosInt_Jumper = Conversions.ToString(array[3].Value),
						BlocoLayout = Conversions.ToString(array[4].Value),
						Numero = Conversions.ToString(array[5].Value),
						NumeroComplem = Conversions.ToString(array[6].Value),
						Ordem = Conversions.ToDouble(array[7].Value),
						IndiceRegua = Conversions.ToInteger(array[8].Value),
						conector = Conversions.ToString(array[9].Value)
					};
					int lm = 0;
					if (Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(array[10].Value)))
					{
						lm = Conversions.ToInteger(array[10].Value);
					}
					structureBorne.lm = lm;
					structureBorne.Orientacao = Conversions.ToString(array[11].Value);
					structureBorne.tipo = Conversions.ToInteger(array[14].Value);
					structureBorne.Visivel = Conversions.ToInteger(array[15].Value);
					structureBorne.user = Conversions.ToString(array[16].Value);
					structureBorne.data = Conversions.ToString(array[17].Value);
					result = structureBorne;
				}
			}
			return result;
		}
		return result;
	}

	public static void GravarXDataDefinicao(ref Entity Ent, ref DeclaracoesEntidades.StructureDefinicaoPortas Def)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("Definicao"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Definicao";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[5]
				{
					new TypedValue(1001, (object)"Definicao"),
					new TypedValue(1000, (object)Def.HandleDaMascara),
					new TypedValue(1071, (object)Def.indiceDoModelo),
					new TypedValue(1071, (object)Def.indiceDaPorta),
					new TypedValue(1000, (object)Def.handleDaPorta)
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
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

	public static bool LerXDataDefinicao(ref Entity Ent, ref DeclaracoesEntidades.StructureDefinicaoPortas Def)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Definicao");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("DEFINICAO");
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "DEFINICAO", TextCompare: true) == 0)
			{
				Def.Nome = Conversions.ToString(array[0].Value);
				Def.HandleDaMascara = Conversions.ToString(array[1].Value);
				Def.indiceDoModelo = Conversions.ToInteger(array[2].Value);
				Def.indiceDaPorta = Conversions.ToInteger(array[3].Value);
				Def.handleDaPorta = Conversions.ToString(array[4].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataErro(ref Entity Ent, string sTipo, string sDisp, string sHandle)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("ERRO"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "ERRO";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[4]
				{
					new TypedValue(1001, (object)"ERRO"),
					new TypedValue(1000, (object)sTipo.ToUpper()),
					new TypedValue(1000, (object)sDisp.ToUpper()),
					new TypedValue(1000, (object)sHandle)
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
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

	public static object LerXDataErro(ref Entity Ent, string sTipo, ref string sDisp, ref string sHandle)
	{
		bool flag = false;
		bool flag2 = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("ERRO");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("ERRO");
			if (val != null)
			{
				flag2 = true;
			}
		}
		else
		{
			flag2 = true;
		}
		if (flag2)
		{
			flag = true;
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "ERRO", TextCompare: true) != 0)
			{
				flag = false;
			}
			else if (!((Operators.CompareString(array[1].Value.ToString().ToUpper(), sTipo.ToUpper(), TextCompare: true) == 0) | (Operators.CompareString(sTipo, "", TextCompare: true) == 0)))
			{
				flag = false;
			}
			else
			{
				sDisp = Conversions.ToString(array[2].Value);
				if (array.Length > 3)
				{
					sHandle = Conversions.ToString(array[3].Value);
				}
				flag = true;
			}
		}
		return flag;
	}

	public static void GravarXDataDispModelo(ref BlockReference blockRef, ref Declaracoes2.StructureModelo Modelo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("Modelo"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "Modelo";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[5]
			{
				new TypedValue(1001, (object)"Modelo"),
				new TypedValue(1000, (object)Modelo.HandleBob),
				new TypedValue(1071, (object)Modelo.indexModelo),
				new TypedValue(1071, (object)Modelo.indexContato),
				new TypedValue(1000, (object)Modelo.HandleContatoAux)
			};
			((DBObject)blockRef).UpgradeOpen();
			((DBObject)blockRef).XData = new ResultBuffer(array);
			((DBObject)blockRef).DowngradeOpen();
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
	}

	public static bool LerXDataModelo(ref Entity Ent, ref Declaracoes2.StructureModelo Modelo)
	{
		bool result = false;
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Modelo");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("MODELO");
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			if (Operators.CompareString(array[0].Value.ToString().ToUpper(), "MODELO", TextCompare: true) == 0)
			{
				Modelo.HandleBob = Conversions.ToString(array[1].Value);
				Modelo.indexModelo = Conversions.ToInteger(array[2].Value);
				Modelo.indexContato = Conversions.ToInteger(array[3].Value);
				Modelo.HandleContatoAux = Conversions.ToString(array[4].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravarXDataTextoLP(ref Entity Ent, string sChave)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("TextoLP"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "TextoLP";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[6]
				{
					new TypedValue(1001, (object)"TextoLP"),
					new TypedValue(1000, (object)sChave),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1071, (object)0)
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
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

	public static string LerXDataTextoLP(ref Entity Ent)
	{
		string result = "";
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("TextoLP");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("TEXTOLP");
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			result = ((Operators.CompareString(array[0].Value.ToString().ToUpper(), "TEXTOLP", TextCompare: true) == 0) ? Conversions.ToString(array[1].Value) : "");
		}
		return result;
	}

	public static void GravarXDataLinhaTextoLP(ref Entity Ent, string sChave)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Expected Obj, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected Obj, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				RegAppTable val3 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val3).Has("LinhaTextoLP"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "LinhaTextoLP";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[2]
				{
					new TypedValue(1001, (object)"LinhaTextoLP"),
					new TypedValue(1000, (object)sChave)
				};
				((DBObject)Ent).UpgradeOpen();
				((DBObject)Ent).XData = new ResultBuffer(array);
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

	public static string LerXDataLinhaTextoLP(ref Entity Ent)
	{
		string result = "";
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("LinhaTextoLP");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("LINHATEXTOLP");
			if (val != null)
			{
				flag = true;
			}
		}
		else
		{
			flag = true;
		}
		if (flag)
		{
			TypedValue[] array = val.AsArray();
			result = ((Operators.CompareString(array[0].Value.ToString().ToUpper(), "LINHATEXTOLP", TextCompare: true) == 0) ? Conversions.ToString(array[1].Value) : "");
		}
		return result;
	}
}

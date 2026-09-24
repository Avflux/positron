using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;
using ZwSoft.ZwCAD.Geometry;

namespace Eletron4;

public class XDataGeral
{
	public static string verificaTipoXData()
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected Obj, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected Obj, but got Unknown
		string result = "V";
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("Eletron");
			if (xDataForApplication == null)
			{
				xDataForApplication = ((DBObject)val3).GetXDataForApplication("DiagLog");
				if (xDataForApplication == null)
				{
					xDataForApplication = ((DBObject)val3).GetXDataForApplication("ArqNet");
					if (xDataForApplication != null)
					{
						result = "A";
					}
				}
				else
				{
					result = "D";
				}
			}
			else
			{
				result = "E";
			}
			val.Commit();
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

	public static int Contador()
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected Obj, but got Unknown
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected Obj, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected Obj, but got Unknown
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected Obj, but got Unknown
		int num = 0;
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				ResultBuffer xDataForApplication = ((DBObject)val4).GetXDataForApplication("CONTADOR");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					num = Conversions.ToInteger(array[1].Value);
					num = checked(num + 1);
					array[0] = new TypedValue(1001, (object)"CONTADOR");
					array[1] = new TypedValue(1071, (object)num);
					((DBObject)val4).XData = new ResultBuffer(array);
				}
				else
				{
					RegAppTable val5 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
					if (!((SymbolTable)val5).Has("CONTADOR"))
					{
						RegAppTableRecord val6 = new RegAppTableRecord();
						((SymbolTableRecord)val6).Name = "CONTADOR";
						((SymbolTable)val5).Add((SymbolTableRecord)(object)val6);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					}
					num = 1;
					((DBObject)val4).XData = new ResultBuffer(new TypedValue[2]
					{
						new TypedValue(1001, (object)"CONTADOR"),
						new TypedValue(1071, (object)1)
					});
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
		return num;
	}

	public static bool LerXDataConfiguracao()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		try
		{
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("Eletron");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					if (Operators.ConditionalCompareObjectEqual(array[1].Value, "Config", TextCompare: true))
					{
						if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(array[3].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
						{
							DeclaracoesGeral.Conf.Banco = Conversions.ToString(array[3].Value);
						}
						else
						{
							DeclaracoesGeral.Conf.Banco = "A";
						}
						if (!Operators.ConditionalCompareObjectEqual(array[4].Value, "", TextCompare: true))
						{
							DeclaracoesGeral.Conf.SeparadorCarimbo = Conversions.ToString(array[4].Value);
						}
						else
						{
							DeclaracoesGeral.Conf.SeparadorCarimbo = "-";
						}
						DeclaracoesGeral.Conf.PrefixoCruzFF = Conversions.ToString(array[5].Value);
						DeclaracoesGeral.Conf.SufixoCruzFF = Conversions.ToString(array[6].Value);
						DeclaracoesGeral.Conf.PassoPagina = Conversions.ToInteger(array[7].Value);
						DeclaracoesGeral.Conf.Local = Conversions.ToString(array[8].Value);
						DeclaracoesGeral.Conf.PrefixoCruzInterno = Conversions.ToString(array[9].Value);
						DeclaracoesGeral.Conf.SufixoCruzInterno = Conversions.ToString(array[10].Value);
						DeclaracoesGeral.Conf.CorConexao = Conversions.ToInteger(array[11].Value);
						DeclaracoesGeral.Conf.CorTextoCircuito = Conversions.ToInteger(array[12].Value);
						DeclaracoesGeral.Conf.InterligacaoLayout = Conversions.ToInteger(array[13].Value);
						DeclaracoesGeral.Conf.CorInterligacao = Conversions.ToInteger(array[14].Value);
						DeclaracoesGeral.Conf.CorTextoInterligacao = Conversions.ToInteger(array[15].Value);
						DeclaracoesGeral.Conf.SeparadorCaboVeia = Conversions.ToString(array[16].Value);
						if (!Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(array[29].Value, null, "trim", new object[0], null, null, null), "", TextCompare: true))
						{
							DeclaracoesGeral.Conf.EstiloLinha = Conversions.ToString(array[29].Value);
						}
						else
						{
							DeclaracoesGeral.Conf.EstiloLinha = "Continuous";
						}
						if (!Operators.ConditionalCompareObjectEqual(array[36].Value, 0, TextCompare: true))
						{
							DeclaracoesGeral.Conf.EstiloLinhaEscala = Conversions.ToDouble(array[36].Value);
						}
						else
						{
							DeclaracoesGeral.Conf.EstiloLinhaEscala = 1.0;
						}
						DeclaracoesGeral.Conf.SCapa = Conversions.ToBoolean(array[17].Value);
						DeclaracoesGeral.Conf.SCorpo = Conversions.ToBoolean(array[18].Value);
						DeclaracoesGeral.Conf.CCapa = Conversions.ToBoolean(array[19].Value);
						DeclaracoesGeral.Conf.CCorpo = Conversions.ToBoolean(array[20].Value);
						DeclaracoesGeral.Conf.maxCapa = Conversions.ToInteger(array[21].Value);
						DeclaracoesGeral.Conf.maxCorpo = Conversions.ToInteger(array[22].Value);
						DeclaracoesGeral.Conf.PrefixoCruzExterno = Conversions.ToString(array[23].Value);
						DeclaracoesGeral.Conf.SufixoCruzExterno = Conversions.ToString(array[24].Value);
						DeclaracoesGeral.Conf.CaracterTerminalIndefinido = Conversions.ToString(array[25].Value);
						DeclaracoesGeral.Conf.incluirColuna = Conversions.ToInteger(array[26].Value);
						if (!Operators.ConditionalCompareObjectEqual(array[27].Value, "1", TextCompare: true))
						{
							DeclaracoesGeral.Conf.SeparadorPainelRegua = Conversions.ToString(array[27].Value);
						}
						else
						{
							DeclaracoesGeral.Conf.SeparadorPainelRegua = "/";
						}
						DeclaracoesGeral.Conf.Norma = Conversions.ToInteger(array[28].Value);
						DeclaracoesGeral.Conf.SeparadorCruzamento = Conversions.ToString(array[30].Value);
						DeclaracoesGeral.Conf.FonteCircuito = Conversions.ToDouble(array[31].Value);
						DeclaracoesGeral.Conf.FonteCabos = Conversions.ToDouble(array[32].Value);
						DeclaracoesGeral.Conf.ModeloBobina = Conversions.ToInteger(array[33].Value);
						DeclaracoesGeral.Conf.LarguraFixaPaginas = Conversions.ToInteger(array[34].Value);
						if (!Operators.ConditionalCompareObjectEqual(array[35].Value, 0, TextCompare: true))
						{
							DeclaracoesGeral.Conf.FonteCruzamento = Conversions.ToDouble(array[35].Value);
						}
						else
						{
							DeclaracoesGeral.Conf.FonteCruzamento = Conversions.ToDouble(array[31].Value);
						}
						if (Operators.CompareString(DeclaracoesGeral.Conf.SeparadorCruzamento.Trim(), "", TextCompare: true) == 0)
						{
							DeclaracoesGeral.Conf.SeparadorCruzamento = "/";
						}
						if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(array[37].Value)))
						{
							DeclaracoesGeral.Conf.DataSource = Conversions.ToString(array[37].Value);
						}
						else if (Operators.ConditionalCompareObjectEqual(array[37].Value, 0, TextCompare: true))
						{
							DeclaracoesGeral.Conf.DataSource = "";
						}
						if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(array[38].Value)))
						{
							DeclaracoesGeral.Conf.BancoDeDados = Conversions.ToString(array[38].Value);
						}
						else if (Operators.ConditionalCompareObjectEqual(array[38].Value, 0, TextCompare: true))
						{
							DeclaracoesGeral.Conf.BancoDeDados = "";
						}
						if (!Versioned.IsNumeric(RuntimeHelpers.GetObjectValue(array[39].Value)))
						{
							DeclaracoesGeral.Conf.User = Conversions.ToString(array[39].Value);
						}
						else if (Operators.ConditionalCompareObjectEqual(array[39].Value, 0, TextCompare: true))
						{
							DeclaracoesGeral.Conf.User = "";
						}
						if (Operators.CompareString(array[40].Value.ToString(), "0", TextCompare: true) != 0)
						{
							DeclaracoesGeral.Conf.Senha = Conversions.ToString(array[40].Value);
						}
						else
						{
							DeclaracoesGeral.Conf.Senha = "";
						}
						result = true;
					}
				}
				else
				{
					DeclaracoesGeral.Conf.PassoPagina = 1;
					DeclaracoesGeral.Conf.Local = "???";
					DeclaracoesGeral.Conf.CorConexao = 7;
					DeclaracoesGeral.Conf.CorTextoCircuito = 7;
					DeclaracoesGeral.Conf.CorInterligacao = 7;
					DeclaracoesGeral.Conf.CorTextoInterligacao = 7;
					DeclaracoesGeral.Conf.EstiloLinha = "Continuous";
					DeclaracoesGeral.Conf.EstiloLinhaEscala = 1.0;
					DeclaracoesGeral.Conf.SeparadorCaboVeia = "/";
					DeclaracoesGeral.Conf.SeparadorPainelRegua = "/";
					DeclaracoesGeral.Conf.CaracterTerminalIndefinido = "?";
					DeclaracoesGeral.Conf.incluirColuna = 1;
					DeclaracoesGeral.Conf.Norma = 0;
					DeclaracoesGeral.Conf.FonteCircuito = 1.5;
					DeclaracoesGeral.Conf.FonteCruzamento = 1.5;
					DeclaracoesGeral.Conf.FonteCabos = 1.5;
					DeclaracoesGeral.Conf.LarguraFixaPaginas = 0;
					DeclaracoesGeral.Conf.SeparadorCruzamento = "/";
					DeclaracoesGeral.Conf.SeparadorCarimbo = "-";
					DeclaracoesGeral.Conf.PrefixoCruzInterno = "(";
					DeclaracoesGeral.Conf.SufixoCruzInterno = ")";
					DeclaracoesGeral.Conf.PrefixoCruzExterno = "[";
					DeclaracoesGeral.Conf.SufixoCruzExterno = "]";
					DeclaracoesGeral.Conf.PrefixoCruzFF = "(";
					DeclaracoesGeral.Conf.SufixoCruzFF = ")";
					DeclaracoesGeral.Conf.ModeloBobina = 0;
					DeclaracoesGeral.Conf.InterligacaoLayout = 0;
					DeclaracoesGeral.Conf.Banco = "A";
					result = false;
				}
				val.Commit();
				return result;
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
		finally
		{
			((IDisposable)database)?.Dispose();
		}
	}

	public static void GravarXDataConfiguracao()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_025c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Unknown result type (might be due to invalid IL or missing references)
		//IL_0328: Unknown result type (might be due to invalid IL or missing references)
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Unknown result type (might be due to invalid IL or missing references)
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Unknown result type (might be due to invalid IL or missing references)
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03be: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		//IL_0459: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0503: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_0525: Unknown result type (might be due to invalid IL or missing references)
		//IL_052a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0564: Unknown result type (might be due to invalid IL or missing references)
		//IL_057c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Unknown result type (might be due to invalid IL or missing references)
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b1: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					RegAppTable val5 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
					if (!((SymbolTable)val5).Has("Eletron"))
					{
						RegAppTableRecord val6 = new RegAppTableRecord();
						((SymbolTableRecord)val6).Name = "Eletron";
						((SymbolTable)val5).Add((SymbolTableRecord)(object)val6);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					}
					((DBObject)val4).XData = new ResultBuffer(new TypedValue[41]
					{
						new TypedValue(1001, (object)"Eletron"),
						new TypedValue(1000, (object)"Config"),
						new TypedValue(1000, (object)""),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.Banco),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.SeparadorCarimbo),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.PrefixoCruzFF),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.SufixoCruzFF),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.PassoPagina),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.Local),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.PrefixoCruzInterno),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.SufixoCruzInterno),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.CorConexao),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.CorTextoCircuito),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.InterligacaoLayout),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.CorInterligacao),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.CorTextoInterligacao),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.SeparadorCaboVeia),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.SCapa),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.SCorpo),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.CCapa),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.CCorpo),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.maxCapa),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.maxCorpo),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.PrefixoCruzExterno),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.SufixoCruzExterno),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.CaracterTerminalIndefinido),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.incluirColuna),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.SeparadorPainelRegua),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.Norma),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.EstiloLinha),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.SeparadorCruzamento),
						new TypedValue(1040, (object)DeclaracoesGeral.Conf.FonteCircuito),
						new TypedValue(1040, (object)DeclaracoesGeral.Conf.FonteCabos),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.ModeloBobina),
						new TypedValue(1070, (object)DeclaracoesGeral.Conf.LarguraFixaPaginas),
						new TypedValue(1040, (object)DeclaracoesGeral.Conf.FonteCruzamento),
						new TypedValue(1040, (object)DeclaracoesGeral.Conf.EstiloLinhaEscala),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.DataSource),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.BancoDeDados),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.User),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.Senha)
					});
					DeclaracoesGeral.bAnularEventos = true;
					val2.Commit();
					DeclaracoesGeral.bAnularEventos = false;
					DeclaracoesGeral.ativo.Tipo = "E";
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool LerXDataConfiguracao2()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		try
		{
			Transaction val = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
				ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("EletronProj");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					if (Operators.ConditionalCompareObjectEqual(array[1].Value, "Projeto", TextCompare: true))
					{
						DeclaracoesGeral.Conf.DirProjeto = Conversions.ToString(array[2].Value);
						DeclaracoesGeral.Conf.DirSimbologiaEletrica = Conversions.ToString(array[3].Value);
						DeclaracoesGeral.Conf.dirSimbologiaTopografico = Conversions.ToString(array[5].Value);
						DeclaracoesGeral.Conf.dirSimbologiaLayout = Conversions.ToString(array[7].Value);
						DeclaracoesGeral.Conf.dirSimbologiaRelatorios = Conversions.ToString(array[4].Value);
						result = true;
					}
				}
				else
				{
					DeclaracoesGeral.Conf.DirProjeto = "";
					DeclaracoesGeral.Conf.DirSimbologiaEletrica = "";
					DeclaracoesGeral.Conf.dirSimbologiaTopografico = "";
					DeclaracoesGeral.Conf.dirSimbologiaLayout = "";
					DeclaracoesGeral.Conf.dirSimbologiaRelatorios = "";
					result = false;
				}
				val.Commit();
				return result;
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
		finally
		{
			((IDisposable)database)?.Dispose();
		}
	}

	public static void GravarXDataConfiguracao2()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			try
			{
				Transaction val2 = database.TransactionManager.StartTransaction();
				try
				{
					BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
					BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
					RegAppTable val5 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
					if (!((SymbolTable)val5).Has("EletronProj"))
					{
						RegAppTableRecord val6 = new RegAppTableRecord();
						((SymbolTableRecord)val6).Name = "EletronProj";
						((SymbolTable)val5).Add((SymbolTableRecord)(object)val6);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					}
					((DBObject)val4).XData = new ResultBuffer(new TypedValue[8]
					{
						new TypedValue(1001, (object)"EletronProj"),
						new TypedValue(1000, (object)"Projeto"),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.DirProjeto),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.DirSimbologiaEletrica),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.dirSimbologiaRelatorios),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.dirSimbologiaTopografico),
						new TypedValue(1000, (object)""),
						new TypedValue(1000, (object)DeclaracoesGeral.Conf.dirSimbologiaLayout)
					});
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
				((IDisposable)database)?.Dispose();
			}
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool LerXDataConfiguracaoListaDePontos()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("DiagLogLP");
			if (xDataForApplication != null)
			{
				TypedValue[] array = xDataForApplication.AsArray();
				if (Operators.ConditionalCompareObjectEqual(array[1].Value, "LP", TextCompare: true))
				{
					DeclaracoesGeral.ConfLP.listaDePontos = Conversions.ToString(array[3].Value);
					DeclaracoesGeral.ConfLP.worksheet = Conversions.ToString(array[4].Value);
					DeclaracoesGeral.ConfLP.chavePrimaria = Conversions.ToString(array[5].Value);
					DeclaracoesGeral.ConfLP.tag = Conversions.ToString(array[6].Value);
					DeclaracoesGeral.ConfLP.descricaoResumida = Conversions.ToString(array[7].Value);
					DeclaracoesGeral.ConfLP.descricaoCompleta = Conversions.ToString(array[8].Value);
					DeclaracoesGeral.ConfLP.tipoDeSinal = Conversions.ToString(array[10].Value);
					DeclaracoesGeral.ConfLP.unidade = Conversions.ToString(array[11].Value);
					DeclaracoesGeral.ConfLP.funcaoPorta = Conversions.ToString(array[12].Value);
					DeclaracoesGeral.ConfLP.enderecoFisico = Conversions.ToString(array[13].Value);
					DeclaracoesGeral.ConfLP.posicaoLogico = Conversions.ToString(array[17].Value);
					DeclaracoesGeral.ConfLP.posicaoFuncional = Conversions.ToString(array[18].Value);
					DeclaracoesGeral.ConfLP.documentoFuncional = Conversions.ToString(array[19].Value);
					DeclaracoesGeral.ConfLP.documentoLogico = Conversions.ToString(array[20].Value);
					result = true;
				}
			}
			else
			{
				DeclaracoesGeral.ConfLP.listaDePontos = "";
				DeclaracoesGeral.ConfLP.worksheet = "";
				DeclaracoesGeral.ConfLP.chavePrimaria = "";
				DeclaracoesGeral.ConfLP.tag = "";
				DeclaracoesGeral.ConfLP.descricaoResumida = "";
				DeclaracoesGeral.ConfLP.descricaoCompleta = "";
				DeclaracoesGeral.ConfLP.tipoDeSinal = "";
				DeclaracoesGeral.ConfLP.unidade = "";
				DeclaracoesGeral.ConfLP.funcaoPorta = "";
				DeclaracoesGeral.ConfLP.enderecoFisico = "";
				DeclaracoesGeral.ConfLP.posicaoLogico = "";
				DeclaracoesGeral.ConfLP.posicaoFuncional = "";
				DeclaracoesGeral.ConfLP.documentoFuncional = "";
				DeclaracoesGeral.ConfLP.documentoLogico = "";
				result = false;
			}
			val.Commit();
			return result;
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

	public static void GravarXDataConfiguracaoListaDePontos()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected Obj, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected Obj, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0252: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_030e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Unknown result type (might be due to invalid IL or missing references)
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0403: Unknown result type (might be due to invalid IL or missing references)
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_041b: Unknown result type (might be due to invalid IL or missing references)
		//IL_042e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0433: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_044b: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_047b: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0493: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Expected Obj, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		DocumentLock val = Application.DocumentManager.MdiActiveDocument.LockDocument();
		try
		{
			Database database = Application.DocumentManager.MdiActiveDocument.Database;
			Transaction val2 = database.TransactionManager.StartTransaction();
			try
			{
				BlockTable val3 = (BlockTable)val2.GetObject(database.BlockTableId, (OpenMode)0);
				BlockTableRecord val4 = (BlockTableRecord)val2.GetObject(((SymbolTable)val3)[BlockTableRecord.ModelSpace], (OpenMode)1);
				RegAppTable val5 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
				if (!((SymbolTable)val5).Has("DiagLogLP"))
				{
					RegAppTableRecord val6 = new RegAppTableRecord();
					((SymbolTableRecord)val6).Name = "DiagLogLP";
					((SymbolTable)val5).Add((SymbolTableRecord)(object)val6);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
				}
				((DBObject)val4).XData = new ResultBuffer(new TypedValue[39]
				{
					new TypedValue(1001, (object)"DiagLogLP"),
					new TypedValue(1000, (object)"LP"),
					new TypedValue(1070, (object)0),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.listaDePontos),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.worksheet),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.chavePrimaria),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.tag),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.descricaoResumida),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.descricaoCompleta),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.tipoDeSinal),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.unidade),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.funcaoPorta),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.enderecoFisico),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.posicaoLogico),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.posicaoFuncional),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.documentoFuncional),
					new TypedValue(1000, (object)DeclaracoesGeral.ConfLP.documentoLogico),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)""),
					new TypedValue(1000, (object)"")
				});
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

	public static void GravarXDataFormato(ref BlockReference blockRef)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("DiagLog"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "DiagLog";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[4]
			{
				new TypedValue(1001, (object)"DiagLog"),
				new TypedValue(1000, (object)"Formato"),
				new TypedValue(1070, (object)3),
				new TypedValue(1000, (object)" ")
			};
			((DBObject)blockRef).XData = new ResultBuffer(array);
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

	public static bool PossuiXDataFormato(ref BlockReference blockRef)
	{
		ResultBuffer xDataForApplication = ((DBObject)blockRef).GetXDataForApplication("DiagLog");
		if (xDataForApplication == null)
		{
			return false;
		}
		TypedValue[] array = xDataForApplication.AsArray();
		if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "FORMATO", TextCompare: true) != 0)
		{
			return false;
		}
		return true;
	}

	public static void gravarXDataTitulo(ref DBText texto, int tipo, string valor)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("DiagLog"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "DiagLog";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[10]
			{
				new TypedValue(1001, (object)"DiagLog"),
				new TypedValue(1000, (object)"TituloPagina"),
				new TypedValue(1070, (object)tipo),
				new TypedValue(1000, (object)valor),
				new TypedValue(1070, (object)1),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1071, (object)1),
				new TypedValue(1040, (object)1),
				new TypedValue(1000, (object)" ")
			};
			((DBObject)texto).XData = new ResultBuffer(array);
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

	public static int LeXDataTitulo(ref DBText text)
	{
		ResultBuffer xDataForApplication = ((DBObject)text).GetXDataForApplication("DiagLog");
		if (xDataForApplication == null)
		{
			return 0;
		}
		TypedValue[] array = xDataForApplication.AsArray();
		if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "TITULOPAGINA", TextCompare: true) != 0)
		{
			return 0;
		}
		return Conversions.ToInteger(array[2].Value);
	}

	public static void GravarXDataUnidadeAlternativo(ref LayerTableRecord layer, string unidade, string alternativo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("Eletron"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "Eletron";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[4]
			{
				new TypedValue(1001, (object)"Eletron"),
				new TypedValue(1000, (object)"Unidade"),
				new TypedValue(1000, (object)unidade),
				new TypedValue(1000, (object)alternativo)
			};
			((DBObject)layer).XData = new ResultBuffer(array);
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

	public static void LeXDataUnidadeAlternativo(ref LayerTableRecord Layer, ref string unidade, ref string alternativo)
	{
		unidade = "";
		alternativo = "";
		ResultBuffer xDataForApplication = ((DBObject)Layer).GetXDataForApplication("Eletron");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "UNIDADE", TextCompare: true) == 0)
			{
				unidade = Conversions.ToString(array[2].Value);
				alternativo = Conversions.ToString(array[3].Value);
			}
		}
	}

	public static void LeXDataUnidadeAlternativo2(ref string pagina, ref string unidade, ref string alternativo)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected Obj, but got Unknown
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			unidade = "";
			alternativo = "";
			LayerTable val = (LayerTable)topTransaction.GetObject(database.LayerTableId, (OpenMode)0);
			if (!((SymbolTable)val).Has(pagina))
			{
				return;
			}
			ObjectId val2 = ((SymbolTable)val)[pagina];
			LayerTableRecord val3 = (LayerTableRecord)topTransaction.GetObject(val2, (OpenMode)0);
			ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("Eletron");
			if (xDataForApplication != null)
			{
				TypedValue[] array = xDataForApplication.AsArray();
				if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "UNIDADE", TextCompare: true) == 0)
				{
					unidade = Conversions.ToString(array[2].Value);
					alternativo = Conversions.ToString(array[3].Value);
				}
			}
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

	public static void LeXDataUnidadeAlternativoRemoto(ref Database db, ref string pagina, ref string unidade, ref string alternativo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected Obj, but got Unknown
		Transaction val = (Transaction)(object)db.TransactionManager.StartOpenCloseTransaction();
		try
		{
			unidade = "";
			alternativo = "";
			LayerTable val2 = (LayerTable)val.GetObject(db.LayerTableId, (OpenMode)0);
			if (((SymbolTable)val2).Has(pagina))
			{
				ObjectId val3 = ((SymbolTable)val2)[pagina];
				LayerTableRecord val4 = (LayerTableRecord)val.GetObject(val3, (OpenMode)0);
				ResultBuffer xDataForApplication = ((DBObject)val4).GetXDataForApplication("Eletron");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "UNIDADE", TextCompare: true) == 0)
					{
						unidade = Conversions.ToString(array[2].Value);
						alternativo = Conversions.ToString(array[3].Value);
					}
				}
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

	public static void AlteraXDataUnidadeAlternativo(string pagina, string unidade, string alternativo)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected Obj, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected Obj, but got Unknown
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected Obj, but got Unknown
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
						if (Operators.CompareString(((SymbolTableRecord)layer).Name.ToString(), pagina, TextCompare: true) != 0)
						{
							continue;
						}
						((DBObject)layer).UpgradeOpen();
						ResultBuffer xDataForApplication = ((DBObject)layer).GetXDataForApplication("Eletron");
						if (xDataForApplication == null)
						{
							GravarXDataUnidadeAlternativo(ref layer, unidade, alternativo);
							break;
						}
						TypedValue[] array = xDataForApplication.AsArray();
						if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "UNIDADE", TextCompare: true) == 0)
						{
							array[2] = new TypedValue(1000, (object)unidade);
							array[3] = new TypedValue(1000, (object)alternativo);
							((DBObject)layer).XData = new ResultBuffer(array);
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

	public static bool LeXDataRevisao(ref BlockReference blockRef, ref DeclaracoesGeral.Revisoes revC)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)blockRef).GetXDataForApplication("DiagLog");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REVISAO", TextCompare: true) == 0)
			{
				revC.Posicao = Conversions.ToInteger(array[2].Value);
				revC.RevisaoOriginal = Conversions.ToString(array[3].Value);
				revC.Revisao = Conversions.ToString(array[3].Value);
				revC.Descricao = Conversions.ToString(array[4].Value);
				revC.Elaborador = Conversions.ToString(array[5].Value);
				revC.Verificador = Conversions.ToString(array[6].Value);
				revC.Aprovador = Conversions.ToString(array[7].Value);
				revC.Data = Conversions.ToString(array[8].Value);
				result = true;
			}
		}
		return result;
	}

	public static void gravarXDataRevisao(ref Entity ent, DeclaracoesGeral.Revisoes revC)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("DiagLog"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "DiagLog";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[15]
			{
				new TypedValue(1001, (object)"DiagLog"),
				new TypedValue(1000, (object)"Revisao"),
				new TypedValue(1070, (object)revC.Posicao),
				new TypedValue(1000, (object)revC.Revisao),
				new TypedValue(1000, (object)revC.Descricao),
				new TypedValue(1000, (object)revC.Elaborador),
				new TypedValue(1000, (object)revC.Verificador),
				new TypedValue(1000, (object)revC.Aprovador),
				new TypedValue(1000, (object)revC.Data),
				new TypedValue(1070, (object)1),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1071, (object)1),
				new TypedValue(1040, (object)1.1),
				new TypedValue(1000, (object)" ")
			};
			((DBObject)ent).XData = new ResultBuffer(array);
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

	public static bool LeXDataRevisaoAutomatica(ref Entity ent, ref string rev, [Optional][DefaultParameterValue(1)] ref int iCor)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("DiagLog");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REVISAOAUTOMATICA", TextCompare: true) == 0)
			{
				rev = Conversions.ToString(array[3].Value);
				iCor = Conversions.ToInteger(array[2].Value);
				if (iCor == 0)
				{
					iCor = 1;
				}
				result = true;
			}
		}
		return result;
	}

	public static void gravarXDataRevisaoAutomatica(ref Entity ent, string rev, int iCor)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("DiagLog"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "DiagLog";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[15]
			{
				new TypedValue(1001, (object)"DiagLog"),
				new TypedValue(1000, (object)"RevisaoAutomatica"),
				new TypedValue(1070, (object)iCor),
				new TypedValue(1000, (object)rev),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1070, (object)1),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1071, (object)1),
				new TypedValue(1040, (object)1.1),
				new TypedValue(1000, (object)" ")
			};
			((DBObject)ent).XData = new ResultBuffer(array);
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

	public static bool LeXDataReguaH(ref DeclaracoesGeral.Reguas RH)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			if (((SymbolTable)val2).Has("ReguaH"))
			{
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)["ReguaH"], (OpenMode)0);
				ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("Eletron");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REGUAH", TextCompare: true) == 0)
					{
						RH.Inicio = Conversions.ToString(array[2].Value);
						RH.Fim = Conversions.ToString(array[3].Value);
						RH.Delta = Conversions.ToDouble(array[4].Value);
						RH.AltBase = Conversions.ToDouble(array[5].Value);
						object value = array[6].Value;
						RH.Pti = ((value == null) ? default(Point3d) : ((Point3d)value));
						RH.LarguraBase = RH.Pti.X + (Conversions.ToDouble(RH.Fim) - Conversions.ToDouble(RH.Inicio) + 1.0) * RH.Delta;
						result = true;
					}
				}
			}
			val.Commit();
			return result;
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

	public static void gravarXDataReguaH(ref BlockTableRecord novaRegua, DeclaracoesGeral.Reguas rg)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("Eletron"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "Eletron";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[13]
			{
				new TypedValue(1001, (object)"Eletron"),
				new TypedValue(1000, (object)"ReguaH"),
				new TypedValue(1070, (object)Conversions.ToInteger(rg.Inicio)),
				new TypedValue(1070, (object)Conversions.ToInteger(rg.Fim)),
				new TypedValue(1040, (object)rg.Delta),
				new TypedValue(1040, (object)rg.AltBase),
				new TypedValue(1011, (object)rg.Pti),
				new TypedValue(1070, (object)0),
				new TypedValue(1000, (object)Environment.UserName.ToString()),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1071, (object)0),
				new TypedValue(1040, (object)1.1),
				new TypedValue(1000, (object)" ")
			};
			((DBObject)novaRegua).XData = new ResultBuffer(array);
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

	public static bool LeXDataReguaV(ref DeclaracoesGeral.Reguas RH)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected Obj, but got Unknown
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			if (((SymbolTable)val2).Has("ReguaV"))
			{
				BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)["ReguaV"], (OpenMode)0);
				ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("Eletron");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "REGUAV", TextCompare: true) == 0)
					{
						RH.Inicio = Conversions.ToString(array[2].Value);
						RH.Fim = Conversions.ToString(array[3].Value);
						RH.Delta = Conversions.ToDouble(array[4].Value);
						RH.Div = Conversions.ToDouble(array[5].Value);
						object value = array[6].Value;
						RH.Pti = ((value == null) ? default(Point3d) : ((Point3d)value));
						result = true;
					}
				}
			}
			val.Commit();
			return result;
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

	public static void gravarXDataReguaV(ref BlockTableRecord novaRegua, DeclaracoesGeral.Reguas rg)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("Eletron"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "Eletron";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[13]
			{
				new TypedValue(1001, (object)"Eletron"),
				new TypedValue(1000, (object)"ReguaV"),
				new TypedValue(1070, (object)Strings.Asc(rg.Inicio)),
				new TypedValue(1070, (object)Strings.Asc(rg.Fim)),
				new TypedValue(1040, (object)rg.Delta),
				new TypedValue(1040, (object)rg.Div),
				new TypedValue(1011, (object)rg.Pti),
				new TypedValue(1070, (object)0),
				new TypedValue(1000, (object)Environment.UserName.ToString()),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1071, (object)0),
				new TypedValue(1040, (object)1.1),
				new TypedValue(1000, (object)" ")
			};
			((DBObject)novaRegua).XData = new ResultBuffer(array);
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

	public static void gravarXDataColuna(Entity ent, string tipo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("DiagLog"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "DiagLog";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			((DBObject)ent).XData = new ResultBuffer(new TypedValue[5]
			{
				new TypedValue(1001, (object)"DiagLog"),
				new TypedValue(1000, (object)"COLUNAS"),
				new TypedValue(1000, (object)tipo),
				new TypedValue(1000, (object)Environment.UserName.ToString()),
				new TypedValue(1000, (object)DateTime.Now.ToString())
			});
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

	public static string verificaXDataColunas(Entity ent)
	{
		string result = "0";
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("DiagLog");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "COLUNAS", TextCompare: true) == 0)
			{
				result = Conversions.ToString(array[2].Value);
			}
		}
		return result;
	}

	public static bool TemXData(ref Entity ent, string sNomexData)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication(sNomexData);
		if (xDataForApplication == null)
		{
			xDataForApplication = ((DBObject)ent).GetXDataForApplication(sNomexData.ToUpper());
			if (xDataForApplication != null)
			{
				result = true;
			}
		}
		else
		{
			result = true;
		}
		return result;
	}

	public static bool verificaCoelba()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected Obj, but got Unknown
		bool result = false;
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			BlockTable val2 = (BlockTable)val.GetObject(database.BlockTableId, (OpenMode)0);
			BlockTableRecord val3 = (BlockTableRecord)val.GetObject(((SymbolTable)val2)[BlockTableRecord.ModelSpace], (OpenMode)0);
			ResultBuffer xDataForApplication = ((DBObject)val3).GetXDataForApplication("Eletron");
			if (xDataForApplication != null)
			{
				TypedValue[] array = xDataForApplication.AsArray();
				if (Operators.ConditionalCompareObjectEqual(array[1].Value, "Config", TextCompare: true) && Operators.ConditionalCompareObjectEqual(array[33].Value, 1, TextCompare: true))
				{
					result = true;
				}
			}
			else
			{
				result = false;
			}
			val.Commit();
			return result;
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

	public static void gravarXDataCopiaSemFuncaoEletrica(ref Entity ent, string sHandle)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("Eletron"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "Eletron";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[7]
			{
				new TypedValue(1001, (object)"Eletron"),
				new TypedValue(1000, (object)"COPIAELETRON"),
				new TypedValue(1000, (object)sHandle),
				new TypedValue(1000, (object)""),
				new TypedValue(1070, (object)0),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString())
			};
			((DBObject)ent).XData = new ResultBuffer(array);
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

	public static bool leXDataCopiaSemFuncaoEletrica(ref Entity ent, ref string rev)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("Eletron");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.CompareString(array[1].Value.ToString().ToUpper(), "COPIAELETRON", TextCompare: true) == 0)
			{
				rev = Conversions.ToString(array[2].Value);
				result = true;
			}
		}
		return result;
	}

	public static void GravaxdataPonto(ref Entity Ent)
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
				if (!((SymbolTable)val3).Has("Eletron"))
				{
					RegAppTableRecord val4 = new RegAppTableRecord();
					((SymbolTableRecord)val4).Name = "Eletron";
					((SymbolTable)val3).Add((SymbolTableRecord)(object)val4);
					DeclaracoesGeral.bAnularEventos = true;
					val2.AddNewlyCreatedDBObject((DBObject)(object)val4, true);
				}
				TypedValue[] array = new TypedValue[2]
				{
					new TypedValue(1001, (object)"Eletron"),
					new TypedValue(1000, (object)"PONTO")
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

	public static bool LerXDataPonto(ref Entity Ent)
	{
		bool flag = false;
		ResultBuffer val = null;
		val = ((DBObject)Ent).GetXDataForApplication("Eletron");
		if (val == null)
		{
			val = ((DBObject)Ent).GetXDataForApplication("Eletron".ToUpper());
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
			flag = Operators.CompareString(array[0].Value.ToString().ToUpper(), "Eletron".ToUpper(), TextCompare: true) == 0 && Operators.CompareString(array[1].Value.ToString().ToUpper(), "PONTO", TextCompare: true) == 0;
		}
		return flag;
	}

	public static bool TemXdataEletron(string sValor)
	{
		bool result = false;
		string[] collection = new string[37]
		{
			"ARANHA", "AUXBORNES", "AUXCONEXAO", "AUXDERIVACAO", "AUXEXPORTADO", "AUXIMPORTADO", "AUXINTERLIG", "BLOCKREF", "CODEXPORT", "CONEXAO",
			"CONFIGTOPOGRAFICO", "CONSTRUTOR", "CONTADOR", "CORRECAO", "DEFINICAO", "DEPARA", "DIAGLOGLP", "DINTERLIG", "DISP_FUNCAO", "DISPOSITIVO",
			"DISTRIBUICAODEPOTENCIAIS", "DISTRIBUICAODEPOTENCIAISLINHA", "ELETRONPROJ", "ELETROSUL", "ENEL", "DISPOSITIVO", "ERRO", "EXPORTADO", "IMPORTADO", "INTERLIGACAO",
			"LAYOUT", "LINHATEXTOLP", "MODELO", "BURST_OLE", "POTENCIAL", "TEXTOLP", "TOPOGRAFICO"
		};
		List<string> list = new List<string>(collection);
		if (list.Contains(sValor))
		{
			result = true;
		}
		return result;
	}
}

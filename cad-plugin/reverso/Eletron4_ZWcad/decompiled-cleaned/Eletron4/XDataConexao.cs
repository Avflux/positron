using System;
using Microsoft.VisualBasic.CompilerServices;
using ZwSoft.ZwCAD.ApplicationServices;
using ZwSoft.ZwCAD.ApplicationServices.Core;
using ZwSoft.ZwCAD.DatabaseServices;

namespace Eletron4;

public class XDataConexao
{
	public static int BuscaPotencial()
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
				ResultBuffer xDataForApplication = ((DBObject)val4).GetXDataForApplication("POTENCIAL");
				if (xDataForApplication != null)
				{
					TypedValue[] array = xDataForApplication.AsArray();
					num = Conversions.ToInteger(array[1].Value);
					num = checked(num + 1);
					array[0] = new TypedValue(1001, (object)"POTENCIAL");
					array[1] = new TypedValue(1071, (object)num);
					((DBObject)val4).XData = new ResultBuffer(array);
				}
				else
				{
					RegAppTable val5 = (RegAppTable)val2.GetObject(database.RegAppTableId, (OpenMode)1);
					if (!((SymbolTable)val5).Has("POTENCIAL"))
					{
						RegAppTableRecord val6 = new RegAppTableRecord();
						((SymbolTableRecord)val6).Name = "POTENCIAL";
						((SymbolTable)val5).Add((SymbolTableRecord)(object)val6);
						DeclaracoesGeral.bAnularEventos = true;
						val2.AddNewlyCreatedDBObject((DBObject)(object)val6, true);
					}
					num = 1;
					((DBObject)val4).XData = new ResultBuffer(new TypedValue[2]
					{
						new TypedValue(1001, (object)"POTENCIAL"),
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

	public static void GravarXDataConexao(ref Polyline pl, DeclaracoesEntidades.StructureConexao conex)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0264: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("CONEXAO"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "CONEXAO";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[25]
			{
				new TypedValue(1001, (object)"CONEXAO"),
				new TypedValue(1070, (object)conex.Tipo),
				new TypedValue(1071, (object)conex.Potencial),
				new TypedValue(1000, (object)conex.Handle),
				new TypedValue(1070, (object)conex.Painel),
				new TypedValue(1070, (object)conex.Aplicacao),
				new TypedValue(1070, (object)0),
				new TypedValue(1000, (object)conex.Nome),
				new TypedValue(1000, (object)conex.Funcao),
				new TypedValue(1000, (object)conex.Tensao),
				new TypedValue(1000, (object)conex.Secao),
				new TypedValue(1000, (object)conex.Cor),
				new TypedValue(1000, (object)""),
				new TypedValue(1040, (object)0),
				new TypedValue(1070, (object)(0 - (conex.Disp1 ? 1 : 0))),
				new TypedValue(1070, (object)(0 - (conex.Disp2 ? 1 : 0))),
				new TypedValue(1000, (object)conex.Jumper),
				new TypedValue(1000, (object)""),
				new TypedValue(1071, (object)conex.Enderecamento),
				new TypedValue(1071, (object)1),
				new TypedValue(1000, (object)conex.Usuario),
				new TypedValue(1000, (object)conex.Data),
				new TypedValue(1071, (object)1),
				new TypedValue(1040, (object)0),
				new TypedValue(1000, (object)"")
			};
			((DBObject)pl).XData = new ResultBuffer(array);
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

	public static bool lerXDataConexao(ref Polyline pl, ref DeclaracoesEntidades.StructureConexao conex)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)pl).GetXDataForApplication("CONEXAO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			conex.Tipo = Conversions.ToShort(array[1].Value);
			conex.Potencial = Conversions.ToInteger(array[2].Value);
			conex.Handle = Conversions.ToString(array[3].Value);
			conex.Painel = Conversions.ToShort(array[4].Value);
			conex.Aplicacao = Conversions.ToInteger(array[5].Value);
			conex.Nome = Conversions.ToString(array[7].Value);
			conex.Funcao = Conversions.ToString(array[8].Value);
			conex.Tensao = Conversions.ToString(array[9].Value);
			conex.Secao = Conversions.ToString(array[10].Value);
			conex.Cor = Conversions.ToString(array[11].Value);
			conex.Disp1 = Conversions.ToBoolean(array[14].Value);
			conex.Disp2 = Conversions.ToBoolean(array[15].Value);
			conex.Jumper = Conversions.ToString(array[16].Value);
			conex.Enderecamento = Conversions.ToInteger(array[18].Value);
			conex.Usuario = Conversions.ToString(array[20].Value);
			conex.Data = Conversions.ToString(array[21].Value);
			result = true;
		}
		return result;
	}

	public static void GravarXDataHatchLinha(ref Entity ent, string handle, short tipo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction val = database.TransactionManager.StartTransaction();
		try
		{
			RegAppTable val2 = (RegAppTable)val.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val2).Has("AUXDERIVACAO"))
			{
				RegAppTableRecord val3 = new RegAppTableRecord();
				((SymbolTableRecord)val3).Name = "AUXDERIVACAO";
				((SymbolTable)val2).Add((SymbolTableRecord)(object)val3);
				DeclaracoesGeral.bAnularEventos = true;
				val.AddNewlyCreatedDBObject((DBObject)(object)val3, true);
			}
			TypedValue[] array = new TypedValue[6]
			{
				new TypedValue(1001, (object)"AUXDERIVACAO"),
				new TypedValue(1070, (object)tipo),
				new TypedValue(1000, (object)handle),
				new TypedValue(1071, (object)1),
				new TypedValue(1040, (object)0),
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
			throw;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	public static bool lerXDataHatchLinha(ref Entity ent, ref short tipo)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXDERIVACAO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			tipo = Conversions.ToShort(array[1].Value);
			result = true;
		}
		return result;
	}

	public static bool checaHandleDerivacaoLinha(ref Entity ent, string handle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXDERIVACAO");
		if (xDataForApplication == null)
		{
			result = false;
		}
		else
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (!Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(array[1].Value, 1, TextCompare: true), Operators.CompareObjectEqual(array[1].Value, 2, TextCompare: true))))
			{
				result = false;
			}
			else if (Operators.ConditionalCompareObjectEqual(array[2].Value, handle, TextCompare: true))
			{
				result = true;
			}
		}
		return result;
	}

	public static string leHandleDerivacaoLinha(ref Entity ent)
	{
		string result = "";
		if (ent != null)
		{
			ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXDERIVACAO");
			if (xDataForApplication != null)
			{
				TypedValue[] array = xDataForApplication.AsArray();
				if (Conversions.ToBoolean(Operators.OrObject(Operators.CompareObjectEqual(array[1].Value, 1, TextCompare: true), Operators.CompareObjectEqual(array[1].Value, 2, TextCompare: true))))
				{
					result = Conversions.ToString(array[2].Value);
				}
			}
		}
		return result;
	}

	public static bool checaDerivacao(ref Entity ent, ref string handle)
	{
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXDERIVACAO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[1].Value, 1, TextCompare: true))
			{
				handle = Conversions.ToString(array[2].Value);
				return true;
			}
		}
		return false;
	}

	public static void GravarXDataAuxCircuito(ref DBText text, int potencial, string handle, int enderecamento, short tipo)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected Obj, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected Obj, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Expected Obj, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		Database database = Application.DocumentManager.MdiActiveDocument.Database;
		Transaction topTransaction = database.TransactionManager.TopTransaction;
		try
		{
			RegAppTable val = (RegAppTable)topTransaction.GetObject(database.RegAppTableId, (OpenMode)1);
			if (!((SymbolTable)val).Has("AUXCONEXAO"))
			{
				RegAppTableRecord val2 = new RegAppTableRecord();
				((SymbolTableRecord)val2).Name = "AUXCONEXAO";
				((SymbolTable)val).Add((SymbolTableRecord)(object)val2);
				DeclaracoesGeral.bAnularEventos = true;
				topTransaction.AddNewlyCreatedDBObject((DBObject)(object)val2, true);
			}
			TypedValue[] array = new TypedValue[12]
			{
				new TypedValue(1001, (object)"AUXCONEXAO"),
				new TypedValue(1070, (object)tipo),
				new TypedValue(1071, (object)potencial),
				new TypedValue(1000, (object)handle),
				new TypedValue(1000, (object)""),
				new TypedValue(1000, (object)""),
				new TypedValue(1071, (object)enderecamento),
				new TypedValue(1000, (object)Environment.UserName),
				new TypedValue(1000, (object)DateTime.Now.ToString()),
				new TypedValue(1071, (object)1),
				new TypedValue(1040, (object)0),
				new TypedValue(1000, (object)" ")
			};
			((DBObject)text).XData = new ResultBuffer(array);
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

	public static bool lerXDataAuxCircuito(ref DBText text, ref int potencial, ref string handle, ref int enderecamento, ref short tipo)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)text).GetXDataForApplication("AUXCONEXAO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			tipo = Conversions.ToShort(array[1].Value);
			potencial = Conversions.ToInteger(array[2].Value);
			handle = Conversions.ToString(array[3].Value);
			enderecamento = Conversions.ToInteger(array[6].Value);
			result = true;
		}
		return result;
	}

	public static bool checaHandleTextoAuxConexao(ref Entity ent, string handle)
	{
		bool result = false;
		ResultBuffer xDataForApplication = ((DBObject)ent).GetXDataForApplication("AUXCONEXAO");
		if (xDataForApplication != null)
		{
			TypedValue[] array = xDataForApplication.AsArray();
			if (Operators.ConditionalCompareObjectEqual(array[3].Value, handle, TextCompare: true))
			{
				result = true;
			}
		}
		return result;
	}
}
